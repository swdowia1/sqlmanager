using System.Data;
using System.Data.SqlClient;

namespace SQLM.Klasy
{
    internal class classData
    {
        public static DataTable FillData(string sqlText, string pol, string infoLogo = "", bool pivot = true)
        {
            if (infoLogo != "")
                classLog.LogInfo("\n\n====================      pytamy o " + infoLogo + "        ==========\n" + sqlText);

            try
            {
                using SqlConnection con = new (pol);
                using SqlCommand cmd = new SqlCommand(sqlText, con);
                using SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                cmd.CommandType = sqlText.Contains("select", StringComparison.CurrentCultureIgnoreCase) ? CommandType.Text : CommandType.StoredProcedure;

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                var dane = dataSet.Tables[0];

                if (dane.Rows.Count > 1 || pivot == false)

                    return dane;

                if (dane.Rows.Count == 1)
                {
                    DataTable MyTable = new DataTable();
                    MyTable.Columns.Add("Id", typeof(int));
                    MyTable.Columns.Add("Kolumna", typeof(string));
                    MyTable.Columns.Add("Wartosc", typeof(string));

                    for (int i = 0; i < dane.Columns.Count; i++)
                    {
                        MyTable.Rows.Add(i + 1, dane.Columns[i].ColumnName, dane.Rows[0][i].ToString());
                    }

                    MyTable.Rows.Add(999, "jeden", "wiersz");
                    return MyTable;
                }

                return null;
            }
            catch (Exception ee)
            {
                classLog.LogError(ee, "classFun.SyberiaZapytanie");

                return null;
            }
        }
    }
}