namespace SQLM.Klasy
{
    [Serializable]
    public class Query
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Question { get; set; }

        /// <summary>
        /// Data w formacie yyyyMMddHHss
        /// </summary>
        public string Data { get; set; }

        public Query()
        {
        }

        public Query(string title, string text)
        {
            Text = text;
            Title = title;
            Data = DateTime.Now.ToString(classConsst.FormatDataTime);
        }
    }
}