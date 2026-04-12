namespace SQLM.Klasy
{
    public class TableInfo
    {
        public TableInfo(string serverName, string databaseName)
        {
            this.serverName = serverName;
            this.databaseName = databaseName;
            this.QueryText = "";
            this.POL = classFun.PolDataBase(serverName, databaseName);
        }

        public TableInfo()
        {
        }

        public string schemat { get; set; }
        public string nazwa { get; set; }
        public string Question { get; set; }

        public int ilosc { get; set; }

        public int LiczbaKolumn { get; internal set; }
        public string POL { get; internal set; }

        public string serverName { get; set; }
        public string databaseName { get; set; }
        public string QueryText { get; internal set; }

        public bool IsQuestion
        {
            get { return !string.IsNullOrEmpty(Question); }
        }

        public override string ToString()
        {
            return $"{schemat} {nazwa}/{serverName}:{databaseName}";
        }
    }
}