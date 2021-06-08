using Clase_Practica1.enums;
using Clase_Practica1.model;
using Clase_Practica1.poco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_Practica1
{
    public partial class EmpleadoView : Form
    {
        
        private EmpleadoModel empleadoModel;
        int id = -1;
        public EmpleadoView()
        {
            InitializeComponent();
            loadComboBox();
            empleadoModel = new EmpleadoModel();
        }

        private void loadComboBox()
        {
            cmbCargo.Items.AddRange(Enum.GetValues(typeof(Cargo)).Cast<Object>().ToArray());
            cmbCargo.SelectedIndex = 0;
            cmbProfesion.Items.AddRange(Enum.GetValues(typeof(Profesion)).Cast<Object>().ToArray());
            cmbProfesion.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string lastName = txtLastName.Text;
            string cedula = txtCedula.Text;
            string cellphone = txtCellphone.Text;
            string email = txtEmail.Text;
            Profesion profesion = (Profesion)Enum.GetValues(typeof(Profesion)).GetValue(cmbProfesion.SelectedIndex);
            Cargo cargo = (Cargo) Enum.GetValues(typeof(Cargo)).GetValue(cmbCargo.SelectedIndex);
            decimal.TryParse(txtSalary.Text, out decimal salary);

            Empleado empleado = new Empleado()
            {
                name = name,
                lastName = lastName,
                cedula = cedula,
                cellphone = cellphone,
                email  = email,
                profesion = profesion,
                cargo = cargo,
                salary = salary,

            };

            empleadoModel.AddElement(empleado);
            dgvEmpleados.DataSource = empleadoModel.GetAll();
           
        }


        private void ValidateEmpleado(string name,string lastName)
        {

        }
        
           
        

    }
}
