using POOApps.enums;
using POOApps.model;
using POOApps.poco;
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
    public partial class Form1 : Form
    {
        public ActivoFijoModel ActivoFijoModel { get; set; }  // Property

        public Form1()
        {
            InitializeComponent();
            LoadComboBoxs();
        }

        private void LoadComboBoxs()
        {
            cmbTipoActivo.Items.AddRange(Enum.GetValues(typeof(TipoActivo)).Cast<object>().ToArray());
            cmbTipoActivo.SelectedIndex = 0;
            ActivoFijoModel = new ActivoFijoModel();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigo.Text;
                string nombre = txtNombre.Text;
                ValidateActivoFijo(codigo, nombre, out decimal valor, out decimal valorResidual);
                int index = cmbTipoActivo.SelectedIndex;
                TipoActivo tipo = (TipoActivo)Enum.GetValues(typeof(TipoActivo)).GetValue(index);
                ActivoFijo af = new ActivoFijo()
                {
                    Codigo = codigo,
                    Nombre = nombre,
                    TipoActivo = tipo,
                    Valor = valor,
                    ValorResidual = valorResidual
                };

                ActivoFijoModel.AddElement(af);
                dvgActivos.DataSource = ActivoFijoModel.GetAll();
                MessageBox.Show($"Activo agregado satisfactoriamente!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MENSAJE DE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ClearComponents();
        }

        private void ValidateActivoFijo(string codigo, string nombre, out decimal valor, out decimal valorR)
        {
            if(string.IsNullOrWhiteSpace(codigo))
            {
                throw new ArgumentException("El codigo es requerido!");
            }
            if(string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre es requerido!");
            }
            if(!decimal.TryParse(txtValor.Text, out decimal v))
            {
                throw new ArgumentException($"El valor '{txtValor.Text}' es invalido!");
            }
            valor = v;
            if(!decimal.TryParse(txtValorResidual.Text, out decimal vR))
            {
                throw new ArgumentException($"El valor '{txtValorResidual.Text}' es invalido!");
            }
            valorR = vR;
        }

        private void ClearComponents()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtValor.Text = "";
            txtValorResidual.Text = "";
            cmbTipoActivo.SelectedIndex = 0;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if(dvgActivos.Rows.Count == 0)
            {
                return;
            }

            int index = dvgActivos.CurrentCell.RowIndex;
            ActivoFijoModel.Remove(index);
            dvgActivos.DataSource = ActivoFijoModel.GetAll();
        }
    }
}
