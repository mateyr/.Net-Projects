using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOApps.service
{
    public class LineaRecta : IDpreciacion
    {
        public decimal[] CalcularDepreciacion(decimal valor, decimal valorR, int vidaUtil)
        {
            decimal d = (valor - valorR) / vidaUtil;
            return Enumerable.Repeat(d, vidaUtil).ToArray();
        }
    }
}
