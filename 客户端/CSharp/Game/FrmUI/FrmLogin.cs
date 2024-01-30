using Game.Entity;
using Game.Helper;
using Game.Service;

namespace Game.FrmUI
{
    public partial class FrmLogin : Form
    {
        private string token = "";
        private string password = "";
        PostService http = new PostService();
        public FrmLogin()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.init();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        public string getToken()
        {
            return token;
        }

        public string getPassword()
        {
            return password;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UtilService.openUlr("https://github.com/abigsoft/ChildrenOnline");
        }

        private void init()
        {
            IniHelper.Instance.FileName = "conf/config.ini";
            textBox1.Text = IniHelper.Instance.ReadString("Account", "Account", "");
            textBox2.Text = IniHelper.Instance.ReadString("Account", "Password", "");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            _ = doLoginAsync();
        }

        private async Task doLoginAsync()
        {
            String account = textBox1.Text;
            String password = textBox2.Text;
            if (account == "" || password == "")
            {
                MessageBox.Show("账号密码不能为空");
                return;
            }

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("account", account);
            dic.Add("password", password);
            ResultEntity result = await http.apiPost("login/account", dic);

            if (result.getStatus() != 200)
            {
                MessageBox.Show(result.getMsg());
                return;
            }
            IniHelper.Instance.WriteString("Account", "Account", account);
            IniHelper.Instance.WriteString("Account", "Password", password);

            this.token = JTokenHelper.ToStr(result.getData());
            this.password = password;
            this.Close();
        }

        private async void doRegister()
        {
            String account = textBox3.Text;
            String password = textBox4.Text;
            String name = textBox5.Text;
            int sex = radioButton1.Checked ? 1 : 2;
            if (account == "" || password == "" || name == "")
            {
                MessageBox.Show("请将表单填写完毕");
                return;
            }

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("account", account);
            dic.Add("password", password);
            dic.Add("nickname", name);
            dic.Add("sex", sex.ToString());
            ResultEntity result = await http.apiPost("register/account", dic);
            MessageBox.Show(result.getMsg());
            if (result.getStatus() != 200)
            {
                return;
            }
            textBox1.Text = account;
            textBox2.Text = password;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                doLoginAsync();
                //e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            steamLogin();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            doRegister();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBox2.Focus();
                //e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            steamLogin();
        }

        private void steamLogin()
        {
            /**
            byte[] ticket = new byte[1024]; // 票据的缓冲区大小
            uint ticketSize = 0;
            HAuthTicket hAuthTicket = SteamUser.GetAuthSessionTicket(ticket, ticket.Length, out ticketSize);
            if (hAuthTicket != HAuthTicket.Invalid)
            {
                // 票据已经成功生成，ticket数组中的前ticketSize个字节是有效的票据数据
                byte[] actualTicket = new byte[ticketSize];
                Array.Copy(ticket, actualTicket, ticketSize);

                // 将actualTicket发送到服务器进行验证
            }
            else
            {
                // 票据生成失败
            }**/
        }
    }
}
