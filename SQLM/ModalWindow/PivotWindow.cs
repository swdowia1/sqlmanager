using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using SQLM.Klasy;
using SQLM.VM;

namespace SQLM.ModalWindow
{
    public partial class PivotWindow : Form
    {
        public PivotWindow(Dictionary<string, object> rowData)
        {
            InitializeComponent();
            dgPivot.SetStyle();
            List<PivotModel> dane = new List<PivotModel>();

            int pos = 1;
            foreach (var kvp in rowData)
            {
                string kolumna = kvp.Key;
                object wartosc = kvp.Value;

                string sformatowanaWartosc = FormatujWartosc(wartosc);
                dane.Add(new PivotModel() { LP = pos, Kolumna = kolumna, Wartosc = wartosc.ToString() });
                pos++;
            }

            dgPivot.DataSource = dane;
        }

        private string FormatujWartosc(object wartosc)
        {
            if (wartosc == null || wartosc == DBNull.Value)
                return "pusta";

            switch (wartosc)
            {
                case string s:
                    return s;

                case DateTime dt:
                    return dt.ToString("yyyy-MM-dd HH:mm:ss");

                case bool b:
                    return b ? "Tak" : "Nie";

                case byte[] bytes:
                    return $"Dane binarne ({bytes.Length} bajtów)";

                case decimal d:
                    return d.ToString("N2", CultureInfo.InvariantCulture);

                case double dbl:
                    return dbl.ToString("N2", CultureInfo.InvariantCulture);

                case float f:
                    return f.ToString("N2", CultureInfo.InvariantCulture);

                default:
                    try
                    {
                        return wartosc.ToString();
                    }
                    catch
                    {
                        return $"[Nieczytelna wartość typu {wartosc.GetType().Name}]";
                    }
            }
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            classFun.ConfirmAndExit();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var value = dgPivot.CurrentCell.Value?.ToString();
            if (string.IsNullOrWhiteSpace(value))
                return;

            try
            {
                var viewer = new JsonViewerForm(value);
                viewer.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Wybrana komórka nie zawiera poprawnego JSON.");
            }
        }

        private void dgPivot_Click(object sender, EventArgs e)
        {
            var row = dgPivot.CurrentRow<PivotModel>();
            string formatted = FormatJson(row.Wartosc);
            rtbJson.Text = formatted;

            ColorizeJson();
        }
    }
}