using POOApps.enums;
using POOApps.model;
using POOApps.poco;
using POOApps.service;
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
    public partial class FrmDepreciacion : Form
    {
        public ActivoFijoModel ActivoFijoModel { get; set; }
        public FrmDepreciacion()
        {
            InitializeComponent();
        }

        private void FrmDepreciacion_Load(object sender, EventArgs e)
        {
            cmbMetodos.Items.AddRange(Enum.GetValues(typeof(MetodoDepreciacion)).Cast<object>().ToArray());
            cmbMetodos.SelectedIndex = 0;
            cmbMetodos.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadDepreciaciones()
        {
            int columns = ActivoFijoModel.GetGreaterVidaUtil();
            for(int i = 0; i <= columns; i++)
            {
                if(i == 0)
                {
                    dgvDepreciacion.Columns.Add($"Columns{i}", "Nombre Activo");
                }

                dgvDepreciacion.Columns.Add($"Columns{i}", $"{i}");
            }

            IDpreciacion depreciacion = new DepreciacionFactory().CreateInstance((MetodoDepreciacion) 
                Enum.GetValues(typeof(MetodoDepreciacion)).GetValue(cmbMetodos.SelectedIndex));

            foreach(ActivoFijo af in ActivoFijoModel.GetAll())
            {
                decimal[] dep = depreciacion.CalcularDepreciacion(af.Valor, af.ValorResidual, (int)af.TipoActivo);
                List<object> rows = new List<object>();
                //rows.Add(af.Nombre);
                //rows.Add(dep);
                //dgvDepreciacion.Rows.AddRange(rows);
                for(int i = 0; i <= dep.Length; i++)
                {
                    if(i == 0)
                    {
                        dgvDepreciacion.Rows.Add(af.Nombre);
                    }

                }
            }
        }
    }
}
