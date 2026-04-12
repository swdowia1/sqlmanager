namespace SQLM.ModalWindow
{
    partial class AddSqllXML
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
            label1 = new Label();
            txtHeadTitle = new TextBox();
            txtDescribe1 = new TextBox();
            label2 = new Label();
            txtQuestion = new TextBox();
            label3 = new Label();
            txtParametr = new TextBox();
            label4 = new Label();
            rtSQL = new RichTextBox();
            btnValidate = new Button();
            lblDescribe = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 31);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
            label1.TabIndex = 0;
            label1.Text = "Tytuł główny";
            // 
            // txtHeadTitle
            // 
            txtHeadTitle.Location = new Point(201, 31);
            txtHeadTitle.Name = "txtHeadTitle";
            txtHeadTitle.Size = new Size(797, 27);
            txtHeadTitle.TabIndex = 1;
            // 
            // txtDescribe1
            // 
            txtDescribe1.Location = new Point(201, 120);
            txtDescribe1.Name = "txtDescribe1";
            txtDescribe1.Size = new Size(419, 27);
            txtDescribe1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 120);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 2;
            label2.Text = "Opis pierszy grd";
            // 
            // txtQuestion
            // 
            txtQuestion.Location = new Point(201, 77);
            txtQuestion.Name = "txtQuestion";
            txtQuestion.Size = new Size(797, 27);
            txtQuestion.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 77);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 4;
            label3.Text = "Pytanie";
            // 
            // txtParametr
            // 
            txtParametr.Location = new Point(924, 123);
            txtParametr.Name = "txtParametr";
            txtParametr.Size = new Size(227, 27);
            txtParametr.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(639, 123);
            label4.Name = "label4";
            label4.Size = new Size(163, 20);
            label4.TabIndex = 6;
            label4.Text = "do testu wstaw wartosc";
            // 
            // rtSQL
            // 
            rtSQL.Location = new Point(47, 252);
            rtSQL.Name = "rtSQL";
            rtSQL.Size = new Size(1184, 326);
            rtSQL.TabIndex = 8;
            rtSQL.Text = "";
            // 
            // btnValidate
            // 
            btnValidate.Location = new Point(73, 182);
            btnValidate.Name = "btnValidate";
            btnValidate.Size = new Size(94, 29);
            btnValidate.TabIndex = 9;
            btnValidate.Text = "Waliduj";
            btnValidate.UseVisualStyleBackColor = true;
            btnValidate.Click += btnValidate_Click;
            // 
            // lblDescribe
            // 
            lblDescribe.AutoSize = true;
            lblDescribe.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lblDescribe.Location = new Point(201, 186);
            lblDescribe.Name = "lblDescribe";
            lblDescribe.Size = new Size(123, 28);
            lblDescribe.TabIndex = 10;
            lblDescribe.Text = "Tytuł główny";
            // 
            // AddSqllXML
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1243, 727);
            Controls.Add(lblDescribe);
            Controls.Add(btnValidate);
            Controls.Add(rtSQL);
            Controls.Add(txtParametr);
            Controls.Add(label4);
            Controls.Add(txtQuestion);
            Controls.Add(label3);
            Controls.Add(txtDescribe1);
            Controls.Add(label2);
            Controls.Add(txtHeadTitle);
            Controls.Add(label1);
            Name = "AddSqllXML";
            Text = "AddSqllXML";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtHeadTitle;
        private TextBox txtDescribe1;
        private Label label2;
        private TextBox txtQuestion;
        private Label label3;
        private TextBox txtParametr;
        private Label label4;
        private RichTextBox rtSQL;
        private Button btnValidate;
        private Label lblDescribe;
    }
}