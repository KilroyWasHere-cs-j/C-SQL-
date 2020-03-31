namespace WindowsFormsApp4
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labelItems = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.DateTimeLabel = new System.Windows.Forms.Label();
            this.StoredProctxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SProctxt = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SPLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Param1txt = new System.Windows.Forms.TextBox();
            this.ParamTwotxt = new System.Windows.Forms.TextBox();
            this.ParamThree = new System.Windows.Forms.TextBox();
            this.ParamFour = new System.Windows.Forms.TextBox();
            this.OpenLoggerbtn = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.UseSMSRB = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Run Query";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(400, 50);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(388, 407);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(0, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 13);
            this.linkLabel1.TabIndex = 2;
            // 
            // labelItems
            // 
            this.labelItems.AutoSize = true;
            this.labelItems.Location = new System.Drawing.Point(93, 5);
            this.labelItems.Name = "labelItems";
            this.labelItems.Size = new System.Drawing.Size(13, 13);
            this.labelItems.TabIndex = 3;
            this.labelItems.Text = "0";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(12, 50);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(382, 407);
            this.listBox2.TabIndex = 4;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.ListBox2_SelectedIndexChanged);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(794, 50);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(388, 407);
            this.listBox3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Neural Network Data Prep";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Query Output";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(791, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Log";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 460);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Set Query";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 476);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1164, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(207, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Run StoredProcedure";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // DateTimeLabel
            // 
            this.DateTimeLabel.AutoSize = true;
            this.DateTimeLabel.Location = new System.Drawing.Point(1496, 5);
            this.DateTimeLabel.Name = "DateTimeLabel";
            this.DateTimeLabel.Size = new System.Drawing.Size(35, 13);
            this.DateTimeLabel.TabIndex = 12;
            this.DateTimeLabel.Text = "label5";
            // 
            // StoredProctxt
            // 
            this.StoredProctxt.Location = new System.Drawing.Point(16, 512);
            this.StoredProctxt.Name = "StoredProctxt";
            this.StoredProctxt.Size = new System.Drawing.Size(1164, 20);
            this.StoredProctxt.TabIndex = 13;
            this.StoredProctxt.TextChanged += new System.EventHandler(this.StoredProctxt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 499);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Set Stored Procedure";
            // 
            // SProctxt
            // 
            this.SProctxt.FormattingEnabled = true;
            this.SProctxt.Location = new System.Drawing.Point(1188, 50);
            this.SProctxt.Name = "SProctxt";
            this.SProctxt.Size = new System.Drawing.Size(388, 407);
            this.SProctxt.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1185, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Stored Procedure";
            // 
            // SPLabel
            // 
            this.SPLabel.AutoSize = true;
            this.SPLabel.Location = new System.Drawing.Point(335, 5);
            this.SPLabel.Name = "SPLabel";
            this.SPLabel.Size = new System.Drawing.Size(13, 13);
            this.SPLabel.TabIndex = 17;
            this.SPLabel.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 533);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "VNumb";
            this.label7.Click += new System.EventHandler(this.Label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1186, 460);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Parmas";
            // 
            // Param1txt
            // 
            this.Param1txt.Location = new System.Drawing.Point(1186, 476);
            this.Param1txt.Name = "Param1txt";
            this.Param1txt.Size = new System.Drawing.Size(100, 20);
            this.Param1txt.TabIndex = 20;
            this.Param1txt.Text = "One";
            this.Param1txt.TextChanged += new System.EventHandler(this.Param1txt_TextChanged);
            // 
            // ParamTwotxt
            // 
            this.ParamTwotxt.Location = new System.Drawing.Point(1186, 512);
            this.ParamTwotxt.Name = "ParamTwotxt";
            this.ParamTwotxt.Size = new System.Drawing.Size(100, 20);
            this.ParamTwotxt.TabIndex = 21;
            this.ParamTwotxt.Text = "Two";
            this.ParamTwotxt.TextChanged += new System.EventHandler(this.ParamTwotxt_TextChanged);
            // 
            // ParamThree
            // 
            this.ParamThree.Location = new System.Drawing.Point(1292, 476);
            this.ParamThree.Name = "ParamThree";
            this.ParamThree.Size = new System.Drawing.Size(100, 20);
            this.ParamThree.TabIndex = 22;
            this.ParamThree.Text = "Three";
            this.ParamThree.TextChanged += new System.EventHandler(this.ParamThree_TextChanged);
            // 
            // ParamFour
            // 
            this.ParamFour.Location = new System.Drawing.Point(1292, 512);
            this.ParamFour.Name = "ParamFour";
            this.ParamFour.Size = new System.Drawing.Size(100, 20);
            this.ParamFour.TabIndex = 23;
            this.ParamFour.Text = "Four";
            this.ParamFour.TextChanged += new System.EventHandler(this.ParamFour_TextChanged);
            // 
            // OpenLoggerbtn
            // 
            this.OpenLoggerbtn.Location = new System.Drawing.Point(366, 5);
            this.OpenLoggerbtn.Name = "OpenLoggerbtn";
            this.OpenLoggerbtn.Size = new System.Drawing.Size(75, 23);
            this.OpenLoggerbtn.TabIndex = 24;
            this.OpenLoggerbtn.Text = "Open Logger";
            this.OpenLoggerbtn.UseVisualStyleBackColor = true;
            this.OpenLoggerbtn.Click += new System.EventHandler(this.OpenLoggerbtn_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(1399, 476);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(88, 17);
            this.radioButton1.TabIndex = 25;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "includParams";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // UseSMSRB
            // 
            this.UseSMSRB.AutoSize = true;
            this.UseSMSRB.Location = new System.Drawing.Point(447, 12);
            this.UseSMSRB.Name = "UseSMSRB";
            this.UseSMSRB.Size = new System.Drawing.Size(48, 17);
            this.UseSMSRB.TabIndex = 27;
            this.UseSMSRB.TabStop = true;
            this.UseSMSRB.Text = "SMS";
            this.UseSMSRB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1604, 555);
            this.Controls.Add(this.UseSMSRB);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.OpenLoggerbtn);
            this.Controls.Add(this.ParamFour);
            this.Controls.Add(this.ParamThree);
            this.Controls.Add(this.ParamTwotxt);
            this.Controls.Add(this.Param1txt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SPLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SProctxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.StoredProctxt);
            this.Controls.Add(this.DateTimeLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.labelItems);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "SQL Head";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.MouseLeave += new System.EventHandler(this.Mouse_ComeBack);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label labelItems;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label DateTimeLabel;
        private System.Windows.Forms.TextBox StoredProctxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox SProctxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label SPLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Param1txt;
        private System.Windows.Forms.TextBox ParamTwotxt;
        private System.Windows.Forms.TextBox ParamThree;
        private System.Windows.Forms.TextBox ParamFour;
        private System.Windows.Forms.Button OpenLoggerbtn;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton UseSMSRB;
    }
}

