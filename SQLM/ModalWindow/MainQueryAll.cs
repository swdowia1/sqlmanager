using System.Text;
using SQLM.Klasy;

namespace SQLM.ModalWindow
{
    public partial class MainQueryAll : Form
    {
        public HistoryQuery2 _HistoryQuery2 { get; set; }
        private string pol = "";

        public MainQueryAll(HistoryQuery2 _Hist, string server, string database)
        {
            InitializeComponent();
            lblInfo.Text = "";
            _HistoryQuery2 = _Hist;
            pol = classFun.PolDataBase(server, database);
            this.Text = pol;
            lblQuestion.Text = _HistoryQuery2.Question;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblInfo.Text = "";
            // var queries = _HistoryQuery2.Query;
            var queries = new List<Query2>(_HistoryQuery2.Query);


            int rows = queries.Count;


            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();

            // tylko 1 kolumna (pełna szerokość)
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = rows;

            // ustaw styl kolumny — 100% szerokości
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));

            for (int i = 0; i < rows; i++)
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            foreach (var q in queries)
            {
                string temp = q.Text;
                q.Text = string.Format(q.Text, textBox1.Text);

                var ctrl = new QueryResultControl(q, pol)
                {
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Margin = new Padding(5)
                };
                q.Text = temp;
                tableLayoutPanel1.Controls.Add(ctrl, 0, tableLayoutPanel1.Controls.Count);
            }

            tableLayoutPanel1.AutoScroll = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblInfo.Text = "";
            StringBuilder sb = new StringBuilder();

            string eol = Environment.NewLine;
            foreach (var q in _HistoryQuery2.Query)
            {
                sb.Append("--" + q.Title + eol);
                sb.Append(string.Format(q.Text, textBox1.Text) + eol + eol);
            }

            File.WriteAllText(classConsst.QueryTextFileSQL, sb.ToString());
            Clipboard.SetText(sb.ToString());


            lblInfo.Text = "__ZAPISANO DO SCHOWAKA__";
            classFun.OPenInNotePad(classConsst.QueryTextFileSQL);
        }
    }
}