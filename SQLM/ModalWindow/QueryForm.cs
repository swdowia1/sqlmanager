using SQLM.Klasy;

namespace SQLM.ModalWindow
{
    public partial class QueryForm : Form
    {
        private string _query;
        private string _pol;

        public QueryForm(string query, string pol, string parametr = "")
        {
            InitializeComponent();
            _query = query;
            _pol = pol;
            dataGridView1.SetStyle();
            dataGridView1.DataSource = classData.FillData(string.Format(_query, parametr), _pol, "", false);
        }
    }
}