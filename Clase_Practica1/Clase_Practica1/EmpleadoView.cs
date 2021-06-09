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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_Practica1
{
    public partial class EmpleadoView : Form
    {
        
        private EmpleadoModel empleadoModel;
        int id, indextoUpdate = 0;
        bool update = false;
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

            if(update == true)
            {
                int idUpdated = int.Parse(txtId.Text);
                string nameUpdated = txtName.Text;
                string lastNameUpdated = txtLastName.Text;
                string cedulaUpdated = txtCedula.Text;
                string cellphoneUpdated = txtCellphone.Text;
                string emailUpdated = txtEmail.Text;
                if (!validateEmail(emailUpdated))
                {
                    MessageBox.Show("Email Incorrecto!");
                    return;
                }
                Profesion profesionUpdated = (Profesion)Enum.GetValues(typeof(Profesion)).GetValue(cmbProfesion.SelectedIndex);
                Cargo cargoUpdated = (Cargo)Enum.GetValues(typeof(Cargo)).GetValue(cmbCargo.SelectedIndex);
                decimal.TryParse(txtSalary.Text, out decimal salaryUpdated);

                Empleado empleadoUpdate = new Empleado()
                {
                    id = idUpdated,
                    name = nameUpdated,
                    lastName = lastNameUpdated,
                    cedula = cedulaUpdated,
                    cellphone = cellphoneUpdated,
                    email = emailUpdated,
                    profesion = profesionUpdated,
                    cargo = cargoUpdated,
                    salary = salaryUpdated,

                };

                update = false;
                btnAdd.Text = "Registrar";
                btnUpdate.Text = "Actualizar";

                empleadoModel.Update(empleadoUpdate, indextoUpdate);
                dgvEmpleados.Refresh();
                dgvEmpleados.DataSource = empleadoModel.GetAll();
               
                CleanData();
                return;
            }

            string name = txtName.Text;
            string lastName = txtLastName.Text;
            string cedula = txtCedula.Text;
            string cellphone = txtCellphone.Text;
            string email = txtEmail.Text;
            if (!validateEmail(email))
            {
               MessageBox.Show("Email Incorrecto!");
                return;
            }
            Profesion profesion = (Profesion)Enum.GetValues(typeof(Profesion)).GetValue(cmbProfesion.SelectedIndex);
            Cargo cargo = (Cargo) Enum.GetValues(typeof(Cargo)).GetValue(cmbCargo.SelectedIndex);
            decimal.TryParse(txtSalary.Text, out decimal salary);

            Empleado empleado = new Empleado()
            {
                id = id++,
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

            CleanData();
           
        }


        private void ValidateEmpleado(string name,string lastName)
        {

        }

        private Boolean validateEmail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {   
            if (dgvEmpleados.Rows.Count == 0)
            {
                return;
            }

            if(update == true)
            {
                return;

            }

            int index = dgvEmpleados.CurrentCell.RowIndex;
            
            empleadoModel.Remove(index);

            dgvEmpleados.DataSource = empleadoModel.GetAll();

        }

        private void CleanData()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtLastName.Text = "";
            txtCedula.Text = "";
            txtCellphone.Text = "";
            txtEmail.Text = "";
            txtSalary.Text ="";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.Rows.Count == 0)
            {
                return;
            }
            if (update == true)  // & btnUpdate.Text.Equals("Cancel")
            {
                CleanData();
                btnAdd.Text = "Registrar";
                btnUpdate.Text = "Actualizar";
                update = false;
                return;
            }

            if(update == false)
            {
                btnAdd.Text = "Save";
                btnUpdate.Text = "Cancel";
                update = true;
            }
          
            
            indextoUpdate = dgvEmpleados.CurrentCell.RowIndex;

            Empleado empleadoToUpdate = empleadoModel.getElement(indextoUpdate);

            txtId.Text = empleadoToUpdate.id.ToString();
            txtName.Text = empleadoToUpdate.name;
            txtLastName.Text = empleadoToUpdate.lastName;
            txtCedula.Text = empleadoToUpdate.cedula;
            txtCellphone.Text = empleadoToUpdate.cellphone;
            txtEmail.Text = empleadoToUpdate.email;
            cmbCargo.SelectedIndex = (int)empleadoToUpdate.cargo;
            cmbProfesion.SelectedIndex = (int)empleadoToUpdate.profesion;
            txtSalary.Text = empleadoToUpdate.salary.ToString();
            

        }
    }
}
