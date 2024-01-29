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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Game.Entity;
using Newtonsoft.Json;
using System.Resources;
using Game.Assembly;

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
                switch (JTokenHelper.ToStrN(json, "type"))
                {
                    case "system":
                        if (JTokenHelper.ToStrN(json, "data.type") == "system")
                        {
                            if (JTokenHelper.ToStrN(json, "data.data") == "close")
                            {
                                this.Close();
                            }
                        }
                        if (JTokenHelper.ToStrN(json, "data.type") == "init")
                        {
                            if (JTokenHelper.ToStrN(json, "data.data") == "user")
                            {
                                this.initUser();
                            }
                        }
                        if (JTokenHelper.ToStrN(json, "data.type") == "clear")
                        {
                            if (JTokenHelper.ToStrN(json, "data.data") == "world")
                            {
                                dataGridView1.Rows.Clear();
                                this.previouslySelectedRowIndex = -1;
                                addSystemLog("管理员开启了清屏");
                            }
                            if (JTokenHelper.ToStrN(json, "data.data") == "hearsay")
                            {
                                listView1.Items.Clear();
                                addSystemLog("管理员开启了清屏");
                            }
                        }
                        if (JTokenHelper.ToStrN(json, "data.type") == "message")
                        {
                            label2.Text = JTokenHelper.ToStrN(json, "data.data");
                        }
                        break;
                    case "statistics":
                        break;
                    case "world":
                        dealWorldMessage(JsonConvert.DeserializeObject<WorldMessageEntity>(json["data"].ToString()));
                        break;
                }
            }
        }
        int previouslySelectedRowIndex = -1;
        private void dealWorldMessage(WorldMessageEntity? message)
        {
            if (message.Channel == "world")
            {
                if (message.Data.Id == 0)
                {
                    int rowIndex = 0;
                    if (message.Data.Message.Content.Type == "text")
                    {
                        rowIndex = dataGridView1.Rows.Add(
                            message.Data.Message.Id,
                            "[" + message.Data.Message.From.Title + "]",
                            message.Data.Message.From.Name,
                            message.Data.Message.Content.Data,
                            message.Data.Message.Time
                        );
                    }
                    else if (message.Data.Message.Content.Type == "emoji")
                    {
                        Image smileyImage = Properties.Resources.ResourceManager.GetObject(message.Data.Message.Content.Data) as Image;
                        //TextAndImageCell textAndImageCell = new TextAndImageCell();
                        //textAndImageCell.Image = smileyImage;

                        rowIndex = dataGridView1.Rows.Add(
                            message.Data.Message.Id,
                            "[" + message.Data.Message.From.Title + "]",
                            message.Data.Message.From.Name,
                            "",
                            message.Data.Message.Time
                        );
                        ((TextAndImageCell)dataGridView1.Rows[rowIndex].Cells[3]).Image = smileyImage;
                    }
                    else
                    {
                        return;
                    }

                    //判断有没有艾特
                    if ((message.Data.Message.From.Uid != member_info.Uid) && ((message.Data.Message.Content.Data.IndexOf("@所有人") > -1 && message.Data.Message.From.Uid == "administrator") || message.Data.Message.Content.Data.IndexOf("@" + member_info.Nickname + "") > -1))
                    {
                        ListViewItem hearsay_item = new ListViewItem(new string[] {
                        "有人艾特你了",
                        DateTime.Now.ToString("HH:mm:ss"),
                        message.Data.Message.Id.ToString(),
                        "at",
                        rowIndex.ToString()
                    });

                        hearsay_item.UseItemStyleForSubItems = false;
                        hearsay_item.SubItems[0].ForeColor = hearsay_item.SubItems[1].ForeColor = StrHelper.HexToColor("#6495ED");
                        listView1.Items.Add(hearsay_item);
                        this.listView1.Items[this.listView1.Items.Count - 1].EnsureVisible();
                    }


                    if (message.Data.Message.Color.Title != "#000000")
                    {
                        dataGridView1.Rows[rowIndex].Cells["Column2"].Style.ForeColor = StrHelper.HexToColor(message.Data.Message.Color.Title);
                    }
                    if (message.Data.Message.Color.Title != "#000000")
                    {
                        dataGridView1.Rows[rowIndex].Cells["Column3"].Style.ForeColor = StrHelper.HexToColor(message.Data.Message.Color.Name);
                    }
                    if (message.Data.Message.Color.Title != "#000000")
                    {
                        dataGridView1.Rows[rowIndex].Cells["Column4"].Style.ForeColor = StrHelper.HexToColor(message.Data.Message.Color.Message);
                    }
                    if (message.Data.Message.Color.Title != "#000000")
                    {
                        dataGridView1.Rows[rowIndex].Cells["Column6"].Style.ForeColor = StrHelper.HexToColor(message.Data.Message.Color.Time);
                    }

                    if (dataGridView1.Rows.Count == 1)
                    {
                        dataGridView1.ClearSelection();
                    }

                    if (this.自动滚动ToolStripMenuItem.Checked && dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                    }

                    if (message.Data.Notice == 1)
                    {
                        notifyIcon1.BalloonTipText = message.Data.Message.Content.Data;
                        notifyIcon1.BalloonTipTitle = "系统消息";
                        notifyIcon1.ShowBalloonTip(1000);
                        addSystemLog("系统消息：" + message.Data.Message.Content.Data);
                    }
                    panel_collapsed.BackColor = System.Drawing.Color.DarkViolet;
                }
            }
            else if (message.Channel == "cancel")
            {
                if (message.Data.Id == 0)
                {
                    for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                    {
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) > 0 && Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) < message.Data.Message.Id)
                        {
                            break;
                        }
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == message.Data.Message.Id.ToString())
                        {
                            DataGridViewRow select_row = dataGridView1.Rows[i];
                            dataGridView1.Rows.Remove(select_row);
                            break;
                        }
                    }
                }

            }
        }

        private void addSystemLog(string message, bool jump = true)
        {
            this.BeginInvoke(new Action(() =>
            {
                dataGridView2.Rows.Add(message, DateTime.Now.ToString("HH:mm:ss"));
                if (dataGridView2.Rows.Count > 0)
                {
                    dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView2.Rows.Count - 1;
                }
            }));

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            new FrmLoading(() =>
            {
                this.initAll();
            }, this);
        }
        MemberEntity member_info = new MemberEntity();
        private void initUser()
        {
            this.BeginInvoke(new Action(() =>
            {
                ResultEntity result = http.apiPost("member/info/info");
                if (result.getStatus() != 200)
                {
                    MessageBox.Show(result.getMsg());
                    return;
                }
                this.member_info = JsonConvert.DeserializeObject<MemberEntity>(result.toString());
                if (this.member_info == null)
                {
                    MessageBox.Show(result.getMsg());
                    return;
                }
                this.notifyIcon1.Text = label1.Text = "寻仙：" + member_info.Nickname;
                this.label8.Text = member_info.LevelTitle;
                this.label9.Text = member_info.DataExp.ToString();
                this.label10.Text = member_info.DataGoldCoin.ToString();
                this.label11.Text = member_info.DataSpiritStone.ToString();
                this.label36.Text = member_info.DataFortune.ToString();
                this.label14.Text = member_info.DataPhysical.ToString() + " / " + member_info.DataPhysicalMax.ToString();
                this.label34.Text = member_info.WorldBlood.ToString();
                this.label27.Text = member_info.DataInsight.ToString();
                this.label16.Text = member_info.WorldAttackPhysics.ToString();
                this.label18.Text = member_info.WorldAttackMagic.ToString();
                this.label20.Text = member_info.WorldDefensePhysics.ToString();
                this.label22.Text = member_info.WorldDefenseMagic.ToString();
                this.label24.Text = member_info.WorldSpeed.ToString();
                this.label26.Text = (member_info.WorldCriticalRate * 100).ToString() + "%";
                this.label7.Text = (member_info.WorldCriticalData * 100).ToString() + "%";
                this.label30.Text = (member_info.WorldSure * 100).ToString() + "%";
                this.label32.Text = (member_info.WorldEvade * 100).ToString() + "%";
            }));
        }

        private void initAll()
        {
            this.InitSocket();
            this.SetupWebSocketEvents();
            this.initUser();
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
            if (textBox1.Text == "")
            {
                return;
            }
            this.BeginInvoke(new Action(() =>
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("message", textBox1.Text);
                ResultEntity result = new ResultEntity();
                result = http.apiPost("message/world", dic);
                if (result.getStatus() != 200)
                {
                    MessageBox.Show(result.getMsg());
                    return;
                }
                this.textBox1.Text = "";
                this.Focus();
            }));

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

        private void button4_Click(object sender, EventArgs e)
        {
            WinformHelper.Open<FrmSetting>();
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WinformHelper.Open<FrmSetting>();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                return;
            }
            if (this.previouslySelectedRowIndex >= 0)
            {
                this.previouslySelectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            }

        }

        private void 快速艾特ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                textBox1.Text += "@" + selectedRow.Cells["Column3"].Value.ToString() + " ";
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // 检查是否是右键点击
            if (e.Button == MouseButtons.Right)
            {
                // 确保点击的是行头或单元格，而不是列头或行外的位置
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    // 选中当前右键点击的行
                    dataGridView1.Rows[e.RowIndex].Selected = true;

                }
            }
        }

        private void dataGridView2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // 检查是否是右键点击
            if (e.Button == MouseButtons.Right)
            {
                // 确保点击的是行头或单元格，而不是列头或行外的位置
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    // 选中当前右键点击的行
                    dataGridView2.Rows[e.RowIndex].Selected = true;

                }
            }
        }

        private void 复制消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                if (!string.IsNullOrEmpty(selectedRow.Cells["Column4"].Value.ToString()))
                {
                    Clipboard.SetText(selectedRow.Cells["Column4"].Value.ToString());
                }

            }
        }

        private void 清空聊天ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            this.previouslySelectedRowIndex = -1;
        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.FocusedItem == null)
            {
                return;
            }
            string message = listView1.FocusedItem.SubItems[0].Text;
            string id = listView1.FocusedItem.SubItems[2].Text;
            string type = listView1.FocusedItem.SubItems[3].Text;
            string data = listView1.FocusedItem.SubItems[4].Text;

            switch (type)
            {
                case "apply":
                    tabControl1.SelectedIndex = 0;
                    break;
                case "show":
                    MessageBox.Show(data, message);
                    break;
                case "at":
                    for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                    {
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) > 0 && Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) < Convert.ToInt32(id))
                        {
                            break;
                        }
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == id)
                        {
                            DataGridViewRow select_row = dataGridView1.Rows[i];
                            自动滚动ToolStripMenuItem.Checked = false;
                            select_row.Selected = true;
                            dataGridView1.FirstDisplayedScrollingRowIndex = select_row.Index;
                            break;
                        }
                    }
                    break;
                default:
                    MessageBox.Show(data, message);
                    break;
            }
        }

        private void 复制消息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                Clipboard.SetText(selectedRow.Cells["dataGridViewTextBoxColumn4"].Value.ToString());
            }
        }

        private void 清空列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
        }

        private void 发送表情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmoji frm = new FrmEmoji();
            frm.ShowDialog();
            if (frm.getSelect != "")
            {
                this.BeginInvoke(new Action(() =>
                {
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add("message", frm.getSelect);
                    dic.Add("type", "emoji");
                    ResultEntity result = new ResultEntity();
                    result = http.apiPost("message/world", dic);
                    if (result.getStatus() != 200)
                    {
                        MessageBox.Show(result.getMsg());
                        return;
                    }
                    this.Focus();
                }));
            }
        }

        private void 撤销消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                if (!string.IsNullOrEmpty(selectedRow.Cells["Column1"].Value.ToString()))
                {
                    string? message_id = selectedRow.Cells["Column1"].Value.ToString();
                    if (message_id != null)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            Dictionary<string, string> dic = new Dictionary<string, string>();
                            dic.Add("message_id", message_id);
                            ResultEntity result = new ResultEntity();
                            result = http.apiPost("message/cancel", dic);
                            addSystemLog(result.getMsg(), false);
                            if (result.getStatus() == 200 && textBox1.Text == "")
                            {
                                textBox1.Text = JTokenHelper.ToStr(result.getData());
                            }
                        }));
                    }
                }

            }
        }
    }
}
