namespace Game.FrmUI
{
    partial class FrmSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetting));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button7 = new Button();
            comboBox1 = new ComboBox();
            label3 = new Label();
            button4 = new Button();
            label5 = new Label();
            label4 = new Label();
            button2 = new Button();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            checkBox4 = new CheckBox();
            button8 = new Button();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            tabPage4 = new TabPage();
            linkLabel1 = new LinkLabel();
            label6 = new Label();
            button10 = new Button();
            button9 = new Button();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox6 = new TextBox();
            label45 = new Label();
            label44 = new Label();
            label43 = new Label();
            label42 = new Label();
            tabPage3 = new TabPage();
            button6 = new Button();
            button5 = new Button();
            button3 = new Button();
            checkedListBox1 = new CheckedListBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 17);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(477, 303);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button7);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(469, 273);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "资料设置";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(356, 153);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 14;
            button7.Text = "保存";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // comboBox1
            // 
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "无称号" });
            comboBox1.Location = new Point(100, 152);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(233, 24);
            comboBox1.TabIndex = 13;
            comboBox1.DrawItem += comboBox1_DrawItem;
            comboBox1.DropDown += comboBox1_DropDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 155);
            label3.Name = "label3";
            label3.Size = new Size(44, 17);
            label3.TabIndex = 12;
            label3.Text = "称号：";
            // 
            // button4
            // 
            button4.Location = new Point(356, 199);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 11;
            button4.Text = "绑定";
            button4.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("文道粗楷体", 10.4999981F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(102, 203);
            label5.Name = "label5";
            label5.Size = new Size(51, 19);
            label5.TabIndex = 10;
            label5.Text = "未绑定";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 204);
            label4.Name = "label4";
            label4.Size = new Size(56, 17);
            label4.TabIndex = 9;
            label4.Text = "Steam：";
            // 
            // button2
            // 
            button2.Location = new Point(356, 104);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "保存";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(356, 46);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "保存";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("文道粗楷体", 10.4999981F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(100, 101);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "输入要修改的密码";
            textBox2.Size = new Size(233, 26);
            textBox2.TabIndex = 4;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("文道粗楷体", 10.4999981F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(100, 45);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "输入要修改的道号";
            textBox1.Size = new Size(233, 26);
            textBox1.TabIndex = 3;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 105);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 1;
            label2.Text = "密码：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 49);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 0;
            label1.Text = "道号：";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(checkBox4);
            tabPage2.Controls.Add(button8);
            tabPage2.Controls.Add(checkBox3);
            tabPage2.Controls.Add(checkBox2);
            tabPage2.Controls.Add(checkBox1);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(469, 273);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "系统设置";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(55, 167);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(135, 21);
            checkBox4.TabIndex = 4;
            checkBox4.Text = "系统消息同步到世界";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(370, 228);
            button8.Name = "button8";
            button8.Size = new Size(75, 28);
            button8.TabIndex = 3;
            button8.Text = "保存";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(55, 129);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(75, 21);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "贴边折叠";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(55, 92);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(111, 21);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "不自动更新列表";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(55, 54);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(87, 21);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "消息免打扰";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(linkLabel1);
            tabPage4.Controls.Add(label6);
            tabPage4.Controls.Add(button10);
            tabPage4.Controls.Add(button9);
            tabPage4.Controls.Add(textBox5);
            tabPage4.Controls.Add(textBox4);
            tabPage4.Controls.Add(textBox3);
            tabPage4.Controls.Add(textBox6);
            tabPage4.Controls.Add(label45);
            tabPage4.Controls.Add(label44);
            tabPage4.Controls.Add(label43);
            tabPage4.Controls.Add(label42);
            tabPage4.Location = new Point(4, 26);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(469, 273);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "消息设置";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(17, 242);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(57, 17);
            linkLabel1.TabIndex = 17;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "RGB用例";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ControlDark;
            label6.Location = new Point(37, 29);
            label6.Name = "label6";
            label6.Size = new Size(116, 17);
            label6.TabIndex = 16;
            label6.Text = "此设置仅对本机有效";
            // 
            // button10
            // 
            button10.Location = new Point(380, 236);
            button10.Name = "button10";
            button10.Size = new Size(75, 23);
            button10.TabIndex = 15;
            button10.Text = "还原";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button9
            // 
            button9.Location = new Point(301, 236);
            button9.Name = "button9";
            button9.Size = new Size(75, 23);
            button9.TabIndex = 14;
            button9.Text = "保存";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // textBox5
            // 
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Font = new Font("文道粗楷体", 10.4999981F, FontStyle.Regular, GraphicsUnit.Point);
            textBox5.Location = new Point(166, 174);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "#000000";
            textBox5.Size = new Size(241, 26);
            textBox5.TabIndex = 11;
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Font = new Font("文道粗楷体", 10.4999981F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(166, 137);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "#000000";
            textBox4.Size = new Size(241, 26);
            textBox4.TabIndex = 12;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Font = new Font("文道粗楷体", 10.4999981F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(166, 101);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "#000000";
            textBox3.Size = new Size(241, 26);
            textBox3.TabIndex = 13;
            // 
            // textBox6
            // 
            textBox6.BorderStyle = BorderStyle.FixedSingle;
            textBox6.Font = new Font("文道粗楷体", 10.4999981F, FontStyle.Regular, GraphicsUnit.Point);
            textBox6.Location = new Point(166, 63);
            textBox6.Name = "textBox6";
            textBox6.PlaceholderText = "默认请留空";
            textBox6.Size = new Size(241, 26);
            textBox6.TabIndex = 10;
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Location = new Point(62, 66);
            label45.Name = "label45";
            label45.Size = new Size(92, 17);
            label45.TabIndex = 9;
            label45.Text = "自己称号显示：";
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Location = new Point(62, 139);
            label44.Name = "label44";
            label44.Size = new Size(92, 17);
            label44.TabIndex = 8;
            label44.Text = "自己称号颜色：";
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Location = new Point(62, 176);
            label43.Name = "label43";
            label43.Size = new Size(92, 17);
            label43.TabIndex = 7;
            label43.Text = "朋友字体颜色：";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Location = new Point(62, 104);
            label42.Name = "label42";
            label42.Size = new Size(92, 17);
            label42.TabIndex = 6;
            label42.Text = "自己消息颜色：";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(button6);
            tabPage3.Controls.Add(button5);
            tabPage3.Controls.Add(button3);
            tabPage3.Controls.Add(checkedListBox1);
            tabPage3.Location = new Point(4, 26);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(469, 273);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "插件设置";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(365, 28);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 3;
            button6.Text = "刷新";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(365, 114);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 2;
            button5.Text = "禁用";
            button5.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(365, 71);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 1;
            button3.Text = "启用";
            button3.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(30, 28);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(312, 220);
            checkedListBox1.TabIndex = 0;
            // 
            // FrmSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 332);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSetting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "设置";
            Load += FrmSetting_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private Label label4;
        private Label label5;
        private Button button4;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckedListBox checkedListBox1;
        private Button button3;
        private Button button5;
        private Button button6;
        private Label label3;
        private ComboBox comboBox1;
        private Button button7;
        private Button button8;
        private CheckBox checkBox4;
        private TabPage tabPage4;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox6;
        private Label label45;
        private Label label44;
        private Label label43;
        private Label label42;
        private Button button9;
        private Button button10;
        private Label label6;
        private LinkLabel linkLabel1;
    }
}