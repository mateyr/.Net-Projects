using POOApps.model;
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
        private ActivoFijoModel activoFijoModel;
        public FrmMdi()
        {
            InitializeComponent();
            activoFijoModel = new ActivoFijoModel();
        }

        private void ActivoFijoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ActivoFijoModel = activoFijoModel;
            frm.MdiParent = this;
            frm.Show();
        }

        private void DepreciacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDepreciacion frmDepreciacion = new FrmDepreciacion();
            frmDepreciacion.ActivoFijoModel = activoFijoModel;
            frmDepreciacion.MdiParent = this;
            frmDepreciacion.Show();
        }
    }
}
