﻿using POOApps.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOApps.poco
{
    public class ActivoFijo
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorResidual { get; set; }
        public TipoActivo TipoActivo { get; set; }
    }
}
