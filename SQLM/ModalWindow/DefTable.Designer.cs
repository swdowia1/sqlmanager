namespace SQLM.ModalWindow
{
    partial class DefTable
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            dgKolumny = new DataGridView();
            dgPowiazania = new DataGridView();
            dgProcedury = new DataGridView();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgKolumny).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgPowiazania).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgProcedury).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1117, 572);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgKolumny);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1109, 539);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Kolumny";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgPowiazania);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1109, 539);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Powiazania";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dgProcedury);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1109, 539);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Procedury";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgKolumny
            // 
            dgKolumny.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgKolumny.Dock = DockStyle.Fill;
            dgKolumny.Location = new Point(3, 3);
            dgKolumny.Name = "dgKolumny";
            dgKolumny.RowHeadersWidth = 51;
            dgKolumny.Size = new Size(1103, 533);
            dgKolumny.TabIndex = 0;
            // 
            // dgPowiazania
            // 
            dgPowiazania.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgPowiazania.Dock = DockStyle.Fill;
            dgPowiazania.Location = new Point(3, 3);
            dgPowiazania.Name = "dgPowiazania";
            dgPowiazania.RowHeadersWidth = 51;
            dgPowiazania.Size = new Size(1103, 533);
            dgPowiazania.TabIndex = 0;
            // 
            // dgProcedury
            // 
            dgProcedury.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgProcedury.Dock = DockStyle.Fill;
            dgProcedury.Location = new Point(3, 3);
            dgProcedury.Name = "dgProcedury";
            dgProcedury.RowHeadersWidth = 51;
            dgProcedury.Size = new Size(1103, 533);
            dgProcedury.TabIndex = 0;
            // 
            // DefTable
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1117, 572);
            Controls.Add(tabControl1);
            Name = "DefTable";
            Text = "DeftTable";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgKolumny).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgPowiazania).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgProcedury).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dgKolumny;
        private DataGridView dgPowiazania;
        private TabPage tabPage3;
        private DataGridView dgProcedury;
    }
}