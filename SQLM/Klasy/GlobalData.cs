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
            string sql = @"
SELECT 
    TABLE_SCHEMA,
    TABLE_NAME,
    COLUMN_NAME,
    DATA_TYPE,
    CHARACTER_MAXIMUM_LENGTH
FROM INFORMATION_SCHEMA.COLUMNS
ORDER BY TABLE_SCHEMA, TABLE_NAME, ORDINAL_POSITION";
            Kolumny = classData.FillData(sql, Pol);
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