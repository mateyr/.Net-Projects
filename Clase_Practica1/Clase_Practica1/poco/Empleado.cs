using Clase_Practica1.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Practica1.poco
{
    public class Empleado
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string cedula { get; set;}
        public string cellphone { get; set; }
        public string email { get; set; }
        public Profesion profesion { get; set; }
        public Cargo cargo { get; set;}
        public decimal salary { get; set; }

    }
}
