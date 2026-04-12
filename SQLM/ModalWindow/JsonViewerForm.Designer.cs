namespace SQLM.ModalWindow
{
    partial class JsonViewerForm
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
            rtbJson = new RichTextBox();
            SuspendLayout();
            // 
            // rtbJson
            // 
            rtbJson.BackColor = Color.FromArgb(30, 30, 30);
            rtbJson.Dock = DockStyle.Fill;
            rtbJson.Font = new Font("Consolas", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbJson.ForeColor = Color.Gainsboro;
            rtbJson.Location = new Point(0, 0);
            rtbJson.Name = "rtbJson";
            rtbJson.ReadOnly = true;
            rtbJson.Size = new Size(800, 450);
            rtbJson.TabIndex = 0;
            rtbJson.Text = "";
            // 
            // JsonViewerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbJson);
            Name = "JsonViewerForm";
            Text = "JsonViewerForm";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtbJson;
    }
}