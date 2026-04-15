namespace SQLM
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tvServer = new TreeView();
            dgTable = new DataGridView();
            Schamat = new DataGridViewTextBoxColumn();
            Nazwa = new DataGridViewTextBoxColumn();
            ilosc = new DataGridViewTextBoxColumn();
            kolumny = new DataGridViewTextBoxColumn();
            def = new DataGridViewButtonColumn();
            textBox1 = new TextBox();
            button1 = new Button();
            btnSQL = new Button();
            btnSql2 = new Button();
            btnOpenCatalog = new Button();
            btnAddSql = new Button();
            btnKolumny = new Button();
            dgLastServer = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgLastServer).BeginInit();
            SuspendLayout();
            // 
            // tvServer
            // 
            tvServer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tvServer.Location = new Point(24, 327);
            tvServer.Margin = new Padding(3, 2, 3, 2);
            tvServer.Name = "tvServer";
            tvServer.Size = new Size(392, 390);
            tvServer.TabIndex = 0;
            tvServer.NodeMouseClick += tvServer_NodeMouseClick;
            // 
            // dgTable
            // 
            dgTable.AllowUserToOrderColumns = true;
            dgTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgTable.Columns.AddRange(new DataGridViewColumn[] { Schamat, Nazwa, ilosc, kolumny, def });
            dgTable.Location = new Point(449, 56);
            dgTable.Margin = new Padding(3, 2, 3, 2);
            dgTable.Name = "dgTable";
            dgTable.RowHeadersWidth = 51;
            dgTable.Size = new Size(968, 686);
            dgTable.TabIndex = 1;
            dgTable.CellClick += dgTable_CellClick;
            // 
            // Schamat
            // 
            Schamat.DataPropertyName = "Schemat";
            Schamat.HeaderText = "Schemat";
            Schamat.MinimumWidth = 6;
            Schamat.Name = "Schamat";
            Schamat.ReadOnly = true;
            Schamat.Width = 125;
            // 
            // Nazwa
            // 
            Nazwa.DataPropertyName = "nazwa";
            Nazwa.HeaderText = "Nazwa";
            Nazwa.MinimumWidth = 6;
            Nazwa.Name = "Nazwa";
            Nazwa.Width = 125;
            // 
            // ilosc
            // 
            ilosc.DataPropertyName = "ilosc";
            ilosc.HeaderText = "Ilość wierszy";
            ilosc.MinimumWidth = 6;
            ilosc.Name = "ilosc";
            ilosc.Width = 125;
            // 
            // kolumny
            // 
            kolumny.DataPropertyName = "LiczbaKolumn";
            kolumny.HeaderText = "Ilość kolumn";
            kolumny.MinimumWidth = 6;
            kolumny.Name = "kolumny";
            kolumny.Width = 125;
            // 
            // def
            // 
            def.HeaderText = "definicje";
            def.MinimumWidth = 6;
            def.Name = "def";
            def.Width = 125;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(458, 22);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(353, 23);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(826, 20);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(129, 22);
            button1.TabIndex = 3;
            button1.Text = "szukaj tabela";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnSQL
            // 
            btnSQL.Location = new Point(960, 20);
            btnSQL.Margin = new Padding(3, 2, 3, 2);
            btnSQL.Name = "btnSQL";
            btnSQL.Size = new Size(96, 22);
            btnSQL.TabIndex = 4;
            btnSQL.Text = "SQL";
            btnSQL.UseVisualStyleBackColor = true;
            btnSQL.Click += btnSQL_Click;
            // 
            // btnSql2
            // 
            btnSql2.Location = new Point(1061, 17);
            btnSql2.Name = "btnSql2";
            btnSql2.Size = new Size(75, 23);
            btnSql2.TabIndex = 7;
            btnSql2.Text = "Sql duze";
            btnSql2.UseVisualStyleBackColor = true;
            btnSql2.Click += btnSql2_Click;
            // 
            // btnOpenCatalog
            // 
            btnOpenCatalog.Location = new Point(1142, 17);
            btnOpenCatalog.Margin = new Padding(3, 2, 3, 2);
            btnOpenCatalog.Name = "btnOpenCatalog";
            btnOpenCatalog.Size = new Size(82, 22);
            btnOpenCatalog.TabIndex = 8;
            btnOpenCatalog.Text = "Katalog";
            btnOpenCatalog.UseVisualStyleBackColor = true;
            btnOpenCatalog.Click += btnOpenCatalog_Click;
            // 
            // btnAddSql
            // 
            btnAddSql.Location = new Point(1245, 17);
            btnAddSql.Margin = new Padding(3, 2, 3, 2);
            btnAddSql.Name = "btnAddSql";
            btnAddSql.Size = new Size(82, 22);
            btnAddSql.TabIndex = 9;
            btnAddSql.Text = "dodaj sql";
            btnAddSql.UseVisualStyleBackColor = true;
            btnAddSql.Click += btnAddSql_Click;
            // 
            // btnKolumny
            // 
            btnKolumny.Location = new Point(1333, 16);
            btnKolumny.Name = "btnKolumny";
            btnKolumny.Size = new Size(75, 23);
            btnKolumny.TabIndex = 10;
            btnKolumny.Text = "Kolumny";
            btnKolumny.UseVisualStyleBackColor = true;
            btnKolumny.Click += btnKolumny_Click;
            // 
            // dgLastServer
            // 
            dgLastServer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgLastServer.Location = new Point(24, 16);
            dgLastServer.Name = "dgLastServer";
            dgLastServer.Size = new Size(376, 276);
            dgLastServer.TabIndex = 11;
            dgLastServer.Click += dgLastServer_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1428, 752);
            Controls.Add(dgLastServer);
            Controls.Add(btnKolumny);
            Controls.Add(btnAddSql);
            Controls.Add(btnOpenCatalog);
            Controls.Add(btnSql2);
            Controls.Add(btnSQL);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(dgTable);
            Controls.Add(tvServer);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgLastServer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView tvServer;
        private DataGridView dgTable;
        private TextBox textBox1;
        private Button button1;
        private DataGridViewTextBoxColumn Schamat;
        private DataGridViewTextBoxColumn Nazwa;
        private DataGridViewTextBoxColumn ilosc;
        private DataGridViewTextBoxColumn kolumny;
        private DataGridViewButtonColumn def;
        private Button btnSQL;

        private Button btnSql2;
        private Button btnOpenCatalog;
        private Button btnAddSql;
        private Button btnKolumny;
        private DataGridView dgLastServer;
    }
}
