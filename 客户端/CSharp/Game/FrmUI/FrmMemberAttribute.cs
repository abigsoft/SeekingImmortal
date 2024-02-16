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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Game.FrmUI
{
    public partial class FrmMemberAttribute : Form
    {
        PostService http = new PostService();
        MemberEntity member_info = new MemberEntity();
        public FrmMemberAttribute(MemberEntity member_info, PostService http)
        {
            InitializeComponent();
            this.http = http;
            this.member_info = member_info;
        }

        private void FrmMemberAttribute_Load(object sender, EventArgs e)
        {
            label14.Text = member_info.DataDot.ToString();
            label34.Text = member_info.WorldBloodMax.ToString();
            label16.Text = member_info.WorldAttackPhysics.ToString();
            label18.Text = member_info.WorldAttackMagic.ToString();
            label20.Text = member_info.WorldDefensePhysics.ToString();
            label22.Text = member_info.WorldDefenseMagic.ToString();
            this.initJob();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("暂未开放");
        }

        private async void initJob()
        {
            ResultEntity result = await http.apiPost("member/dot/get");
            if (result.getStatus() != 200)
            {
                MessageBox.Show(result.getMsg());
                return;
            }
            button1.Enabled = button2.Enabled =
                button3.Enabled = button4.Enabled =
                button5.Enabled = button6.Enabled =
                button7.Enabled = button8.Enabled =
                button9.Enabled = button10.Enabled =
                button11.Enabled = button12.Enabled =
                button13.Enabled = false;
            JToken job = JTokenHelper.ToJToken(result.getData(), "job");
            if (JTokenHelper.ToStrN(job, "start", "0") == "0")
            {
                button1.Enabled = true;
            }
            else
            {
                if (JTokenHelper.ToStrN(job, "way.assassin.first", "0") == "0")
                {
                    button2.Enabled = true;
                }
                else
                {
                    if (JTokenHelper.ToStrN(job, "way.assassin.second", "0") == "0")
                    {
                        button5.Enabled = true;
                    }
                    else
                    {
                        if (JTokenHelper.ToStrN(job, "way.assassin.third", "0") == "0")
                        {
                            button10.Enabled = true;
                        }
                        else
                        {
                            button13.Enabled = true;
                            label1.Text = "+ " + JTokenHelper.ToStrN(job, "way.assassin.level", "0");
                        }
                    }
                }

                if (JTokenHelper.ToStrN(job, "way.soldier.first", "0") == "0")
                {
                    button3.Enabled = true;
                }
                else
                {
                    if (JTokenHelper.ToStrN(job, "way.soldier.second", "0") == "0")
                    {
                        button6.Enabled = true;
                    }
                    else
                    {
                        if (JTokenHelper.ToStrN(job, "way.soldier.third", "0") == "0")
                        {
                            button9.Enabled = true;
                        }
                        else
                        {
                            button12.Enabled = true;
                            label2.Text = "+ " + JTokenHelper.ToStrN(job, "way.soldier.level", "0");
                        }
                    }
                }

                if (JTokenHelper.ToStrN(job, "way.auxiliary.first", "0") == "0")
                {
                    button4.Enabled = true;
                }
                else
                {
                    if (JTokenHelper.ToStrN(job, "way.auxiliary.second", "0") == "0")
                    {
                        button7.Enabled = true;
                    }
                    else
                    {
                        if (JTokenHelper.ToStrN(job, "way.auxiliary.third", "0") == "0")
                        {
                            button8.Enabled = true;
                        }
                        else
                        {
                            button11.Enabled = true;
                            label3.Text = "+ " + JTokenHelper.ToStrN(job, "way.auxiliary.level", "0");
                        }
                    }
                }
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addCommon("blood", 1);
        }



        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addCommon("blood", 10);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addCommon("blood", 100);
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addCommon("attack_physics", 1);
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addCommon("attack_physics", 10);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addCommon("attack_physics", 100);
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addCommon("attack_magic", 1);
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addCommon("attack_magic", 10);
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addCommon("attack_magic", 100);
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addCommon("defense_physics", 1);
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addCommon("defense_physics", 10);
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addCommon("defense_physics", 100);
        }

        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addCommon("defense_magic", 1);
        }

        private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addCommon("defense_magic", 10);
        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addCommon("defense_magic", 100);
        }

        private async void addCommon(string type = "", int number = 1)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("type", type);
            dic.Add("number", number.ToString());
            ResultEntity result = await http.apiPost("member/dot/common", dic);
            MessageBox.Show(result.getMsg());
        }

        private async void addJob(int row = 0, int col = 0)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("row", row.ToString());
            dic.Add("col", col.ToString());
            ResultEntity result = await http.apiPost("member/dot/job", dic);
            MessageBox.Show(result.getMsg());
            initJob();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addJob(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addJob(1, 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addJob(2, 1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            addJob(3, 1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            addJob(4, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addJob(1, 2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addJob(2, 2);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            addJob(3, 2);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            addJob(4, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addJob(1, 3);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            addJob(2, 3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            addJob(3, 3);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            addJob(4, 3);
        }
    }
}
