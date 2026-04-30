using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using SQLM.VM;

namespace SQLM.Klasy
{
    internal class classFun
    {
        public static List<T> ConvertToList<T>(DataTable table) where T : DataRowModel
        {
            var list = new List<T>();

            if (table == null)
                throw new ArgumentNullException(nameof(table));

            foreach (DataRow row in table.Rows)
            {
                // Znajdź konstruktor, który przyjmuje DataRow
                ConstructorInfo constructor = typeof(T).GetConstructor(new[] { typeof(DataRow) });
                if (constructor == null)
                    throw new InvalidOperationException($"Typ {typeof(T).Name} nie ma konstruktora z parametrem DataRow.");

                // Utwórz instancję
                var instance = (T)constructor.Invoke(new object[] { row });
                list.Add(instance);
            }

            return list;
        }

        public static void AddTableMemory(string we, DataGridView dg)
        {
            List<string> lista = classMemory.MemoryReadList(ConfigSave.QueryList);
            lista.Remove(we);
            lista.Add(we);
            if (lista.Count > 10)
            {
                lista.RemoveAt(0);
            }
            classMemory.MemoryWriteList(ConfigSave.QueryList, lista);
            lista.Reverse();
            dg.DataSource = lista.Select(x => new StringValue(x)).ToList();
        }

        public static void FavoriteAdd(string zaw)
        {
            List<string> lista = classMemory.MemoryReadList(ConfigSave.Favorite);
            lista.Remove(zaw);
            lista.Add(zaw);
            if (lista.Count > 5)
                lista.RemoveAt(0);
            classMemory.MemoryWriteList(ConfigSave.Favorite, lista);
        }

        public static void ConfirmAndExit()
        {
            if (classMessage.Question("Na pewno chcesz zamknąć aplikację"))
                Application.Exit();
        }

        public static string PolServer(string name)
        {
            return "Data Source=" + name + ";Integrated Security=SSPI;Encrypt=false";
        }

        public static string PolDataBase(string serverName, string dataBaseName)
        {
            return "Data Source=" + serverName + ";Initial Catalog=" + dataBaseName + ";Integrated Security=SSPI;Encrypt=false";
        }

        internal static List<TableInfo> Tabele(string serverName, string dataBaseName)
        {
            string pol = PolDataBase(serverName, dataBaseName);
            List<TableInfo> wynik = new List<TableInfo>();
            try
            {
                //SCHEMA_NAME(A.schema_id) + '.' +
                string zap = @"SELECT       
    SCHEMA_NAME(A.schema_id) as schemat,A.Name AS Tabela, 
    AVG(B.rows) AS Ilosc, 
    COUNT(DISTINCT C.column_id) AS LiczbaKolumn
FROM sys.objects A
INNER JOIN sys.partitions B ON A.object_id = B.object_id
LEFT JOIN sys.columns C ON A.object_id = C.object_id
WHERE A.type = 'U'
GROUP BY A.schema_id, A.Name, A.object_id
ORDER BY 1,2";
                DataTable dt = classData.FillData(zap, pol, "lista tabel w bazie");

                if (dt != null)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        string tabela = item["Tabela"].ToString();
                        string schema = item["schemat"].ToString();
                        TableInfo q = new TableInfo()
                        {
                            POL = pol,
                            QueryText = "select top 1000 * from [" + schema + "].[" + tabela + "] order by 1 desc",
                            nazwa = tabela,
                            serverName = serverName,
                            databaseName = dataBaseName,
                            schemat = schema,
                            ilosc = int.Parse(item["Ilosc"].ToString()),
                            LiczbaKolumn = int.Parse(item["LiczbaKolumn"].ToString()),
                        };
                        wynik.Add(q);
                    }
                }
            }
            catch (Exception ee)
            {
                classLog.LogError(ee, "classFun.Tabele");
                throw ee; // Rzucenie wyjątku dalej, aby można było go obsłużyć w wywołującym kodzie
            }

            return wynik.OrderBy(k => k.schemat).ThenBy(j => j.nazwa).ToList();
        }

        public static List<string> DtToList(DataTable dt, string kolName)
        {
            return dt.AsEnumerable()
                .Select(row => row.Field<string>(kolName))
                .ToList();
        }

        public static HistoryQuery2 GetQueryAll(string path)
        {
            HistoryQuery2 q = new HistoryQuery2();
            q.Query = new List<Query2>();

            XmlSerializer serializer = new XmlSerializer(typeof(HistoryQuery2));
            using (StreamReader reader = new StreamReader(path))
            {
                q = (HistoryQuery2)serializer.Deserialize(reader);
            }

            return q;
        }

        public static List<QueryListSaveData> GetListQuerySave()
        {
            List<QueryListSaveData> result = new List<QueryListSaveData>();
            string[] pliki = Directory.GetFiles(classConsst.KatalogXML);
            foreach (var plik in pliki)
            {
                QueryListSaveData d = new QueryListSaveData();
                d.filename = plik;
                HistoryQuery2 hist = GetQueryAll(plik);
                d.title = hist.Title;
                d.question = hist.Question;
                d.historyQuery2 = hist;
                d.ilosc = hist.Query.Count;
                result.Add(d);
            }

            return result;
        }

        public static void SaveDataTableToCsv(DataTable table)
        {
            if (table == null)
                throw new ArgumentNullException(nameof(table));

            if (string.IsNullOrWhiteSpace(table.TableName))
                throw new Exception("DataTable.TableName is empty.");

            string filePath = $"{table.TableName}.csv";

            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                // nagłówki
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    writer.Write(table.Columns[i].ColumnName);

                    if (i < table.Columns.Count - 1)
                        writer.Write(";");
                }

                writer.WriteLine();

                // dane
                foreach (DataRow row in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        var value = row[i]?.ToString()?.Replace(";", " "); // zabezpieczenie separatora
                        writer.Write(value);

                        if (i < table.Columns.Count - 1)
                            writer.Write(";");
                    }

                    writer.WriteLine();
                }
            }
        }

        internal static void DataTableToFile(DataTable dane)
        {
            string filePath = @"dane.txt";

            // Tworzymy lub nadpisujemy plik
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"=============== {DateTime.Now.ToLongTimeString()}===============");
                foreach (DataColumn col in dane.Columns)
                {
                    // Nagłówek kolumny
                    writer.WriteLine(col.ColumnName);

                    // Wszystkie wartości w tej kolumnie
                    foreach (DataRow row in dane.Rows)
                    {
                        writer.WriteLine(row[col]?.ToString() ?? "");
                    }

                    // Opcjonalnie pusty wiersz między kolumnami
                    writer.WriteLine();
                }
            }
        }

        internal static void OPenInNotePad(string queryTextFileSQL)
        {
            Process.Start("C:\\Program Files\\Notepad++\\notepad++.exe", classConsst.QueryTextFileSQL);
        }
    }
}