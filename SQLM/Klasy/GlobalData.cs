using System.Data;
using SQLM.VM;

namespace SQLM.Klasy
{
    public static class GlobalData
    {
        public static string ServerName;
        public static string DataBaseName;
        public static string Pol;
        public static DataTable Kolumny { get; set; } = new DataTable();

        public static void SetValue(string ser, string dat)
        {
            ServerName = ser;
            DataBaseName = dat;
            Pol = classFun.PolDataBase(ser, dat);
        }

        public static List<StringValue> GetColumns(string schema, string table)
        {
            return Kolumny.AsEnumerable()
                .Where(r =>
                    r.Field<string>("TABLE_SCHEMA") == schema &&
                    r.Field<string>("TABLE_NAME") == table)
                .Select(r => new StringValue
                {
                    Value = r.Field<string>("COLUMN_NAME")
                })
                .ToList();
        }

        public static List<StringValue> GetColumns(string table)
        {
            return Kolumny.AsEnumerable()
                .Where(r =>
                    r.Field<string>("TABLE_NAME") == table)
                .Select(r => new StringValue
                {
                    Value = r.Field<string>("COLUMN_NAME")
                })
                .ToList();
        }
    }
}