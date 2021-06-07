using POOApps.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOApps.service
{
    public class DepreciacionFactory
    {
        public IDpreciacion CreateInstance(MetodoDepreciacion metodoDepreciacion)
        {
            switch (metodoDepreciacion)
            {
                case MetodoDepreciacion.LINEA_RECTA:
                    return new LineaRecta();
                case MetodoDepreciacion.SDA_INCREMENTAL:
                    return new SDAIncremental();
                case MetodoDepreciacion.SDA_DECREMENTAL:
                    return new SDADecremental();
                default:
                    return null;
            }
        }
    }
}
