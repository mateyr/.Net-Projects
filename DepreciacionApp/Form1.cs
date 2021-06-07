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
        private poco.ActivoFijo[] activosFijo;
        public Form1()
        {
            InitializeComponent();
            loadTipoActivo();
        }

        private ActivoFijo[] AddElement(ActivoFijo[] activos, ActivoFijo af)//Arreglo dinámico
        {
            if(activos == null)
            {
                activos = new ActivoFijo[1];
                activos[0] = af;
                return activos;
            }
            ActivoFijo[] temp = new ActivoFijo[activos.Length + 1];
            Array.Copy(activos, temp, activos.Length);
            temp[temp.Length - 1] = af;

            return temp;
        }

        private void loadTipoActivo()
        {
            //foreach(Object i in Enum.GetValues(typeof(poco.TipoActivo))) ;    ----> Esta es una forma para cargar los cmb pero es muy tardado ya que tendria que recorrer muchas veces el enum creadoy pues efe

            cmbTipo.Items.AddRange(Enum.GetValues(typeof(poco.TipoActivo)).Cast<object>().ToArray());
            cmbTipo.SelectedItem = 0;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            decimal.TryParse(txtValor.Text, out decimal valor);
            decimal.TryParse(txtValorR.Text, out decimal valorR);

            int index = cmbTipo.SelectedIndex;
            TipoActivo tipoActivo = (TipoActivo) Enum.GetValues(typeof(TipoActivo)).GetValue(index);//Seleccion de los elementos de un cmb integrando el enum TipoActivo

            ActivoFijo af = new ActivoFijo()// En .NET no existen los constructores y por eso asi es que se inicializan los objetos
            {//Se pueden agregar todos los elementos y tambien solo los que necesitemos gran Hack
                Codigo = codigo,
                Nombre = nombre,
                TipoActivo = tipoActivo,
                Valor = valor,
                ValorR = valorR
            };

            activosFijo = AddElement(activosFijo, af);
            MessageBox.Show("Activo agregado sastifactoriamente :)");

            dgbActivos.DataSource = activosFijo;

            cleanComponents();
        } 

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            cleanComponents();
        }

        private void txtValidations()
        {
            //Validaciones
        }


        private void cleanComponents()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtValor.Text = "";
            txtValorR.Text = "";
            cmbTipo.SelectedItem = 0;
        }
    }
}
