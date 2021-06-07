using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POOApps
{
    public partial class FrmMdi : Form
    {
        public FrmMdi()
        {
            InitializeComponent();
        }

        private void ActivoFijoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
