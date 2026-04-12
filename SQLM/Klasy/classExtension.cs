using System.Data;

namespace SQLM.Klasy
{
    public static class classExtension
    {
        public static string CellValue(this DataGridView dg)
        {
            return dg.CurrentCell.Value?.ToString();
        }

        public static void SetStyle(this TreeView tv)
        {
            tv.BorderStyle = BorderStyle.None;
            tv.HideSelection = false;

            tv.Font = new Font("Segoe UI", 10F);
            tv.BackColor = Color.FromArgb(248, 248, 248); // jasne tło
            tv.ForeColor = Color.FromArgb(60, 60, 60); // ciemnoszary tekst

            // Kolor zaznaczenia (systemowy override)
            tv.LineColor = Color.FromArgb(200, 200, 200);
        }

        public static void SetStyle(this DataGridView dg, bool autoGenerate = true)
        {
            dg.AutoGenerateColumns = autoGenerate;
            dg.AllowUserToAddRows = false;
            dg.AllowUserToDeleteRows = false;
            dg.ReadOnly = true;

            dg.BorderStyle = BorderStyle.None;
            dg.EnableHeadersVisualStyles = false;
            dg.RowHeadersVisible = false;

            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // TŁO
            dg.BackgroundColor = Color.FromArgb(245, 245, 245);
            dg.GridColor = Color.FromArgb(220, 220, 220);

            dg.DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            dg.DefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
            dg.DefaultCellStyle.Font = new Font("Segoe UI", 10F);

            dg.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            // Nagłówki
            dg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 225, 215);
            dg.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(90, 60, 40);
            dg.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Selekcja – brązowy akcent
            dg.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 180, 140);
            dg.DefaultCellStyle.SelectionForeColor = Color.Black;

            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public static void SetStyleSchowek(this DataGridView dg, bool autoGenerate = true)
        {
            dg.AutoGenerateColumns = autoGenerate;
            dg.AllowUserToAddRows = false;
            dg.AllowUserToDeleteRows = false;
            dg.ReadOnly = true;

            dg.BorderStyle = BorderStyle.None;
            dg.EnableHeadersVisualStyles = false;
            dg.RowHeadersVisible = false;

            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dg.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // 🌫 TŁO
            dg.BackgroundColor = Color.FromArgb(245, 245, 245);
            dg.GridColor = Color.FromArgb(220, 220, 220);

            dg.DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            dg.DefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
            dg.DefaultCellStyle.Font = new Font("Segoe UI", 10F);

            dg.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            // 🏷 Nagłówki
            dg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 225, 215);
            dg.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(90, 60, 40);
            dg.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // ☕ Selekcja – brąz
            dg.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 180, 140);
            dg.DefaultCellStyle.SelectionForeColor = Color.Black;

            // ✨ Delikatny hover
            dg.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0)
                    dg.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            };

            dg.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex >= 0)
                    dg.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                        e.RowIndex % 2 == 0
                            ? Color.FromArgb(250, 250, 250)
                            : Color.FromArgb(240, 240, 240);
            };

            // 📋 Podwójne kliknięcie = kopiuj
            dg.CellDoubleClick += (sender, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                var value = dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (string.IsNullOrWhiteSpace(value))
                    return;

                Clipboard.SetText(value);

                Form parentForm = dg.FindForm();
                if (parentForm != null)
                {
                    parentForm.Text = "Skopiowano do schowka: " + value;
                }
            };
        }

        public static void SetStyleWitchoutZebra(this DataGridView dg)
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dg.AutoGenerateColumns = true;
            dg.AllowUserToAddRows = false;
            dg.AllowUserToDeleteRows = false;
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 230);

            dg.ReadOnly = true;
        }

        public static T CurrentRow<T>(this DataGridView dg)
        {
            object item = dg.CurrentRow?.DataBoundItem;

            if (item is T)
                return (T)item;

            // Gdy np. string, a chcemy tylko T == string
            if (typeof(T) == typeof(string) && item != null)
                return (T)(object)item.ToString();

            return default(T);
        }

        public static string CurrentRowString(this DataGridView dg)
        {
            if (dg.CurrentRow == null)
                return null;

            var item = dg.CurrentRow.DataBoundItem;

            // 1. Jeśli DataBoundItem to string
            if (item is string s)
                return s;

            // 2. Jeśli DataTable (DataRowView)
            if (item is DataRowView drv)
            {
                var val = drv.Row.ItemArray.Length > 0 ? drv.Row[0] : null;
                return val?.ToString();
            }

            // 3. Fallback – pierwsza komórka
            var cellValue = dg.CurrentRow.Cells.Count > 0
                ? dg.CurrentRow.Cells[0].Value
                : null;

            return cellValue?.ToString();
        }
    }
}