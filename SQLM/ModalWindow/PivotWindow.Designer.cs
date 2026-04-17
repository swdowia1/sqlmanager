namespace SQLM.ModalWindow
{
    partial class PivotWindow
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
            dgPivot = new DataGridView();
            btnExit = new Button();
            btnShow = new Button();
            rtbJson = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)dgPivot).BeginInit();
            SuspendLayout();
            // 
            // dgPivot
            // 
            dgPivot.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgPivot.Dock = DockStyle.Left;
            dgPivot.Location = new Point(0, 0);
            dgPivot.Margin = new Padding(3, 2, 3, 2);
            dgPivot.Name = "dgPivot";
            dgPivot.RowHeadersWidth = 51;
            dgPivot.Size = new Size(430, 338);
            dgPivot.TabIndex = 0;
            dgPivot.Click += dgPivot_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.Location = new Point(1077, 0);
            btnExit.Margin = new Padding(3, 2, 3, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(29, 22);
            btnExit.TabIndex = 8;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnShow
            // 
            btnShow.Location = new Point(436, 0);
            btnShow.Margin = new Padding(3, 2, 3, 2);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(245, 22);
            btnShow.TabIndex = 9;
            btnShow.Text = "Pokaz zawartosc";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // rtbJson
            // 
            rtbJson.BackColor = Color.FromArgb(30, 30, 30);
            rtbJson.Dock = DockStyle.Fill;
            rtbJson.Font = new Font("Consolas", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbJson.ForeColor = Color.Gainsboro;
            rtbJson.Location = new Point(430, 0);
            rtbJson.Margin = new Padding(3, 2, 3, 2);
            rtbJson.Name = "rtbJson";
            rtbJson.ReadOnly = true;
            rtbJson.Size = new Size(680, 338);
            rtbJson.TabIndex = 10;
            rtbJson.Text = "";
            // 
            // PivotWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1110, 338);
            Controls.Add(rtbJson);
            Controls.Add(btnShow);
            Controls.Add(btnExit);
            Controls.Add(dgPivot);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PivotWindow";
            Text = "PivotWindow";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgPivot).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgPivot;
        private Button btnExit;
        private Button btnShow;
        private RichTextBox rtbJson;
    }
}