using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOApps.service
{
    public interface IDpreciacion
    {
        decimal[] CalcularDepreciacion(decimal valor, decimal valorR, int vidaUtil);
    }
}
