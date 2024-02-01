using Game.Entity;
using Game.Service;
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

        }
    }
}
