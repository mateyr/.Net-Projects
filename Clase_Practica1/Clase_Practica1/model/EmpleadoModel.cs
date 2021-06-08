using Clase_Practica1.poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Practica1.model
{
    public class EmpleadoModel
    {
        private Empleado[] empleados;

        public EmpleadoModel()
        {

        }

        public void AddElement(Empleado empleado)
        {
            if (empleado == null)
            {
                empleados = new Empleado[1];
                empleados[0] = empleado;
                return;
            }

            Empleado[] temporal = new Empleado[empleados.Length + 1];
            Array.Copy(empleados, temporal, empleados.Length);
            temporal[temporal.Length - 1] = empleado;

            empleados = temporal;
        }

        public void Remove(int index)
        {
            if (index < 0)
            {
                return;
            }

            if (empleados == null)
            {
                return;
            }

            if (index >= empleados.Length)
            {
                throw new IndexOutOfRangeException($"El indice: '{index}' esta fuera de rango!");
            }

            if (index == 0 && empleados.Length == 1)
            {
                empleados = null;
                return;
            }

            Empleado[] temp = new Empleado[empleados.Length - 1];
            if (index == 0)
            {
                Array.Copy(empleados, index + 1, temp, 0, temp.Length);
                empleados = temp;
                return;
            }

            if (index == empleados.Length - 1)
            {
                Array.Copy(empleados, 0, temp, 0, temp.Length);
                empleados = temp;
                return;
            }

            Array.Copy(empleados, 0, temp, 0, index);
            Array.Copy(empleados, index + 1, temp, index, (temp.Length - index));
            empleados = temp;
        }

        public Empleado[] GetAll()
        {
            return empleados;
        }

    }
}
