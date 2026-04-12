using System.Data;
using System.Globalization;
using SQLM.Klasy;

namespace SQLM.ModalWindow
{
    public partial class PivotWindow : Form
    {
        public PivotWindow(Dictionary<string, object> rowData)
        {
            InitializeComponent();
            dgPivot.SetStyle();
            DataTable pivot = new DataTable();
            pivot.Columns.Add("LP");
            pivot.Columns.Add("Kolumna");
            pivot.Columns.Add("Wartość");
            int pos = 1;
            foreach (var kvp in rowData)
            {
                string kolumna = kvp.Key;
                object wartosc = kvp.Value;

                string sformatowanaWartosc = FormatujWartosc(wartosc);
                pivot.Rows.Add($"{pos}", kolumna, sformatowanaWartosc);
                pos++;
            }

            dgPivot.DataSource = pivot;
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
    }
}