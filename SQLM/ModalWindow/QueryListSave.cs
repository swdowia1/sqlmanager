using SQLM.Klasy;

namespace SQLM.ModalWindow
{
    public partial class QueryListSave : Form
    {
        private string _serverName;
        private string _databaseName;

        public QueryListSave(string serverName, string databaseName)
        {
            InitializeComponent();
            dgFile.SetStyle();
            dgFile.DataSource = classFun.GetListQuerySave();
            this._serverName = serverName;
            this._databaseName = databaseName;
        }

        private void dgFile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var SelectedRow = dgFile.CurrentRow<QueryListSaveData>();

            using (QueryListForm form = new QueryListForm(SelectedRow.historyQuery2, classFun.PolDataBase(_serverName, _databaseName)))
            {
                form.ShowDialog(this);
            }
        }
    }
}