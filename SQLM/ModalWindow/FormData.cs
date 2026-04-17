using System.Data;
using System.Text.RegularExpressions;
using SQLM.Klasy;

namespace SQLM.ModalWindow
{
    public partial class FormData : Form
    {
        TableInfo tableInfo;
        DataTable dtOrg;
        ContextMenuStrip ctxMenu = new ContextMenuStrip();
        int clickedColumnIndex = -1;
        int clickedRowIndex = -1;

        private List<string> GetTablesFromQuery(string query)
        {
            var tables = new List<string>();

            var matches = Regex.Matches(query,
                @"\b(FROM|JOIN)\s+([\[\]\w\.]+)",
                RegexOptions.IgnoreCase);

            foreach (Match match in matches)
            {
                string table = match.Groups[2].Value;
                tables.Add(table);
            }

            return tables.Distinct().ToList();
        }

        public FormData(TableInfo t)
        {
            InitializeComponent();
            dgDane.CellMouseDown += dgDane_CellMouseDown;

            ctxMenu.Items.Add("Filtruj = wartość", null, FilterEquals_Click);
            ctxMenu.Items.Add("Filtruj zawiera", null, FilterContains_Click);
            ctxMenu.Items.Add("Usuń filtr", null, ClearFilter_Click);
            ctxMenu.Items.Add("Konsument", null, Customer_Click);
            ctxMenu.Items.Add("Pokaż wiersz", null, btnRowShow_Click);

            dgDane.ContextMenuStrip = ctxMenu;
            tableInfo = t;
            dgDane.SetStyleSchowek();

            if (t.QueryText.Length > 0)
            {
                dtOrg = classData.FillData(t.QueryText, t.POL, "wynik");
                rtQuery.Text = t.QueryText;
                List<string> tabela = GetTablesFromQuery(t.QueryText);
                if (tabela.Count == 1)
                {
                    string[] pow = tabela.First().Split(".");
                    string schema = pow.Length == 2 ? pow[0].Trim('[', ']') : "dbo";
                    string table = pow.Length == 2 ? pow[1].Trim('[', ']') : pow[0].Trim('[', ']');
                    dgKolumn.SetStyle();
                    dgKolumn.DataSource = GlobalData.GetColumns(table);
                }
                if (dtOrg != null)
                    this.Text = "Liczba wiersz :" + dtOrg.Rows.Count + "   " + t.ToString();
                dgDane.DataSource = dtOrg;
                classLog.LogInfo(this.Text);
            }
            else
            {
                tabControl1.SelectedIndex = 1;
            }
        }

        private string ShowInputDialog(string title, string defaultValue)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                Text = title,
                StartPosition = FormStartPosition.CenterParent
            };

            Label textLabel = new Label() { Left = 10, Top = 10, Text = title, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 10, Top = 40, Width = 360 };
            textBox.Text = defaultValue;

            Button confirmation = new Button() { Text = "OK", Left = 210, Width = 75, Top = 70, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Anuluj", Left = 295, Width = 75, Top = 70, DialogResult = DialogResult.Cancel };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);

            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }

        private void dgDane_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.Button == MouseButtons.Right)
            {
                clickedColumnIndex = e.ColumnIndex;
                clickedRowIndex = e.RowIndex;

                dgDane.CurrentCell = dgDane[e.ColumnIndex, e.RowIndex];
            }
        }

        private void Customer_Click(object? sender, EventArgs e)
        {
            if (clickedRowIndex < 0 || clickedColumnIndex < 0 || dtOrg == null)
                return;

            string columnName = dgDane.Columns[clickedColumnIndex].DataPropertyName;
            object value = dgDane.Rows[clickedRowIndex].Cells[clickedColumnIndex].Value;
            var viewer = new FormDataOne($"select * from Customer.Customer where id={value}");
            viewer.ShowDialog();
        }

        private void FilterEquals_Click(object sender, EventArgs e)
        {
            if (clickedRowIndex < 0 || clickedColumnIndex < 0 || dtOrg == null)
                return;

            string columnName = dgDane.Columns[clickedColumnIndex].DataPropertyName;
            object value = dgDane.Rows[clickedRowIndex].Cells[clickedColumnIndex].Value;

            DataColumn col = dtOrg.Columns[columnName];
            dtOrg.DefaultView.RowFilter = BuildFilter(col, value);
            txtFilter.Text = dtOrg.DefaultView.RowFilter;

            this.Text = $"Filtr: {columnName} = {value}";
        }

        private void FilterContains_Click(object sender, EventArgs e)
        {
            if (clickedRowIndex < 0 || clickedColumnIndex < 0 || dtOrg == null)
                return;

            string columnName = dgDane.Columns[clickedColumnIndex].DataPropertyName;
            object value = dgDane.Rows[clickedRowIndex].Cells[clickedColumnIndex].Value;

            DataColumn col = dtOrg.Columns[columnName];

            if (col.DataType != typeof(string))
            {
                MessageBox.Show("Filtr 'zawiera' działa tylko dla tekstu.");
                return;
            }

            string defaultValue = value?.ToString() ?? "";

            string input = ShowInputDialog("Podaj tekst do filtrowania (LIKE %tekst%)", defaultValue);

            if (string.IsNullOrWhiteSpace(input))
                return;

            input = input.Replace("'", "''");

            dtOrg.DefaultView.RowFilter = $"[{columnName}] LIKE '%{input}%'";
            this.Text = $"Filtr: {columnName} LIKE '%{input}%'";
        }

        private void ClearFilter_Click(object sender, EventArgs e)
        {
            ClearFiltr();
        }

        private void ClearFiltr()
        {
            if (dtOrg == null)
                return;

            dtOrg.DefaultView.RowFilter = "";
            txtFilter.Text = "";
            this.Text = "Filtr usunięty";
        }

        private string BuildFilter(DataColumn col, object value)
        {
            if (value == null || value == DBNull.Value)
                return $"[{col.ColumnName}] IS NULL";

            Type type = col.DataType;

            if (type == typeof(string))
            {
                string val = value.ToString().Replace("'", "''");
                return $"[{col.ColumnName}] = '{val}'";
            }
            else if (type == typeof(DateTime))
            {
                DateTime dt = (DateTime)value;
                return $"[{col.ColumnName}] = #{dt:MM/dd/yyyy HH:mm:ss}#";
            }
            else if (type == typeof(bool))
            {
                return $"[{col.ColumnName}] = {value.ToString().ToLower()}";
            }
            else if (type == typeof(decimal))
            {
                string val = Convert.ToDecimal(value)
                    .ToString(System.Globalization.CultureInfo.InvariantCulture);

                return $"[{col.ColumnName}] = {val}";
            }
            else // liczby
            {
                return $"[{col.ColumnName}] = {value}";
            }
        }

        private void btnRunSQL_Click(object sender, EventArgs e)
        {
            dtOrg = classData.FillData(rtQuery.Text, tableInfo.POL, "wynik");

            if (dtOrg != null)
                this.Text = "Liczba wiersz :" + dtOrg.Rows.Count + " " + tableInfo.serverName + " zapytanie";
            dgDane.DataSource = dtOrg;
            tabControl1.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            classFun.ConfirmAndExit();
        }

        private void btnRowShow_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgDane.CurrentRow;

            if (row == null)
            {
                MessageBox.Show("Kliknij najpierw komórkę w wierszu.");
                return;
            }

            var rowData = new Dictionary<string, object>();

            foreach (DataGridViewCell cell in row.Cells)
            {
                string columnName = dgDane.Columns[cell.ColumnIndex].HeaderText;
                rowData[columnName] = cell.Value ?? DBNull.Value;
            }

            var pivot = new PivotWindow(rowData);
            pivot.Show();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var value = dgDane.CellValue();
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

        private void btnFiltr_Click(object sender, EventArgs e)
        {
            dtOrg.DefaultView.RowFilter = txtFilter.Text;
        }

        private void btnClearFiltr_Click(object sender, EventArgs e)
        {
            ClearFiltr();
        }
    }
}