namespace SQLM.ModalWindow
{
    partial class QueryListSave
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
            dgFile = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgFile).BeginInit();
            SuspendLayout();
            // 
            // dgFile
            // 
            dgFile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgFile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgFile.Location = new Point(12, 33);
            dgFile.Name = "dgFile";
            dgFile.Size = new Size(776, 390);
            dgFile.TabIndex = 0;
            dgFile.CellClick += dgFile_CellClick;
            // 
            // QueryListSave
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgFile);
            Name = "QueryListSave";
            Text = "Lista zapisanych zapytań z katalogu KatalogXML ";
            ((System.ComponentModel.ISupportInitialize)dgFile).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgFile;
    }
}