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
            button4 = new Button();
            label2 = new Label();
            tabControl3 = new TabControl();
            tabPage9 = new TabPage();
            listView1 = new ListView();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            tabPage10 = new TabPage();
            listView2 = new ListView();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            tabControl2 = new TabControl();
            tabPage7 = new TabPage();
            button5 = new Button();
            dataGridView1 = new DataGridView();
            tabPage8 = new TabPage();
            button6 = new Button();
            dataGridView2 = new DataGridView();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox2 = new GroupBox();
            label27 = new Label();
            label28 = new Label();
            label7 = new Label();
            label3 = new Label();
            label34 = new Label();
            label33 = new Label();
            label32 = new Label();
            label31 = new Label();
            label30 = new Label();
            label29 = new Label();
            label26 = new Label();
            label15 = new Label();
            label25 = new Label();
            label16 = new Label();
            label24 = new Label();
            label17 = new Label();
            label23 = new Label();
            label18 = new Label();
            label22 = new Label();
            label19 = new Label();
            label21 = new Label();
            label20 = new Label();
            groupBox1 = new GroupBox();
            label11 = new Label();
            label12 = new Label();
            label14 = new Label();
            label36 = new Label();
            label13 = new Label();
            label10 = new Label();
            label35 = new Label();
            label9 = new Label();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            tabPage11 = new TabPage();
            tabPage4 = new TabPage();
            tabPage3 = new TabPage();
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
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            panel_main.SuspendLayout();
            tabControl3.SuspendLayout();
            tabPage9.SuspendLayout();
            tabPage10.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel_collapsed
            // 
            panel_collapsed.BackColor = SystemColors.ActiveCaption;
            panel_collapsed.Location = new Point(0, 0);
            panel_collapsed.Name = "panel_collapsed";
            panel_collapsed.Size = new Size(10, 620);
            panel_collapsed.TabIndex = 0;
            panel_collapsed.Visible = false;
            panel_collapsed.MouseEnter += panel_collapsed_MouseEnter;
            // 
            // panel_main
            // 
            panel_main.BorderStyle = BorderStyle.FixedSingle;
            panel_main.Controls.Add(button4);
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
            panel_main.Size = new Size(800, 620);
            panel_main.TabIndex = 1;
            panel_main.MouseDown += AllMouseDown;
            panel_main.MouseMove += AllMouseMove;
            panel_main.MouseUp += AllMouseUp;
            // 
            // button4
            // 
            button4.BackgroundImage = Properties.Resources.setting;
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.Font = new Font("微软雅黑", 5.25F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(711, 11);
            button4.Name = "button4";
            button4.Size = new Size(20, 20);
            button4.TabIndex = 12;
            button4.TabStop = false;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.AppWorkspace;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(13, 327);
            label2.Name = "label2";
            label2.Size = new Size(774, 23);
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
            tabControl3.Size = new Size(191, 283);
            tabControl3.SizeMode = TabSizeMode.Fixed;
            tabControl3.TabIndex = 10;
            // 
            // tabPage9
            // 
            tabPage9.Controls.Add(listView1);
            tabPage9.Location = new Point(4, 26);
            tabPage9.Name = "tabPage9";
            tabPage9.Padding = new Padding(3);
            tabPage9.Size = new Size(183, 253);
            tabPage9.TabIndex = 0;
            tabPage9.Text = "小道消息";
            tabPage9.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader4, columnHeader5, columnHeader1, columnHeader2, columnHeader3 });
            listView1.GridLines = true;
            listView1.Location = new Point(3, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(177, 247);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "消息";
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "时间";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "类型";
            columnHeader2.Width = 0;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "参数";
            columnHeader3.Width = 0;
            // 
            // tabPage10
            // 
            tabPage10.Controls.Add(listView2);
            tabPage10.Location = new Point(4, 26);
            tabPage10.Name = "tabPage10";
            tabPage10.Padding = new Padding(3);
            tabPage10.Size = new Size(183, 253);
            tabPage10.TabIndex = 1;
            tabPage10.Text = "系统公告";
            tabPage10.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
            listView2.GridLines = true;
            listView2.Location = new Point(3, 3);
            listView2.Name = "listView2";
            listView2.Size = new Size(177, 247);
            listView2.TabIndex = 1;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader6
            // 
            columnHeader6.DisplayIndex = 3;
            columnHeader6.Text = "标题";
            columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            columnHeader7.DisplayIndex = 4;
            columnHeader7.Text = "时间";
            columnHeader7.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader8
            // 
            columnHeader8.DisplayIndex = 0;
            columnHeader8.Text = "ID";
            columnHeader8.Width = 0;
            // 
            // columnHeader9
            // 
            columnHeader9.DisplayIndex = 1;
            columnHeader9.Text = "类型";
            columnHeader9.Width = 0;
            // 
            // columnHeader10
            // 
            columnHeader10.DisplayIndex = 2;
            columnHeader10.Text = "参数";
            columnHeader10.Width = 0;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage7);
            tabControl2.Controls.Add(tabPage8);
            tabControl2.Location = new Point(12, 356);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(777, 220);
            tabControl2.SizeMode = TabSizeMode.Fixed;
            tabControl2.TabIndex = 9;
            // 
            // tabPage7
            // 
            tabPage7.Controls.Add(button5);
            tabPage7.Controls.Add(dataGridView1);
            tabPage7.Location = new Point(4, 26);
            tabPage7.Name = "tabPage7";
            tabPage7.Padding = new Padding(3);
            tabPage7.Size = new Size(769, 190);
            tabPage7.TabIndex = 0;
            tabPage7.Text = "世界聊天";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(666, 161);
            button5.Name = "button5";
            button5.Size = new Size(97, 23);
            button5.TabIndex = 3;
            button5.Text = "滑动到最底部";
            button5.UseVisualStyleBackColor = true;
            button5.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column6, Column7 });
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(3, 4);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ShowCellErrors = false;
            dataGridView1.ShowEditingIcon = false;
            dataGridView1.ShowRowErrors = false;
            dataGridView1.Size = new Size(763, 183);
            dataGridView1.TabIndex = 0;
            dataGridView1.TabStop = false;
            // 
            // tabPage8
            // 
            tabPage8.Controls.Add(button6);
            tabPage8.Controls.Add(dataGridView2);
            tabPage8.Location = new Point(4, 26);
            tabPage8.Name = "tabPage8";
            tabPage8.Padding = new Padding(3);
            tabPage8.Size = new Size(769, 190);
            tabPage8.TabIndex = 1;
            tabPage8.Text = "系统通知";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(666, 161);
            button6.Name = "button6";
            button6.Size = new Size(97, 23);
            button6.TabIndex = 4;
            button6.Text = "滑动到最底部";
            button6.UseVisualStyleBackColor = true;
            button6.Visible = false;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.BackgroundColor = SystemColors.ButtonFace;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn6 });
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.Location = new Point(3, 4);
            dataGridView2.MultiSelect = false;
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.ShowCellErrors = false;
            dataGridView2.ShowEditingIcon = false;
            dataGridView2.ShowRowErrors = false;
            dataGridView2.Size = new Size(763, 183);
            dataGridView2.TabIndex = 1;
            dataGridView2.TabStop = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn4.HeaderText = "消息";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "时间";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            dataGridViewTextBoxColumn6.Width = 60;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Controls.Add(tabPage11);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.ItemSize = new Size(76, 22);
            tabControl1.Location = new Point(9, 41);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(581, 283);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(573, 253);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "信息";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label27);
            groupBox2.Controls.Add(label28);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label34);
            groupBox2.Controls.Add(label33);
            groupBox2.Controls.Add(label32);
            groupBox2.Controls.Add(label31);
            groupBox2.Controls.Add(label30);
            groupBox2.Controls.Add(label29);
            groupBox2.Controls.Add(label26);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(label25);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(label24);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(label23);
            groupBox2.Controls.Add(label18);
            groupBox2.Controls.Add(label22);
            groupBox2.Controls.Add(label19);
            groupBox2.Controls.Add(label21);
            groupBox2.Controls.Add(label20);
            groupBox2.Location = new Point(190, 18);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(291, 218);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "属性";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(208, 35);
            label27.Name = "label27";
            label27.Size = new Size(50, 17);
            label27.TabIndex = 35;
            label27.Text = "999999";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(158, 35);
            label28.Name = "label28";
            label28.Size = new Size(44, 17);
            label28.TabIndex = 34;
            label28.Text = "悟性：";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(208, 91);
            label7.Name = "label7";
            label7.Size = new Size(40, 17);
            label7.TabIndex = 33;
            label7.Text = "100%";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(158, 91);
            label3.Name = "label3";
            label3.Size = new Size(44, 17);
            label3.TabIndex = 32;
            label3.Text = "暴伤：";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(71, 35);
            label34.Name = "label34";
            label34.Size = new Size(50, 17);
            label34.TabIndex = 29;
            label34.Text = "999999";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(21, 35);
            label33.Name = "label33";
            label33.Size = new Size(44, 17);
            label33.TabIndex = 28;
            label33.Text = "血量：";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(208, 147);
            label32.Name = "label32";
            label32.Size = new Size(40, 17);
            label32.TabIndex = 27;
            label32.Text = "100%";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(158, 146);
            label31.Name = "label31";
            label31.Size = new Size(44, 17);
            label31.TabIndex = 26;
            label31.Text = "闪避：";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(208, 119);
            label30.Name = "label30";
            label30.Size = new Size(40, 17);
            label30.TabIndex = 25;
            label30.Text = "100%";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(158, 119);
            label29.Name = "label29";
            label29.Size = new Size(44, 17);
            label29.TabIndex = 24;
            label29.Text = "命中：";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(208, 63);
            label26.Name = "label26";
            label26.Size = new Size(40, 17);
            label26.TabIndex = 23;
            label26.Text = "100%";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(21, 63);
            label15.Name = "label15";
            label15.Size = new Size(44, 17);
            label15.TabIndex = 12;
            label15.Text = "物攻：";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(158, 63);
            label25.Name = "label25";
            label25.Size = new Size(44, 17);
            label25.TabIndex = 22;
            label25.Text = "暴击：";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(71, 63);
            label16.Name = "label16";
            label16.Size = new Size(50, 17);
            label16.TabIndex = 13;
            label16.Text = "999999";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(71, 175);
            label24.Name = "label24";
            label24.Size = new Size(50, 17);
            label24.TabIndex = 21;
            label24.Text = "999999";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(21, 91);
            label17.Name = "label17";
            label17.Size = new Size(44, 17);
            label17.TabIndex = 14;
            label17.Text = "法攻：";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(21, 175);
            label23.Name = "label23";
            label23.Size = new Size(44, 17);
            label23.TabIndex = 20;
            label23.Text = "敏捷：";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(71, 91);
            label18.Name = "label18";
            label18.Size = new Size(50, 17);
            label18.TabIndex = 15;
            label18.Text = "999999";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(71, 147);
            label22.Name = "label22";
            label22.Size = new Size(50, 17);
            label22.TabIndex = 19;
            label22.Text = "999999";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(21, 119);
            label19.Name = "label19";
            label19.Size = new Size(44, 17);
            label19.TabIndex = 16;
            label19.Text = "物防：";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(21, 147);
            label21.Name = "label21";
            label21.Size = new Size(44, 17);
            label21.TabIndex = 18;
            label21.Text = "法防：";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(71, 119);
            label20.Name = "label20";
            label20.Size = new Size(50, 17);
            label20.TabIndex = 17;
            label20.Text = "999999";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(label36);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label35);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(18, 18);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(166, 218);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "角色";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(73, 118);
            label11.Name = "label11";
            label11.Size = new Size(50, 17);
            label11.TabIndex = 9;
            label11.Text = "999999";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(23, 119);
            label12.Name = "label12";
            label12.Size = new Size(44, 17);
            label12.TabIndex = 8;
            label12.Text = "灵石：";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(73, 175);
            label14.Name = "label14";
            label14.Size = new Size(77, 17);
            label14.TabIndex = 11;
            label14.Text = "9999 / 9999";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(73, 147);
            label36.Name = "label36";
            label36.Size = new Size(32, 17);
            label36.TabIndex = 31;
            label36.Text = "正常";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(23, 175);
            label13.Name = "label13";
            label13.Size = new Size(44, 17);
            label13.TabIndex = 10;
            label13.Text = "体力：";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(73, 90);
            label10.Name = "label10";
            label10.Size = new Size(50, 17);
            label10.TabIndex = 7;
            label10.Text = "999999";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(23, 147);
            label35.Name = "label35";
            label35.Size = new Size(44, 17);
            label35.TabIndex = 30;
            label35.Text = "运势：";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(73, 63);
            label9.Name = "label9";
            label9.Size = new Size(50, 17);
            label9.TabIndex = 6;
            label9.Text = "999999";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(73, 35);
            label8.Name = "label8";
            label8.Size = new Size(44, 17);
            label8.TabIndex = 5;
            label8.Text = "凡人境";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 91);
            label6.Name = "label6";
            label6.Size = new Size(44, 17);
            label6.TabIndex = 3;
            label6.Text = "金币：";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 63);
            label5.Name = "label5";
            label5.Size = new Size(44, 17);
            label5.TabIndex = 2;
            label5.Text = "经验：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 35);
            label4.Name = "label4";
            label4.Size = new Size(44, 17);
            label4.TabIndex = 1;
            label4.Text = "境界：";
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 26);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(573, 253);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "家园";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Location = new Point(4, 26);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(573, 253);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "市场";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage11
            // 
            tabPage11.Location = new Point(4, 26);
            tabPage11.Name = "tabPage11";
            tabPage11.Padding = new Padding(3);
            tabPage11.Size = new Size(573, 253);
            tabPage11.TabIndex = 6;
            tabPage11.Text = "探索";
            tabPage11.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 26);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(573, 253);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "娱乐";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 26);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(573, 253);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "工具";
            tabPage3.UseVisualStyleBackColor = true;
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
            button1.Location = new Point(701, 582);
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
            textBox1.Location = new Point(13, 583);
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
            label1.Size = new Size(104, 17);
            label1.TabIndex = 0;
            label1.Text = "寻仙：这里是道号";
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
            设置ToolStripMenuItem.Click += 设置ToolStripMenuItem_Click;
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
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column1.HeaderText = "ID";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Visible = false;
            // 
            // Column2
            // 
            Column2.HeaderText = "称号";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 70;
            // 
            // Column3
            // 
            Column3.HeaderText = "道号";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.HeaderText = "消息";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.HeaderText = "时间";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 70;
            // 
            // Column7
            // 
            Column7.HeaderText = "事件";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Visible = false;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 620);
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
            tabPage9.ResumeLayout(false);
            tabPage10.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            contextMenuStrip2.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_collapsed;
        private Panel panel_main;
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
        private TabPage tabPage11;
        private Button button4;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ListView listView2;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private GroupBox groupBox1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private GroupBox groupBox2;
        private Button button5;
        private Button button6;
        private Label label29;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label1;
        private Label label3;
        private Label label7;
        private Label label27;
        private Label label28;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
    }
}