using System.Data;
using System.Diagnostics;
using SQLM.Klasy;
using SQLM.ModalWindow;
using SQLM.VM;

namespace SQLM
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> serwery;
        List<TableInfo> listaTabelaOrginal;

        private BindingSource bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();

            tvServer.HideSelection = false;
            classLog.LogInfo("start");
            serwery = new Dictionary<string, string>();
            dgTable.SetStyle(false);
            dgTableLast.SetStyle();
            List<string> lastTable = classMemory.MemoryReadList(ConfigSave.QueryList);
            lastTable.Reverse();
            dgTableLast.DataSource = lastTable.Select(x => new StringValue(x)).ToList();
            dgLastServer.SetStyle();

            List<string> serwerplik = classMemory.MemoryReadList(ConfigSave.Servery);
            List<string> favorite = classMemory.MemoryReadList(ConfigSave.Favorite);
            favorite.Reverse();
            List<ServerDatabase> result = favorite
                .Select(x =>
                {
                    var parts = x.Split('/');

                    return new ServerDatabase
                    {
                        ServerName = parts.Length > 0 ? parts[0] : null,
                        DataBaseName = parts.Length > 1 ? parts[1] : null
                    };
                })
                .ToList();
            dgLastServer.DataSource = result;
            if (result.Count > 0)
                GlobalData.SetValue(result[0].ServerName, result[0].DataBaseName);
            int k = 0;
            foreach (string field in serwerplik)
            {
                TreeNode t = new TreeNode(field);
                string pol = classFun.PolServer(field);
                DataTable dd = classData.FillData(@"SELECT name 
FROM sys.databases
ORDER BY name", pol, "lista baza");
                List<string> bazu = classFun.DtToList(dd, "name");
                foreach (var item in bazu)
                {
                    t.Nodes.Add(item);
                }

                tvServer.Nodes.Add(t);

                serwery.Add(k.ToString(), field);
                k++;
                tvServer.SetStyle();
            }

            string zaw = classMemory.MemoryRead(ConfigSave.Server);
            var parts = zaw.Split('/');
            if (parts.Length == 2)
            {
                string serverName = parts[0];
                string databaseName = parts[1];
                foreach (TreeNode serverNode in tvServer.Nodes)
                {
                    if (serverNode.Text == serverName)
                    {
                        serverNode.Expand();

                        foreach (TreeNode dbNode in serverNode.Nodes)
                        {
                            if (dbNode.Text == databaseName)
                            {
                                tvServer.SelectedNode = dbNode;

                                ListaTabelBaza(serverName, databaseName);
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void ListaTabelBaza(string serverName, string databaseName)
        {
            listaTabelaOrginal = classFun.Tabele(serverName, databaseName);

            bindingSource.DataSource = listaTabelaOrginal;
            dgTable.DataSource = bindingSource;
            this.Text = $"server {serverName} baza: {databaseName}";
        }

        private void tvServer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Select the clicked node
            tvServer.SelectedNode = e.Node;
            if (e.Node.Nodes.Count == 0)
            {
                GlobalData.SetValue(e.Node.Parent.Text, e.Node.Text);
                ListaTabelBaza(GlobalData.ServerName, GlobalData.DataBaseName);
                classMemory.MemoryWrite(ConfigSave.Server, $"{GlobalData.ServerName}/{GlobalData.DataBaseName}");
                classFun.FavoriteAdd($"{GlobalData.ServerName}/{GlobalData.DataBaseName}");
                this.Text = $"server {GlobalData.ServerName} baza: {GlobalData.DataBaseName}";

                TableInfo SelectedRow = new TableInfo(GlobalData.ServerName, GlobalData.DataBaseName);
            }
        }

        private void dgTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var SelectedRow = dgTable.CurrentRow<TableInfo>();
            if (e.ColumnIndex == dgTable.Columns["def"].Index && e.RowIndex >= 0) // SprawdŸ czy klikniêto w kolumnê "Akcje"
            {
                using (DefTable form = new DefTable(SelectedRow))
                {
                    var result = form.ShowDialog(this);
                } //

                return;
            }

            using (FormData form = new FormData(SelectedRow))
            {
                string pom = $"[{SelectedRow.schemat}].[{SelectedRow.nazwa}]";
                classFun.AddTableMemory(pom, dgTableLast);
                classMemory.MemoryWrite(ConfigSave.Table, pom);
                form.ShowDialog(this);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filterText = textBox1.Text.ToLower();

            var filtered = listaTabelaOrginal
                .Where(t => t.nazwa.ToLower().Contains(filterText)) // <-- Dostosuj w³aœciwoœæ
                .ToList();

            bindingSource.DataSource = filtered;
        }

        private void btnSQL_Click(object sender, EventArgs e)
        {
            TableInfo SelectedRow = new TableInfo(GlobalData.ServerName, GlobalData.DataBaseName);

            SelectedRow.nazwa = "";
            SelectedRow.QueryText = "";
            using (FormData form = new FormData(SelectedRow))
            {
                form.ShowDialog(this);
            }
        }

        private void btnSql2_Click(object sender, EventArgs e)
        {
            if (GlobalData.ServerName == null)
            {
                classMessage.ShowError("wybierz baze");
                return;
            }

            using (QueryListSave form = new QueryListSave(GlobalData.ServerName, GlobalData.DataBaseName))
            {
                form.ShowDialog(this);
            }
        }

        private void btnOpenCatalog_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = Environment.CurrentDirectory,
                UseShellExecute = true
            });
        }

        private void btnAddSql_Click(object sender, EventArgs e)
        {
            using (AddSqllXML form = new AddSqllXML(GlobalData.ServerName, GlobalData.DataBaseName))
            {
                form.ShowDialog(this);
            }
        }

        private void btnKolumny_Click(object sender, EventArgs e)
        {
            if (GlobalData.ServerName == null)
            {
                classMessage.ShowError("wybierz baze");
                return;
            }
            TableInfo SelectedRow = new TableInfo(GlobalData.ServerName, GlobalData.DataBaseName);
            string sql = @"
SELECT 
    TABLE_SCHEMA,
    TABLE_NAME,
    COLUMN_NAME,
    DATA_TYPE,
    CHARACTER_MAXIMUM_LENGTH
FROM INFORMATION_SCHEMA.COLUMNS
ORDER BY TABLE_SCHEMA, TABLE_NAME, ORDINAL_POSITION";
            var dd = classData.FillData(sql, SelectedRow.POL);
            dd.TableName = "aaaaaaaaaaaaaaaaaaa";
            classFun.SaveDataTableToCsv(dd);
        }

        private void dgLastServer_Click(object sender, EventArgs e)
        {
            var SelectedRow = dgLastServer.CurrentRow<ServerDatabase>();
            ListaTabelBaza(SelectedRow.ServerName, SelectedRow.DataBaseName);
            GlobalData.SetValue(SelectedRow.ServerName, SelectedRow.DataBaseName);

            classMemory.MemoryWrite(ConfigSave.Server, $"{GlobalData.ServerName}/{GlobalData.DataBaseName}");
            classFun.FavoriteAdd($"{GlobalData.ServerName}/{GlobalData.DataBaseName}");
        }

        private void dgTableLast_Click(object sender, EventArgs e)
        {
            var select = dgTableLast.CurrentRow<StringValue>();
            classFun.AddTableMemory(select.Value, dgTableLast);
            classMemory.MemoryWrite(ConfigSave.Table, select.Value);
            using (FormData form = new FormData(select.Value))
            {
                form.ShowDialog(this);
            }
        }
    }
}