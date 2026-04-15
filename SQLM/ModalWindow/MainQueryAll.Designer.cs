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
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Location = new Point(14, 53);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 54F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 46F));
            tableLayoutPanel1.Size = new Size(1379, 531);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Location = new Point(25, 8);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(50, 20);
            lblQuestion.TabIndex = 1;
            lblQuestion.Text = "label1";
            // 
            // button1
            // 
            button1.Location = new Point(485, 4);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(117, 31);
            button1.TabIndex = 2;
            button1.Text = "Pokaż wynik";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(295, 4);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(164, 27);
            textBox1.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(631, 3);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(117, 31);
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
            lblInfo.Location = new Point(766, 9);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(78, 32);
            lblInfo.TabIndex = 5;
            lblInfo.Text = "label1";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(25, 53);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1382, 514);
            dataGridView1.TabIndex = 6;
            // 
            // MainQueryAll
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1407, 600);
            Controls.Add(dataGridView1);
            Controls.Add(lblInfo);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(lblQuestion);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainQueryAll";
            Text = "MainQueryAll";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private DataGridView dataGridView1;
    }
}