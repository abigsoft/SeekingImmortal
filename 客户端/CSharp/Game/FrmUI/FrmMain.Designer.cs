namespace Game.FrmUI
{
    partial class FrmMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            panel_collapsed = new Panel();
            panel_main = new Panel();
            label2 = new Label();
            tabControl3 = new TabControl();
            tabPage9 = new TabPage();
            tabPage10 = new TabPage();
            tabControl2 = new TabControl();
            tabPage7 = new TabPage();
            tabPage8 = new TabPage();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage4 = new TabPage();
            tabPage3 = new TabPage();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            tabPage2 = new TabPage();
            button3 = new Button();
            button1 = new Button();
            contextMenuStrip2 = new ContextMenuStrip(components);
            发送图片ToolStripMenuItem = new ToolStripMenuItem();
            发送表情ToolStripMenuItem = new ToolStripMenuItem();
            textBox1 = new TextBox();
            button2 = new Button();
            label1 = new Label();
            heart_jump = new System.Windows.Forms.Timer(components);
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            设置ToolStripMenuItem = new ToolStripMenuItem();
            显示ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            退出ToolStripMenuItem = new ToolStripMenuItem();
            timer1 = new System.Windows.Forms.Timer(components);
            panel_main.SuspendLayout();
            tabControl3.SuspendLayout();
            tabControl2.SuspendLayout();
            tabControl1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel_collapsed
            // 
            panel_collapsed.BackColor = SystemColors.ActiveCaption;
            panel_collapsed.Location = new Point(0, 0);
            panel_collapsed.Name = "panel_collapsed";
            panel_collapsed.Size = new Size(10, 560);
            panel_collapsed.TabIndex = 0;
            panel_collapsed.Visible = false;
            panel_collapsed.MouseEnter += panel_collapsed_MouseEnter;
            // 
            // panel_main
            // 
            panel_main.BorderStyle = BorderStyle.FixedSingle;
            panel_main.Controls.Add(label2);
            panel_main.Controls.Add(tabControl3);
            panel_main.Controls.Add(tabControl2);
            panel_main.Controls.Add(tabControl1);
            panel_main.Controls.Add(button3);
            panel_main.Controls.Add(button1);
            panel_main.Controls.Add(textBox1);
            panel_main.Controls.Add(button2);
            panel_main.Controls.Add(label1);
            panel_main.Location = new Point(0, 0);
            panel_main.Name = "panel_main";
            panel_main.Size = new Size(800, 560);
            panel_main.TabIndex = 1;
            panel_main.MouseDown += AllMouseDown;
            panel_main.MouseMove += AllMouseMove;
            panel_main.MouseUp += AllMouseUp;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.AppWorkspace;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(11, 265);
            label2.Name = "label2";
            label2.Size = new Size(776, 23);
            label2.TabIndex = 11;
            label2.Text = "系统通知";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl3
            // 
            tabControl3.Controls.Add(tabPage9);
            tabControl3.Controls.Add(tabPage10);
            tabControl3.ItemSize = new Size(76, 22);
            tabControl3.Location = new Point(596, 41);
            tabControl3.Name = "tabControl3";
            tabControl3.SelectedIndex = 0;
            tabControl3.Size = new Size(191, 220);
            tabControl3.SizeMode = TabSizeMode.Fixed;
            tabControl3.TabIndex = 10;
            // 
            // tabPage9
            // 
            tabPage9.Location = new Point(4, 26);
            tabPage9.Name = "tabPage9";
            tabPage9.Padding = new Padding(3);
            tabPage9.Size = new Size(183, 190);
            tabPage9.TabIndex = 0;
            tabPage9.Text = "小道消息";
            tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            tabPage10.Location = new Point(4, 26);
            tabPage10.Name = "tabPage10";
            tabPage10.Padding = new Padding(3);
            tabPage10.Size = new Size(183, 190);
            tabPage10.TabIndex = 1;
            tabPage10.Text = "系统公告";
            tabPage10.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage7);
            tabControl2.Controls.Add(tabPage8);
            tabControl2.Location = new Point(12, 294);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(771, 220);
            tabControl2.SizeMode = TabSizeMode.Fixed;
            tabControl2.TabIndex = 9;
            // 
            // tabPage7
            // 
            tabPage7.Location = new Point(4, 26);
            tabPage7.Name = "tabPage7";
            tabPage7.Padding = new Padding(3);
            tabPage7.Size = new Size(763, 190);
            tabPage7.TabIndex = 0;
            tabPage7.Text = "世界聊天";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            tabPage8.Location = new Point(4, 26);
            tabPage8.Name = "tabPage8";
            tabPage8.Padding = new Padding(3);
            tabPage8.Size = new Size(763, 190);
            tabPage8.TabIndex = 1;
            tabPage8.Text = "系统通知";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.ItemSize = new Size(78, 22);
            tabControl1.Location = new Point(9, 41);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(581, 220);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(573, 190);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "信息";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 26);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(573, 190);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "娱乐";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 26);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(573, 190);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "工具";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 26);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(573, 190);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "家园";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Location = new Point(4, 26);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(573, 190);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "市场";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(573, 190);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "设置";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("微软雅黑", 5.25F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(737, 11);
            button3.Name = "button3";
            button3.Size = new Size(20, 20);
            button3.TabIndex = 7;
            button3.TabStop = false;
            button3.Text = "—";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.ContextMenuStrip = contextMenuStrip2;
            button1.Location = new Point(699, 520);
            button1.Name = "button1";
            button1.Size = new Size(88, 27);
            button1.TabIndex = 6;
            button1.TabStop = false;
            button1.Text = "发送";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { 发送图片ToolStripMenuItem, 发送表情ToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(125, 48);
            // 
            // 发送图片ToolStripMenuItem
            // 
            发送图片ToolStripMenuItem.Name = "发送图片ToolStripMenuItem";
            发送图片ToolStripMenuItem.Size = new Size(124, 22);
            发送图片ToolStripMenuItem.Text = "发送图片";
            // 
            // 发送表情ToolStripMenuItem
            // 
            发送表情ToolStripMenuItem.Name = "发送表情ToolStripMenuItem";
            发送表情ToolStripMenuItem.Size = new Size(124, 22);
            发送表情ToolStripMenuItem.Text = "发送表情";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("文道粗楷体", 10.4999981F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(11, 521);
            textBox1.MaxLength = 30;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "在这里输入发送的消息";
            textBox1.Size = new Size(682, 26);
            textBox1.TabIndex = 5;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // button2
            // 
            button2.Font = new Font("微软雅黑", 5.25F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(763, 11);
            button2.Name = "button2";
            button2.Size = new Size(20, 20);
            button2.TabIndex = 4;
            button2.TabStop = false;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 14);
            label1.Name = "label1";
            label1.Size = new Size(164, 17);
            label1.TabIndex = 0;
            label1.Text = "寻仙：敢问上天，可否有仙？";
            // 
            // heart_jump
            // 
            heart_jump.Interval = 20000;
            heart_jump.Tick += heart_jump_Tick;
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "寻仙：敢问上天，可否有仙？";
            notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 设置ToolStripMenuItem, 显示ToolStripMenuItem, toolStripSeparator1, 退出ToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(101, 76);
            // 
            // 设置ToolStripMenuItem
            // 
            设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            设置ToolStripMenuItem.Size = new Size(100, 22);
            设置ToolStripMenuItem.Text = "设置";
            // 
            // 显示ToolStripMenuItem
            // 
            显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            显示ToolStripMenuItem.Size = new Size(100, 22);
            显示ToolStripMenuItem.Text = "显示";
            显示ToolStripMenuItem.Click += 显示ToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(97, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            退出ToolStripMenuItem.Size = new Size(100, 22);
            退出ToolStripMenuItem.Text = "退出";
            退出ToolStripMenuItem.Click += 退出ToolStripMenuItem_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 300;
            timer1.Tick += timer1_Tick;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 560);
            ControlBox = false;
            Controls.Add(panel_main);
            Controls.Add(panel_collapsed);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "寻仙：敢问上天，可否有仙？";
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            panel_main.ResumeLayout(false);
            panel_main.PerformLayout();
            tabControl3.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_collapsed;
        private Panel panel_main;
        private Label label1;
        private Button button2;
        private System.Windows.Forms.Timer heart_jump;
        private NotifyIcon notifyIcon1;
        private TextBox textBox1;
        private Button button1;
        private Button button3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 设置ToolStripMenuItem;
        private ToolStripMenuItem 显示ToolStripMenuItem;
        private ToolStripMenuItem 退出ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem 发送图片ToolStripMenuItem;
        private ToolStripMenuItem 发送表情ToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private System.Windows.Forms.Timer timer1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabControl tabControl2;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TabControl tabControl3;
        private TabPage tabPage9;
        private TabPage tabPage10;
        private Label label2;
    }
}