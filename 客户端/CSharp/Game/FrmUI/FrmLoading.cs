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
    public partial class FrmLoading : Form
    {
        public Action Worker { get; set; }
        public FrmLoading(Action worker, Form parentForm)
        {
            InitializeComponent();
            if (worker == null)
                throw new ArgumentNullException();
            Worker = worker;

            // 当表单加载时，开始执行耗时操作并在完成后关闭对话框
            this.Load += (sender, e) =>
            {
                Task.Factory.StartNew(Worker).ContinueWith(t =>
                {
                    this.Close();
                }, TaskScheduler.FromCurrentSynchronizationContext());
            };

            // 显示对话框
            this.ShowDialog(parentForm);
        }

        private void FrmLoading_Load(object sender, EventArgs e)
        {

        }
    }
}
