using System.Data;

namespace SQLM.Klasy
{
    public static class GlobalData
    {
        public static string ServerName { get; set; }
        public static string DataBaseName { get; set; }
        public static DataTable Kolumny { get; set; } = new DataTable();

        public static List<string> GetColumns(DataTable dt, string schema, string table)
        {
            return dt.AsEnumerable()
                .Where(r =>
                    r.Field<string>("TABLE_SCHEMA") == schema &&
                    r.Field<string>("TABLE_NAME") == table)
                .Select(r => r.Field<string>("COLUMN_NAME"))
                .ToList();
        }

        public static List<string> GetColumns(DataTable dt, string table)
        {
            return dt.AsEnumerable()
                .Where(r =>
                    r.Field<string>("TABLE_NAME") == table)
                .Select(r => r.Field<string>("COLUMN_NAME"))
                .ToList();
        }
    }
}