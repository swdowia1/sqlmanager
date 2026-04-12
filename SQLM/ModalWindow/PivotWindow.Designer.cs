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
            ((System.ComponentModel.ISupportInitialize)dgPivot).BeginInit();
            SuspendLayout();
            // 
            // dgPivot
            // 
            dgPivot.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgPivot.Dock = DockStyle.Left;
            dgPivot.Location = new Point(0, 0);
            dgPivot.Name = "dgPivot";
            dgPivot.RowHeadersWidth = 51;
            dgPivot.Size = new Size(744, 451);
            dgPivot.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.Location = new Point(1231, 0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(33, 29);
            btnExit.TabIndex = 8;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnShow
            // 
            btnShow.Location = new Point(815, 58);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(280, 29);
            btnShow.TabIndex = 9;
            btnShow.Text = "Pokaz zawartosc";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // PivotWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1268, 451);
            Controls.Add(btnShow);
            Controls.Add(btnExit);
            Controls.Add(dgPivot);
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
    }
}