using SQLM.Klasy;

namespace SQLM.ModalWindow
{
    public partial class QueryResultControl : UserControl
    {
        private string _pol = "";

        public QueryResultControl(Query2 query, string pol)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            _pol = pol;
            LoadData(query);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // jeśli chcesz, możesz dodać ustawienia kontrolki tutaj
            this.ResumeLayout(false);
        }

        private void LoadData(Query2 query)
        {
            // Panel kontenerowy (dla czytelności i marginesów)
            Panel panel = new Panel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(5),
                Margin = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Nagłówek z tytułem zapytania
            Label lblTitle = new Label
            {
                Text = query.Title,
                Dock = DockStyle.Top,
                Height = 28,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(Font.FontFamily, 9, FontStyle.Bold),
                BackColor = Color.Gainsboro,
                ForeColor = Color.Black
            };

            // Grid z danymi
            DataGridView grid = new DataGridView
            {
                Dock = DockStyle.Top, // zamiast Fill!
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                Height = 250 // stała wysokość, żeby było widać dane
            };

            // Wczytaj dane
            var dt = classData.FillData(query.Text, _pol, "wynik", false);
            grid.SetStyle();
            grid.DataSource = dt;

            // Dodaj w odpowiedniej kolejności
            panel.Controls.Add(grid);
            panel.Controls.Add(lblTitle);

            // Dodaj panel do kontrolki
            Controls.Add(panel);
        }
    }
}