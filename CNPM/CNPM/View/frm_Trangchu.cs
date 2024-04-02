using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM.View
{
    public partial class frm_Trangchu : Form
    {
        public frm_Trangchu()
        {
            InitializeComponent();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Taikhoan = "";
            Properties.Settings.Default.Solansai = 0;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Forgot frm_Forgot = new frm_Forgot();
            frm_Forgot.ShowDialog();
        }
    }
}
