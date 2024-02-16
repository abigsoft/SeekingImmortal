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
    public partial class FrmMemberPackage : Form
    {
        PostService http = new PostService();
        public FrmMemberPackage(PostService http)
        {
            InitializeComponent();
            this.http = http;
        }

        private void FrmMemberPackage_Load(object sender, EventArgs e)
        {

        }
    }
}
