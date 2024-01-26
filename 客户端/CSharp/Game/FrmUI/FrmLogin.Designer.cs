namespace Game.FrmUI
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            linkLabel1 = new LinkLabel();
            pictureBox1 = new PictureBox();
            button4 = new Button();
            button3 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            panel3 = new Panel();
            button6 = new Button();
            button5 = new Button();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            button2 = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 17);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 0;
            label1.Text = "登录注册";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel3);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(438, 311);
            panel1.TabIndex = 3;
            panel1.MouseDown += AllMouseDown;
            panel1.MouseMove += AllMouseMove;
            panel1.MouseUp += AllMouseUp;
            // 
            // panel2
            // 
            panel2.Controls.Add(linkLabel1);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(21, 50);
            panel2.Name = "panel2";
            panel2.Size = new Size(394, 248);
            panel2.TabIndex = 3;
            panel2.MouseDown += AllMouseDown;
            panel2.MouseMove += AllMouseMove;
            panel2.MouseUp += AllMouseUp;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(177, 202);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(68, 17);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Steam登录";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.steam;
            pictureBox1.Location = new Point(148, 198);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 21);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // button4
            // 
            button4.Location = new Point(232, 153);
            button4.Name = "button4";
            button4.Size = new Size(75, 30);
            button4.TabIndex = 5;
            button4.Text = "前往注册";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(81, 153);
            button3.Name = "button3";
            button3.Size = new Size(75, 30);
            button3.TabIndex = 4;
            button3.Text = "登录";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("文道粗楷体", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            textBox2.Location = new Point(104, 103);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(235, 26);
            textBox2.TabIndex = 3;
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("文道粗楷体", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(104, 57);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(235, 26);
            textBox1.TabIndex = 2;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 106);
            label3.Name = "label3";
            label3.Size = new Size(44, 17);
            label3.TabIndex = 1;
            label3.Text = "密码：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 61);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 0;
            label2.Text = "账号：";
            // 
            // panel3
            // 
            panel3.Controls.Add(button6);
            panel3.Controls.Add(button5);
            panel3.Controls.Add(radioButton2);
            panel3.Controls.Add(radioButton1);
            panel3.Controls.Add(textBox5);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(textBox4);
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label5);
            panel3.Location = new Point(21, 50);
            panel3.Name = "panel3";
            panel3.Size = new Size(394, 248);
            panel3.TabIndex = 4;
            panel3.Visible = false;
            panel3.MouseDown += AllMouseDown;
            panel3.MouseMove += AllMouseMove;
            panel3.MouseUp += AllMouseUp;
            // 
            // button6
            // 
            button6.Location = new Point(251, 183);
            button6.Name = "button6";
            button6.Size = new Size(75, 30);
            button6.TabIndex = 22;
            button6.Text = "返回登录";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Location = new Point(72, 183);
            button5.Name = "button5";
            button5.Size = new Size(75, 30);
            button5.TabIndex = 21;
            button5.Text = "提交注册";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(308, 132);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(38, 21);
            radioButton2.TabIndex = 20;
            radioButton2.Text = "女";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(264, 132);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(38, 21);
            radioButton1.TabIndex = 18;
            radioButton1.TabStop = true;
            radioButton1.Text = "男";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Font = new Font("文道粗楷体", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            textBox5.Location = new Point(111, 130);
            textBox5.MaxLength = 7;
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = " 1-7个字";
            textBox5.Size = new Size(134, 26);
            textBox5.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 132);
            label6.Name = "label6";
            label6.Size = new Size(68, 17);
            label6.TabIndex = 12;
            label6.Text = "角色名称：";
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Font = new Font("文道粗楷体", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            textBox4.Location = new Point(111, 86);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(235, 26);
            textBox4.TabIndex = 11;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Font = new Font("文道粗楷体", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            textBox3.Location = new Point(111, 43);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(235, 26);
            textBox3.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 88);
            label4.Name = "label4";
            label4.Size = new Size(68, 17);
            label4.TabIndex = 9;
            label4.Text = "登录密码：";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 45);
            label5.Name = "label5";
            label5.Size = new Size(68, 17);
            label5.TabIndex = 8;
            label5.Text = "登录账号：";
            // 
            // button2
            // 
            button2.Font = new Font("微软雅黑", 5.25F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(403, 17);
            button2.Name = "button2";
            button2.Size = new Size(20, 20);
            button2.TabIndex = 2;
            button2.TabStop = false;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("微软雅黑", 5.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(377, 17);
            button1.Name = "button1";
            button1.Size = new Size(20, 20);
            button1.TabIndex = 1;
            button1.TabStop = false;
            button1.Text = "—";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 311);
            ControlBox = false;
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "寻仙";
            Load += FrmLogin_Load;
            MouseDown += AllMouseDown;
            MouseMove += AllMouseMove;
            MouseUp += AllMouseUp;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button3;
        private Button button4;
        private PictureBox pictureBox1;
        private LinkLabel linkLabel1;
        private Panel panel3;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label4;
        private Label label5;
        private TextBox textBox5;
        private Label label6;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button5;
        private Button button6;
        private Button button1;
        private Button button2;
    }
}