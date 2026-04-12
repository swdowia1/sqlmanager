using ExpertSender.Cdp.Common.Enums.Customer;
using ExpertSender.Cdp.DataModel.DTO.Segments;
using ExpertSender.Cdp.DataModel.UnitEntities.Customer;
using ExpertSender.Cdp.Lib.Segments.Abstract;
using ExpertSender.Cdp.Lib.Segments.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace ExpertSender.Cdp.Lib.Segments;

/// <summary>
/// Root restriction for all customer segments
/// </summary>
public class MasterRestriction : LogicalRestriction
{
    /// <summary>
    /// Default list of columns the main query should return
    /// </summary>
    private const string DefaultSelectedColumns = "c.Id";

    private const string CountTotalSelected = "COUNT(1) AS Total";

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="serviceProvider">Service provider</param>
    public MasterRestriction(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    /// <summary>
    /// Initializes the restriction from parsed JSON
    /// </summary>
    /// <param name="o">Parsed JSON part representing the restriction</param>
    /// <param name="data">Segment initialization data</param>
    /// <param name="attributes">Optional collection of custom attributes</param>
    /// <param name="consentIds">Optional collection of consent ids</param>
    public override async Task Init(JObject o, SegmentInitializationData data,
        CustomerAttributeInfo[] attributes = null, int[] consentIds = null)
    {
        Data = data;
        // attributes and consentIds are unused here
        await MasterRestrictionSerializer.FromJson(this, o);
    }

    /// <summary>
    /// Initializes the restriction without JSON
    /// </summary>
    /// <param name="data">Segment initialization data</param>
    public void InitEmpty(SegmentInitializationData data)
    {
        Data = data;
        SubRestrictions = new List<IRestriction>();
    }

    /// <summary>
    /// Generates part of SQL query representing the restriction
    /// </summary>
    /// <returns>SQL</returns>
    public override RestrictionResult ToSql()
    {
        return ToSql(null);
    }

    /// <summary>
    /// Generates part of SQL query representing the restriction
    /// </summary>
    /// <param name="selectedColumns">String with list of columns to return</param>
    /// <param name="additionalTables">Implicitly used tables that need to be included in segment query</param>
    /// <param name="segmentId">Segment Id for add comment</param>
    /// <returns>SQL</returns>
    public RestrictionResult ToSql(string selectedColumns, TablesUsage additionalTables = null, int segmentId = 0)
    {
        // build baseRestriction
        var baseRestriction = BuildBaseRestriction();
        RestrictionResult res = baseRestriction.ToSql();

        selectedColumns ??= DefaultSelectedColumns;

        var tablesUsage = baseRestriction.CheckTablesUsage();

        if (additionalTables is not null)
        {
            tablesUsage += additionalTables;
        }

        string emailJoin = $@"
                LEFT JOIN
                    [Customer].[CustomerEmail] AS ce WITH (NOLOCK)
                ON
                    c.[Id] = ce.[CustomerId]
                    AND ce.[Status] = {(byte)CustomerStatus.Active}";

        string domainJoin = @"
                LEFT JOIN
                    [Email].[Domain] AS d WITH (NOLOCK)
                ON
                    ce.[DomainId] = d.[Id]";

        string phoneJoin = $@"
                LEFT JOIN
                    [Customer].[CustomerPhone] AS cp WITH (NOLOCK)
                ON
                    c.[Id] = cp.[CustomerId]
                    AND cp.[Status] = {(byte)CustomerStatus.Active}";

        string webPushJoin = $@"
                LEFT JOIN
                    [Customer].[CustomerWebPush] AS cwp WITH (NOLOCK)
                ON
                    c.[Id] = cwp.[CustomerId]
                    AND cwp.[Status] = {(byte)CustomerStatus.Active}";

        string mobileJoin = $@"
                LEFT JOIN
                    [Customer].[CustomerMobileDevice] AS cmd WITH (NOLOCK)
                ON
                    c.[Id] = cmd.[CustomerId]
                    AND cmd.[Status] = {(byte)CustomerStatus.Active}";
        if (selectedColumns == DefaultSelectedColumns || selectedColumns == CountTotalSelected)
        {
            mobileJoin = $@"
                LEFT JOIN (
                    SELECT DISTINCT cmd.CustomerId,0 as Id
                    FROM [Customer].[CustomerMobileDevice] AS cmd WITH (NOLOCK)
                    WHERE cmd.[Status] = {(byte)CustomerStatus.Active}
                ) AS cmd ON c.[Id] = cmd.[CustomerId]";
        }
        string finalSql = $@"
                SELECT {(segmentId != 0 ? $"/* SegmentId = {segmentId} */ " : string.Empty)}
                    {selectedColumns}
                FROM
                    [Customer].[Customer] AS c WITH (NOLOCK)
              {(tablesUsage.UsesEmail || tablesUsage.UsesDomain ? emailJoin : string.Empty)}
              {(tablesUsage.UsesDomain ? domainJoin : string.Empty)}
              {(tablesUsage.UsesPhone ? phoneJoin : string.Empty)}
              {(tablesUsage.UsesWebPush ? webPushJoin : string.Empty)}
              {(tablesUsage.UsesMobile ? mobileJoin : string.Empty)}
              {string.Join(Environment.NewLine, res.JoinExpressions)}
              WHERE
                  c.Status = {(byte)CustomerStatus.Active}
                  AND {res.Sql} ";
        return new RestrictionResult(finalSql, res.Parameters, res.CteExpressions);
    }

    /// <summary>
    /// Checks whether a single customer matches the restriction
    /// </summary>
    /// <param name="customer">Customer object</param>
    /// <returns>True if customer matches the restriction</returns>
    public override bool Matches(Customer customer)
    {
        // build baseRestriction
        var baseRestriction = BuildBaseRestriction();

        return baseRestriction.Matches(customer);
    }

    /// <summary>
    /// Builds base restriction according to segment settings and initialization data
    /// </summary>
    /// <returns>Base restriction</returns>
    private LogicalRestriction BuildBaseRestriction()
    {
        var baseRestriction = ServiceProvider.GetRequiredService<LogicalRestriction>();
        baseRestriction.Data = Data;
        baseRestriction.Modifier = LogicalModifier.And;
        baseRestriction.SubRestrictions = new List<IRestriction>();

        // if specified, additional consent filters are added to segment definition
        if (Data.RequiredConsentsIds != null)
        {
            var consentGroup = ServiceProvider.GetRequiredService<LogicalRestriction>();
            consentGroup.Data = Data;
            consentGroup.Modifier = Data.CustomerConsentMatchType switch
            {
                CustomerConsentMatchType.All => LogicalModifier.And,
                CustomerConsentMatchType.Any => LogicalModifier.Or,
                _ => LogicalModifier.And
            };
            consentGroup.SubRestrictions = new List<IRestriction>();

            foreach (var consentId in Data.RequiredConsentsIds)
            {
                var consentRestriction = ServiceProvider.GetRequiredService<ConsentRestriction>();
                consentRestriction.ConsentIdentifier = $"consent_{consentId}";
                consentRestriction.Modifier = ConsentModifier.IsGiven;
                consentRestriction.ConsentIds = ConsentIds;
                consentGroup.SubRestrictions.Add(consentRestriction);
            }

            baseRestriction.SubRestrictions.Add(consentGroup);
        }

        // if email is required, additional filter is added to segment definition
        if (Data.IsEmailRequired)
        {
            var emailRestriction = ServiceProvider.GetRequiredService<EmailRestriction>();
            emailRestriction.Data = Data;
            emailRestriction.Name = "Email";
            emailRestriction.Modifier = EmailModifier.IsNotEmpty;
            baseRestriction.SubRestrictions.Add(emailRestriction);
        }

        // if phone is required, additional filter is added to segment definition
        if (Data.IsPhoneRequired)
        {
            var phoneRestriction = ServiceProvider.GetRequiredService<PhoneRestriction>();
            phoneRestriction.Data = Data;
            phoneRestriction.Name = "Phone";
            phoneRestriction.Modifier = PhoneModifier.IsNotEmpty;
            baseRestriction.SubRestrictions.Add(phoneRestriction);
        }

        // if Web Push is required, additional filter is added to segment definition
        if (Data.IsWebPushRequired)
        {
            var webPushRestriction = ServiceProvider.GetRequiredService<WebPushRestriction>();
            webPushRestriction.Data = Data;
            webPushRestriction.Modifier = WebPushModifier.IsSubscribed;
            webPushRestriction.WebsiteId = Data.WebsiteId;
            baseRestriction.SubRestrictions.Add(webPushRestriction);
        }

        // if Mobile is required, additional filter is added to segment definition
        if (Data.IsMobileRequired)
        {
            var mobileRestriction = ServiceProvider.GetRequiredService<MobileRestriction>();
            mobileRestriction.Data = Data;
            mobileRestriction.Modifier = MobileModifier.HasMobileDevices;
            mobileRestriction.MobileApplicationId = Data.MobileApplicationId;
            baseRestriction.SubRestrictions.Add(mobileRestriction);
        }

        // add main restriction
        var mainRestriction = ServiceProvider.GetRequiredService<LogicalRestriction>();
        mainRestriction.Data = Data;
        mainRestriction.Modifier = Modifier;
        mainRestriction.SubRestrictions = SubRestrictions;
        baseRestriction.SubRestrictions.Add(mainRestriction);

        return baseRestriction;
    }

    ///// <summary>
    ///// Returns JSON object representing the restriction
    ///// </summary>
    ///// <returns>JSON object</returns>
    //public new JObject ToJson() => MasterRestrictionSerializer.ToJson(this);
}