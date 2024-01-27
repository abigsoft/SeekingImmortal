using Game.Service;
using Game;
using Game.Helper;
using Game.Manager;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.FrmUI
{
    public partial class FrmMain : Form
    {
        private string token = "";
        PostService http = new PostService();

        private int default_width = 0;
        private bool isCollapsed = false;
        private int collapsedWidth = 20;
        private string collapsedType = "";

        public FrmMain(string token = "")
        {
            InitializeComponent();
            this.default_width = this.Width;
            http.token = this.token = token;

        }

        private void SetupWebSocketEvents()
        {
            WebSocketManager.Instance.MessageReceived += Instance_OnMessageReceived;
            WebSocketManager.Instance.ErrorOccurred += Instance_OnErrorOccurred;
        }

        private async void InitSocket()
        {
            await WebSocketManager.Instance.ConnectAsync(ConfigModel.socket_url + "/?token=" + this.token);
        }

        private void Instance_OnErrorOccurred(Exception ex)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.InitSocket();
            });
        }

        private void Instance_OnMessageReceived(string message)
        {
            // 当WebSocket接收到消息时执行的代码，可能需要Invoke以更新UI
            if (InvokeRequired)
            {
                Invoke(new Action<string>(Instance_OnMessageReceived), message);
            }
            else
            {
                // 更新UI或者其他逻辑
                JToken json = JsonHelper.ExtractAll(message);
                switch (JTokenHelper.ToStr(json["type"]))
                {
                    case "system":
                        break;
                }
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            new FrmLoading(() =>
            {
                this.initAll();
            }, this);
        }

        private void initAll()
        {
            this.InitSocket();
            this.SetupWebSocketEvents();
        }

        bool is_mouse_move = false;
        Point oPointClicked; // 用于窗体移动

        private void AllMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && is_mouse_move)
            {
                //以当前鼠标位置为基础，找出目标位置
                Point oMoveToPoint = PointToScreen(new Point(e.X, e.Y));
                oMoveToPoint.Offset(oPointClicked.X * -1, (oPointClicked.Y + SystemInformation.CaptionHeight + SystemInformation.BorderSize.Height) * -1 + 24);
                Location = oMoveToPoint;
            }
        }

        private void AllMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                is_mouse_move = false;
            }
        }

        private void AllMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.is_mouse_move = true;
                oPointClicked = new Point(e.X, e.Y);
            }

        }

        private void AllMouseLeave(object? sender = null, EventArgs? e = null)
        {
            // 检查鼠标是否真的离开了窗体，而不是进入了某个子控件
            if (isCollapsed || this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
            {
                return;
            }
            // 窗体在屏幕左边或右边的边界
            WinformHelper.CalculateScreenWidth(out int minX, out int maxX);

            //向左折叠
            if (this.Location.X <= minX + this.collapsedWidth)
            {
                this.Left = 0;
                this.isCollapsed = true;
                this.collapsedType = "left";
            }
            else if (this.Location.X >= maxX - this.collapsedWidth - this.Width)
            {
                this.Location = new Point(maxX - 10, this.Location.Y);

                this.isCollapsed = true;
                this.collapsedType = "right";
            }

            if (this.isCollapsed)
            {
                this.TopMost = true;
                panel_collapsed.BackColor = SystemColors.ActiveCaption;
                this.Width = 10;
                this.panel_collapsed.Visible = true;
                this.panel_main.Visible = false;
            }

        }

        private async void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            await WebSocketManager.Instance.DisconnectAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel_collapsed_MouseEnter(object sender, EventArgs e)
        {
            if (!isCollapsed)
            {
                return;
            }
            WinformHelper.CalculateScreenWidth(out int minX, out int maxX);
            this.panel_collapsed.Visible = false;
            this.panel_main.Visible = true;
            switch (this.collapsedType)
            {
                case "left":
                    this.Width = this.default_width;
                    this.Location = new Point(minX, this.Location.Y);
                    break;
                case "right":
                    this.Width = this.default_width;
                    this.Location = new Point(maxX - this.default_width, this.Location.Y);
                    break;
                default:
                    this.Width = this.default_width;
                    break;
            }
            this.isCollapsed = false;
            this.TopMost = false;

        }

        private async void heart_jump_Tick(object sender, EventArgs e)
        {
            await WebSocketManager.Instance.SendMessageAsync("{\"type\":\"ping\"}");
            StrHelper.ClearMemory();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                sendMessage();
                e.Handled = true;
            }
        }

        private void sendMessage()
        {
            this.textBox1.Text = "";
            this.Focus();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            sendMessage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
            this.WindowState = FormWindowState.Normal;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isCollapsed && !this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
            {
                AllMouseLeave();
            }
        }
    }
}
