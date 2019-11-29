namespace ChildCar_Pro
{
    partial class Form2
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
            this.gb_gesture = new System.Windows.Forms.GroupBox();
            this.b_Login = new System.Windows.Forms.Button();
            this.cb_Sex = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_Weight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_Age = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Phone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_gesture.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_gesture
            // 
            this.gb_gesture.Controls.Add(this.b_Login);
            this.gb_gesture.Controls.Add(this.cb_Sex);
            this.gb_gesture.Controls.Add(this.label6);
            this.gb_gesture.Controls.Add(this.label5);
            this.gb_gesture.Controls.Add(this.tb_Weight);
            this.gb_gesture.Controls.Add(this.label4);
            this.gb_gesture.Controls.Add(this.label3);
            this.gb_gesture.Controls.Add(this.cb_Age);
            this.gb_gesture.Controls.Add(this.label2);
            this.gb_gesture.Controls.Add(this.tb_Phone);
            this.gb_gesture.Controls.Add(this.label1);
            this.gb_gesture.Location = new System.Drawing.Point(218, 62);
            this.gb_gesture.Name = "gb_gesture";
            this.gb_gesture.Size = new System.Drawing.Size(341, 359);
            this.gb_gesture.TabIndex = 0;
            this.gb_gesture.TabStop = false;
            this.gb_gesture.Text = "注册";
            // 
            // b_Login
            // 
            this.b_Login.Location = new System.Drawing.Point(69, 310);
            this.b_Login.Name = "b_Login";
            this.b_Login.Size = new System.Drawing.Size(155, 43);
            this.b_Login.TabIndex = 1;
            this.b_Login.Text = "注册";
            this.b_Login.UseVisualStyleBackColor = true;
            this.b_Login.Click += new System.EventHandler(this.B_Login_Click);
            // 
            // cb_Sex
            // 
            this.cb_Sex.FormattingEnabled = true;
            this.cb_Sex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cb_Sex.Location = new System.Drawing.Point(104, 188);
            this.cb_Sex.Name = "cb_Sex";
            this.cb_Sex.Size = new System.Drawing.Size(121, 23);
            this.cb_Sex.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "孩子性别";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "kg";
            // 
            // tb_Weight
            // 
            this.tb_Weight.Location = new System.Drawing.Point(104, 256);
            this.tb_Weight.Name = "tb_Weight";
            this.tb_Weight.Size = new System.Drawing.Size(120, 25);
            this.tb_Weight.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "孩子体重";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "岁";
            // 
            // cb_Age
            // 
            this.cb_Age.FormattingEnabled = true;
            this.cb_Age.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cb_Age.Location = new System.Drawing.Point(104, 135);
            this.cb_Age.Name = "cb_Age";
            this.cb_Age.Size = new System.Drawing.Size(120, 23);
            this.cb_Age.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "孩子年龄";
            // 
            // tb_Phone
            // 
            this.tb_Phone.Location = new System.Drawing.Point(104, 72);
            this.tb_Phone.Name = "tb_Phone";
            this.tb_Phone.Size = new System.Drawing.Size(155, 25);
            this.tb_Phone.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "电话号码";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 497);
            this.Controls.Add(this.gb_gesture);
            this.Name = "Form2";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.gb_gesture.ResumeLayout(false);
            this.gb_gesture.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_gesture;
        private System.Windows.Forms.Button b_Login;
        private System.Windows.Forms.ComboBox cb_Sex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_Weight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_Age;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Phone;
        private System.Windows.Forms.Label label1;
    }
}