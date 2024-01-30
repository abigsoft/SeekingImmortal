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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Game.FrmUI
{
    public partial class FrmSetting : Form
    {
        PostService http = new PostService();
        public FrmSetting(PostService http)
        {
            InitializeComponent();
            this.http = http;
        }
        JToken select_title_list;
        private async void FrmSetting_Load(object sender, EventArgs e)
        {
            ResultEntity result = await http.apiGet("member/info/title");
            if (result.getStatus() != 200)
            {
                MessageBox.Show(result.getMsg());
                return;
            }
            comboBox1.Items.Clear();
            comboBox1.Items.Add("无称号");
            select_title_list = result.getData();
            foreach (JToken item in select_title_list)
            {
                comboBox1.Items.Add(JTokenHelper.ToStr(item["title"]));
            }
            comboBox1.SelectedIndex = 0;
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
    }
}
