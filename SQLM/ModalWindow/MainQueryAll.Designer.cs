namespace SQLM.ModalWindow
{
    partial class MainQueryAll
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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblQuestion = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            lblInfo = new Label();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Location = new Point(12, 38);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 54F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 46F));
            tableLayoutPanel1.Size = new Size(1207, 400);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Location = new Point(22, 6);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(38, 15);
            lblQuestion.TabIndex = 1;
            lblQuestion.Text = "label1";
            // 
            // button1
            // 
            button1.Location = new Point(424, 3);
            button1.Name = "button1";
            button1.Size = new Size(102, 23);
            button1.TabIndex = 2;
            button1.Text = "Pokaż wynik";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(258, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(144, 23);
            textBox1.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(552, 2);
            button2.Name = "button2";
            button2.Size = new Size(102, 23);
            button2.TabIndex = 4;
            button2.Text = "Pokaż SQL";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lblInfo.ForeColor = Color.FromArgb(0, 192, 0);
            lblInfo.Location = new Point(670, 7);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(63, 25);
            lblInfo.TabIndex = 5;
            lblInfo.Text = "label1";
            // 
            // MainQueryAll
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1231, 450);
            Controls.Add(lblInfo);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(lblQuestion);
            Controls.Add(tableLayoutPanel1);
            Name = "MainQueryAll";
            Text = "MainQueryAll";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblQuestion;
        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private Label lblInfo;
    }
}