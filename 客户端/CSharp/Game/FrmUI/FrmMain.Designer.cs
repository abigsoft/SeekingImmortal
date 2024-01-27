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
            button3 = new Button();
            button1 = new Button();
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
            contextMenuStrip2 = new ContextMenuStrip(components);
            发送图片ToolStripMenuItem = new ToolStripMenuItem();
            发送表情ToolStripMenuItem = new ToolStripMenuItem();
            panel_main.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // panel_collapsed
            // 
            panel_collapsed.BackColor = SystemColors.ActiveCaption;
            panel_collapsed.Location = new Point(0, 0);
            panel_collapsed.Name = "panel_collapsed";
            panel_collapsed.Size = new Size(10, 450);
            panel_collapsed.TabIndex = 0;
            panel_collapsed.Visible = false;
            panel_collapsed.MouseEnter += panel_collapsed_MouseEnter;
            // 
            // panel_main
            // 
            panel_main.BorderStyle = BorderStyle.FixedSingle;
            panel_main.Controls.Add(button3);
            panel_main.Controls.Add(button1);
            panel_main.Controls.Add(textBox1);
            panel_main.Controls.Add(button2);
            panel_main.Controls.Add(label1);
            panel_main.Location = new Point(0, 0);
            panel_main.Name = "panel_main";
            panel_main.Size = new Size(800, 450);
            panel_main.TabIndex = 1;
            panel_main.MouseDown += AllMouseDown;
            panel_main.MouseLeave += AllMouseLeave;
            panel_main.MouseMove += AllMouseMove;
            panel_main.MouseUp += AllMouseUp;
            // 
            // button3
            // 
            button3.Font = new Font("微软雅黑", 5.25F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(730, 20);
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
            button1.Location = new Point(705, 405);
            button1.Name = "button1";
            button1.Size = new Size(75, 27);
            button1.TabIndex = 6;
            button1.Text = "发送";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("文道粗楷体", 10.4999981F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(19, 405);
            textBox1.MaxLength = 30;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "在这里输入发送的消息";
            textBox1.Size = new Size(671, 26);
            textBox1.TabIndex = 5;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // button2
            // 
            button2.Font = new Font("微软雅黑", 5.25F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(756, 20);
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
            label1.Location = new Point(19, 20);
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
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { 发送图片ToolStripMenuItem, 发送表情ToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(125, 48);
            // 
            // 发送图片ToolStripMenuItem
            // 
            发送图片ToolStripMenuItem.Name = "发送图片ToolStripMenuItem";
            发送图片ToolStripMenuItem.Size = new Size(180, 22);
            发送图片ToolStripMenuItem.Text = "发送图片";
            // 
            // 发送表情ToolStripMenuItem
            // 
            发送表情ToolStripMenuItem.Name = "发送表情ToolStripMenuItem";
            发送表情ToolStripMenuItem.Size = new Size(180, 22);
            发送表情ToolStripMenuItem.Text = "发送表情";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            contextMenuStrip1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
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
    }
}