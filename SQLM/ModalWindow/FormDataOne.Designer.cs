namespace SQLM.ModalWindow
{
    partial class FormDataOne
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
            dgData = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgData).BeginInit();
            SuspendLayout();
            // 
            // dgData
            // 
            dgData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgData.Dock = DockStyle.Fill;
            dgData.Location = new Point(0, 0);
            dgData.Name = "dgData";
            dgData.RowHeadersWidth = 51;
            dgData.Size = new Size(648, 707);
            dgData.TabIndex = 0;
            // 
            // FormDataOne
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(648, 707);
            Controls.Add(dgData);
            Name = "FormDataOne";
            Text = "FormDataOne";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgData;
    }
}