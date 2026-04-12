using System.Data;

namespace SQLM.VM;

public class ApiKeyVM : DataRowModel
{
    /*select k.UnitId,k.[Key],u.Name from unit.UnitApiKey k
           join Unit.Unit u on k.UnitId=u.Id*/
    public int UnitId { get; private set; }
    public string Key { get; private set; }
    public string Name { get; private set; }

    public ApiKeyVM(DataRow row) : base(row)
    {
    }

    protected override void LoadFromRow(DataRow row)
    {
        UnitId = Get<int>("UnitId");
        Key = Get<string>("Key");
        Name = Get<string>("Name");
    }
}