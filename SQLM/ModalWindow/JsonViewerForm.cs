using System.Text.Json;
using System.Text.RegularExpressions;

namespace SQLM.ModalWindow
{
    public partial class JsonViewerForm : Form
    {
        public JsonViewerForm(string json)
        {
            InitializeComponent();

            this.Text = "JSON Viewer";
            this.BackColor = Color.FromArgb(30, 30, 30);

            string formatted = FormatJson(json);
            rtbJson.Text = formatted;

            ColorizeJson();
        }

        private string FormatJson(string json)
        {
            try
            {
                using var doc = JsonDocument.Parse(json);
                return JsonSerializer.Serialize(doc, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            }
            catch
            {
                return json;
            }
        }

        private void ColorizeJson()
        {
            rtbJson.SelectAll();
            rtbJson.SelectionColor = Color.Gainsboro;

            string text = rtbJson.Text;

            // Klucze
            foreach (Match m in Regex.Matches(text, "\".*?\"(?=\\s*:)"))
            {
                rtbJson.Select(m.Index, m.Length);
                rtbJson.SelectionColor = Color.FromArgb(86, 156, 214); // niebieski
            }

            // String values
            foreach (Match m in Regex.Matches(text, ":\\s*\".*?\""))
            {
                int start = m.Index + m.Value.IndexOf("\"");
                int length = m.Value.Length - m.Value.IndexOf("\"");
                rtbJson.Select(start, length);
                rtbJson.SelectionColor = Color.FromArgb(214, 157, 133); // pomarańczowy
            }

            // Liczby
            foreach (Match m in Regex.Matches(text, @"\b\d+(\.\d+)?\b"))
            {
                rtbJson.Select(m.Index, m.Length);
                rtbJson.SelectionColor = Color.FromArgb(181, 206, 168); // zielony
            }

            // true / false / null
            foreach (Match m in Regex.Matches(text, @"\b(true|false|null)\b"))
            {
                rtbJson.Select(m.Index, m.Length);
                rtbJson.SelectionColor = Color.FromArgb(197, 134, 192); // fiolet
            }

            rtbJson.Select(0, 0);
        }
    }
}