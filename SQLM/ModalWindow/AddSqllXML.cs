using SQLM.Klasy;

namespace SQLM.ModalWindow
{
    public partial class AddSqllXML : Form
    {
        private string _serverName;
        private string _databaseName;
        private string pol;

        public AddSqllXML(string serverName, string databaseName)
        {
            InitializeComponent();
            lblDescribe.Text = "";
            _serverName = serverName;
            _databaseName = databaseName;
            pol = classFun.PolDataBase(_serverName, _databaseName);
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            lblDescribe.Text = "";
            string par = txtParametr.Text;
            string sql = string.Format(rtSQL.Text, par);
            var ff = classData.FillData(sql, pol);
            if (ff == null)
            {
                classMessage.ShowError("Nie poprawne zapytanie polo " + pol);
                return;
            }

            lblDescribe.Text = $"Tabela zawiera {ff.Rows.Count} wierszy i {ff.Columns.Count} kolumny ";
        }
    }
}