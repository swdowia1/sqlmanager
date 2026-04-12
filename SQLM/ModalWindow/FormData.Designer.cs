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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgDane = new DataGridView();
            tabPage2 = new TabPage();
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
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(11, 84);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1273, 508);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgDane);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1265, 475);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Dane";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgDane
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgDane.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgDane.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgDane.DefaultCellStyle = dataGridViewCellStyle4;
            dgDane.Dock = DockStyle.Fill;
            dgDane.Location = new Point(3, 3);
            dgDane.Name = "dgDane";
            dgDane.RowHeadersWidth = 51;
            dgDane.Size = new Size(1259, 469);
            dgDane.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(rtQuery);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1265, 475);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Zapytanie";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // rtQuery
            // 
            rtQuery.Dock = DockStyle.Fill;
            rtQuery.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            rtQuery.Location = new Point(3, 3);
            rtQuery.Name = "rtQuery";
            rtQuery.Size = new Size(1259, 469);
            rtQuery.TabIndex = 0;
            rtQuery.Text = "";
            // 
            // btnRunSQL
            // 
            btnRunSQL.Location = new Point(37, 11);
            btnRunSQL.Name = "btnRunSQL";
            btnRunSQL.Size = new Size(145, 29);
            btnRunSQL.TabIndex = 1;
            btnRunSQL.Text = "ponów zapytanie";
            btnRunSQL.UseVisualStyleBackColor = true;
            btnRunSQL.Click += btnRunSQL_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.Location = new Point(1264, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(33, 29);
            btnExit.TabIndex = 7;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnRowShow
            // 
            btnRowShow.Location = new Point(1035, 11);
            btnRowShow.Name = "btnRowShow";
            btnRowShow.Size = new Size(145, 29);
            btnRowShow.TabIndex = 8;
            btnRowShow.Text = "Pokaz wiersz";
            btnRowShow.UseVisualStyleBackColor = true;
            btnRowShow.Click += btnRowShow_Click;
            // 
            // btnShow
            // 
            btnShow.Location = new Point(1035, 47);
            btnShow.Margin = new Padding(3, 4, 3, 4);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(145, 31);
            btnShow.TabIndex = 9;
            btnShow.Text = "Pokaż komórke";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // btnFiltr
            // 
            btnFiltr.Location = new Point(515, 49);
            btnFiltr.Name = "btnFiltr";
            btnFiltr.Size = new Size(94, 29);
            btnFiltr.TabIndex = 10;
            btnFiltr.Text = "Filtruj";
            btnFiltr.UseVisualStyleBackColor = true;
            btnFiltr.Click += btnFiltr_Click;
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(18, 50);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(439, 27);
            txtFilter.TabIndex = 11;
            // 
            // btnClearFiltr
            // 
            btnClearFiltr.Location = new Point(639, 50);
            btnClearFiltr.Name = "btnClearFiltr";
            btnClearFiltr.Size = new Size(94, 29);
            btnClearFiltr.TabIndex = 12;
            btnClearFiltr.Text = "Czyść filtr";
            btnClearFiltr.UseVisualStyleBackColor = true;
            btnClearFiltr.Click += btnClearFiltr_Click;
            // 
            // FormData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1297, 605);
            Controls.Add(btnClearFiltr);
            Controls.Add(txtFilter);
            Controls.Add(btnFiltr);
            Controls.Add(btnShow);
            Controls.Add(btnRowShow);
            Controls.Add(btnExit);
            Controls.Add(btnRunSQL);
            Controls.Add(tabControl1);
            Name = "FormData";
            Text = "FormData";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgDane).EndInit();
            tabPage2.ResumeLayout(false);
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
    }
}