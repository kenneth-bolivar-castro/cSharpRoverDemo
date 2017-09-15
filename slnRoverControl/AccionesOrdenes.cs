using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using slnRoverDatos;

namespace slnRoverControl
{
    public interface IServiciosOrdenes
    {
        List<v_Ordenes> obtenOrdenesSegunIdUsuario(int? IdUsuario);
    }

    public class AccionesOrdenes :  IServiciosOrdenes
    {
        private RoverDataContext contexto;

        public AccionesOrdenes()
        {
            this.contexto = new RoverDataContext();
        }

        public AccionesOrdenes(RoverDataContext contexto)
        {
            this.contexto = contexto;
        }

        public List<v_Ordenes> obtenOrdenesSegunIdUsuario(int? IdUsuario)
        {
            if (!IdUsuario.HasValue)
            {
                throw new ArgumentNullException("El identificador usuario no puede ser nulo. Debe iniciar sesi\u00F3n.");
            }
            return this.contexto.v_Ordenes.Where(v => v.IdUsuario == IdUsuario.Value).ToList();
        }
    }

}
