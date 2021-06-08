using Clase_Practica.poco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_Practica
{
    public partial class Form1 : Form
    {
        private int id = 0;
        private Empleado[] empleados;
        

        public Form1()
        {
            InitializeComponent();
           

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string lastName = txtLastName.Text;
            string cedula = txtCedula.Text;
            string fechaC = txtFechaC.Text;
            decimal.TryParse(txtSalario.Text ,out decimal salario );

            Empleado emp = new Empleado
            {
                id = id++,
                name = name,
                lastName = lastName,
                cedula = cedula,
                fechaContra = fechaC,
                salario = salario,
            };

            if (empleados == null)
            {
                empleados = new Empleado[1];
                empleados[0] = emp;
                dgvEmpleados.DataSource = empleados;
                return;
            }

            Empleado[] temp = new Empleado[empleados.Length + 1];
            Array.Copy(empleados, temp, empleados.Length);
            temp[temp.Length - 1] = emp;
            empleados = temp;
           
            dgvEmpleados.DataSource = empleados;
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = dgvEmpleados.CurrentCell.RowIndex;
            Empleado[] temp = new Empleado[empleados.Length ];
            for(int i = 0; i < empleados.Length; i++)
            {
                if((empleados[i].id == index) == false)
                {
                    temp[i] = empleados[i];
                }
            }

            dgvEmpleados.DataSource = temp;
        }
    }
}
