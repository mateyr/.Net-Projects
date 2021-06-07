using POOApps.poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOApps.model
{
    public class ActivoFijoModel
    {
        private ActivoFijo[] activosFijos;

        public ActivoFijoModel()
        {

        }

        public void AddElement(ActivoFijo activoFijo)
        {
            if (activosFijos == null)
            {
                activosFijos = new ActivoFijo[1];
                activosFijos[0] = activoFijo;
                return;
            }

            ActivoFijo[] temporal = new ActivoFijo[activosFijos.Length + 1];
            Array.Copy(activosFijos, temporal, activosFijos.Length);
            temporal[temporal.Length - 1] = activoFijo;

            activosFijos = temporal;
        }

        public void Remove(int index)
        {
            if(index < 0)
            {
                return;
            }

            if(activosFijos == null)
            {
                return;
            }

            if(index >= activosFijos.Length)
            {
                throw new IndexOutOfRangeException($"El indice: '{index}' esta fuera de rango!");
            }

            if(index == 0 && activosFijos.Length == 1)
            {
                activosFijos = null;
                return;
            }

            ActivoFijo[] temp = new ActivoFijo[activosFijos.Length - 1];
            if(index == 0)
            {
                Array.Copy(activosFijos, index + 1, temp, 0, temp.Length);
                activosFijos = temp;
                return;
            }

            if(index == activosFijos.Length - 1)
            {
                Array.Copy(activosFijos, 0, temp, 0, temp.Length);
                activosFijos = temp;
                return;
            }

            Array.Copy(activosFijos, 0, temp, 0, index);
            Array.Copy(activosFijos, index + 1, temp, index, (temp.Length - index));
            activosFijos = temp;
        }

        public ActivoFijo[] GetAll()
        {
            return activosFijos;
        }

        public int GetGreaterVidaUtil()
        {
            return (int) activosFijos.OrderBy(a => a.TipoActivo).Reverse().FirstOrDefault().TipoActivo;
        }
    }
}
