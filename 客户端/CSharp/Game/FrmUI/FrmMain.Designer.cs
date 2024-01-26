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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            panel_collapsed = new Panel();
            panel_main = new Panel();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            panel_main.SuspendLayout();
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
            panel_main.Controls.Add(button1);
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
            // button1
            // 
            button1.Font = new Font("微软雅黑", 5.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(730, 20);
            button1.Name = "button1";
            button1.Size = new Size(20, 20);
            button1.TabIndex = 3;
            button1.TabStop = false;
            button1.Text = "—";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_collapsed;
        private Panel panel_main;
        private Label label1;
        private Button button1;
        private Button button2;
    }
}