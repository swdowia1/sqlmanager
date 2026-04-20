namespace SQLM.ModalWindow
{
    partial class FormData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgDane = new DataGridView();
            tabPage2 = new TabPage();
            dgKolumn = new DataGridView();
            rtQuery = new RichTextBox();
            btnRunSQL = new Button();
            btnExit = new Button();
            btnRowShow = new Button();
            btnShow = new Button();
            btnFiltr = new Button();
            txtFilter = new TextBox();
            btnClearFiltr = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgDane).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgKolumn).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(10, 63);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1114, 381);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgDane);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(1106, 353);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Dane";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgDane
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgDane.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgDane.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgDane.DefaultCellStyle = dataGridViewCellStyle2;
            dgDane.Dock = DockStyle.Fill;
            dgDane.Location = new Point(3, 2);
            dgDane.Margin = new Padding(3, 2, 3, 2);
            dgDane.Name = "dgDane";
            dgDane.RowHeadersWidth = 51;
            dgDane.Size = new Size(1100, 349);
            dgDane.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgKolumn);
            tabPage2.Controls.Add(rtQuery);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(1106, 353);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Zapytanie";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgKolumn
            // 
            dgKolumn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgKolumn.Location = new Point(892, 5);
            dgKolumn.Name = "dgKolumn";
            dgKolumn.Size = new Size(175, 343);
            dgKolumn.TabIndex = 1;
            dgKolumn.Click += dgKolumn_Click;
            // 
            // rtQuery
            // 
            rtQuery.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            rtQuery.Location = new Point(3, 2);
            rtQuery.Margin = new Padding(3, 2, 3, 2);
            rtQuery.Name = "rtQuery";
            rtQuery.Size = new Size(864, 347);
            rtQuery.TabIndex = 0;
            rtQuery.Text = "";
            // 
            // btnRunSQL
            // 
            btnRunSQL.Location = new Point(32, 8);
            btnRunSQL.Margin = new Padding(3, 2, 3, 2);
            btnRunSQL.Name = "btnRunSQL";
            btnRunSQL.Size = new Size(127, 22);
            btnRunSQL.TabIndex = 1;
            btnRunSQL.Text = "ponów zapytanie";
            btnRunSQL.UseVisualStyleBackColor = true;
            btnRunSQL.Click += btnRunSQL_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.Location = new Point(1106, 4);
            btnExit.Margin = new Padding(3, 2, 3, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(29, 22);
            btnExit.TabIndex = 7;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnRowShow
            // 
            btnRowShow.Location = new Point(906, 8);
            btnRowShow.Margin = new Padding(3, 2, 3, 2);
            btnRowShow.Name = "btnRowShow";
            btnRowShow.Size = new Size(127, 22);
            btnRowShow.TabIndex = 8;
            btnRowShow.Text = "Pokaz wiersz";
            btnRowShow.UseVisualStyleBackColor = true;
            btnRowShow.Click += btnRowShow_Click;
            // 
            // btnShow
            // 
            btnShow.Location = new Point(906, 35);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(127, 23);
            btnShow.TabIndex = 9;
            btnShow.Text = "Pokaż komórke";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // btnFiltr
            // 
            btnFiltr.Location = new Point(451, 37);
            btnFiltr.Margin = new Padding(3, 2, 3, 2);
            btnFiltr.Name = "btnFiltr";
            btnFiltr.Size = new Size(82, 22);
            btnFiltr.TabIndex = 10;
            btnFiltr.Text = "Filtruj";
            btnFiltr.UseVisualStyleBackColor = true;
            btnFiltr.Click += btnFiltr_Click;
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(16, 38);
            txtFilter.Margin = new Padding(3, 2, 3, 2);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(385, 23);
            txtFilter.TabIndex = 11;
            // 
            // btnClearFiltr
            // 
            btnClearFiltr.Location = new Point(559, 38);
            btnClearFiltr.Margin = new Padding(3, 2, 3, 2);
            btnClearFiltr.Name = "btnClearFiltr";
            btnClearFiltr.Size = new Size(82, 22);
            btnClearFiltr.TabIndex = 12;
            btnClearFiltr.Text = "Czyść filtr";
            btnClearFiltr.UseVisualStyleBackColor = true;
            btnClearFiltr.Click += btnClearFiltr_Click;
            // 
            // FormData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1135, 454);
            Controls.Add(btnClearFiltr);
            Controls.Add(txtFilter);
            Controls.Add(btnFiltr);
            Controls.Add(btnShow);
            Controls.Add(btnRowShow);
            Controls.Add(btnExit);
            Controls.Add(btnRunSQL);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormData";
            Text = "FormData";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgDane).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgKolumn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dgDane;
        private RichTextBox rtQuery;
        private Button btnRunSQL;
        private Button btnExit;
        private Button btnRowShow;
        private Button btnShow;
        private Button btnFiltr;
        private TextBox txtFilter;
        private Button btnClearFiltr;
        private DataGridView dgKolumn;
    }
}