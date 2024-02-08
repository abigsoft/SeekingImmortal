using Game.Entity;
using Game.Helper;
using Game.Service;
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
using static System.Net.WebRequestMethods;

namespace Game.FrmUI
{
    public partial class FrmSetting : Form
    {
        PostService http = new PostService();
        public SystemSetting system_setting = new SystemSetting();
        public bool Reset = false;
        MemberEntity member_info = new MemberEntity();
        public FrmSetting(MemberEntity member_info, PostService http, SystemSetting system_setting)
        {
            InitializeComponent();
            this.http = http;
            this.system_setting = system_setting;
            this.member_info = member_info;
        }
        JToken? select_title_list;
        private async void FrmSetting_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = member_info.Nickname;
            this.checkBox1.Checked = system_setting.isMute;
            this.checkBox2.Checked = system_setting.isAutoRefresh;
            this.checkBox3.Checked = system_setting.isAutoCollapsed;
            this.checkBox4.Checked = system_setting.isSystemLogToWorld;

            this.textBox6.Text = system_setting.worldColor.title_str;
            this.textBox3.Text = system_setting.worldColor.message_color;
            this.textBox4.Text = system_setting.worldColor.title_color;
            this.textBox5.Text = system_setting.worldColor.friends_color;

            ResultEntity result = await http.apiGet("member/info/title");
            if (result.getStatus() != 200)
            {
                MessageBox.Show(result.getMsg());
                return;
            }
            comboBox1.Items.Clear();
            comboBox1.Items.Add("无称号");
            select_title_list = result.getData();
            int select_title_id = 0;
            int select_title_index = 0;

            foreach (JToken item in select_title_list)
            {
                comboBox1.Items.Add(JTokenHelper.ToStr(item["title"]));
                if (JTokenHelper.ToInt(item["id"]) == member_info.MaskTitleId)
                {
                    select_title_id = select_title_index + 1;
                }
                select_title_index++;
            }
            comboBox1.SelectedIndex = select_title_id;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("道号不能为空");
                return;
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("nickname", textBox1.Text);
            ResultEntity result = await http.apiPost("member/info/nickname", dic);
            MessageBox.Show(result.getMsg());
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("新密码不能为空");
                return;
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("password", textBox2.Text);
            ResultEntity result = await http.apiPost("member/info/password", dic);
            MessageBox.Show(result.getMsg());
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            if (select_title_list == null)
            {
                return;
            }
            string id = "0";
            if (comboBox1.SelectedIndex > 0)
            {
                id = JTokenHelper.ToStrN(select_title_list[comboBox1.SelectedIndex - 1], "id");
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("id", id);
            ResultEntity result = await http.apiPost("member/info/title", dic);
            MessageBox.Show(result.getMsg());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            IniHelper.Instance.WriteInteger("Setting", "isMute", checkBox1.Checked ? 1 : 0);
            IniHelper.Instance.WriteInteger("Setting", "isAutoRefresh", checkBox2.Checked ? 1 : 0);
            IniHelper.Instance.WriteInteger("Setting", "isAutoCollapsed", checkBox3.Checked ? 1 : 0);
            IniHelper.Instance.WriteInteger("Setting", "isSystemLogToWorld", checkBox4.Checked ? 1 : 0);
            this.Reset = true;
            this.Close();
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // 确保索引有效
            if (e.Index < 0) return;

            // 获取项文本
            string text = comboBox1.Items[e.Index].ToString();

            // 获取ComboBox的图形上下文
            Graphics g = e.Graphics;

            // 设置文本格式
            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center; // 垂直居中
            stringFormat.Alignment = StringAlignment.Center; // 水平居中

            // 设置文本颜色和背景
            Brush brush;
            Brush backgroundColor;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                // 如何项被选中，设置高亮颜色
                brush = SystemBrushes.HighlightText;
                backgroundColor = SystemBrushes.Highlight;
            }
            else
            {
                // 未选中项的颜色
                brush = SystemBrushes.WindowText;
                backgroundColor = SystemBrushes.Window;
            }

            // 填充背景
            g.FillRectangle(backgroundColor, e.Bounds);

            // 绘制文本
            g.DrawString(text, e.Font, brush, e.Bounds, stringFormat);
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth = (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                                     ? SystemInformation.VerticalScrollBarWidth : 0;

            // 计算最长项的宽度
            var itemsWidth = senderComboBox.Items.Cast<object>().Select(obj => g.MeasureString(obj.ToString(), font).Width).ToList();
            float newWidth = (itemsWidth.Count > 0 ? itemsWidth.Max() : 0) + vertScrollBarWidth;

            // 如果最长项宽度大于当前下拉列表宽度，则更新它
            if (width < newWidth)
            {
                senderComboBox.DropDownWidth = (int)newWidth;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UtilService.openUlr("https://www.sioe.cn/yingyong/yanse-rgb-16/");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            IniHelper.Instance.WriteString("Setting", "WorldTitleStr", textBox6.Text.Trim());
            IniHelper.Instance.WriteString("Setting", "WorldMessageColor", textBox3.Text.Trim());
            IniHelper.Instance.WriteString("Setting", "WorldTitleColor", textBox4.Text.Trim());
            IniHelper.Instance.WriteString("Setting", "WorldFriendsColor", textBox5.Text.Trim());
            this.Reset = true;
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.textBox6.Text = system_setting.worldColor.title_str;
            this.textBox3.Text = system_setting.worldColor.message_color;
            this.textBox4.Text = system_setting.worldColor.title_color;
            this.textBox5.Text = system_setting.worldColor.friends_color;
        }
    }
}
