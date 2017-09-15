using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using slnRoverDatos;

namespace slnRoverControl
{
    public interface IServiciosTipoModelo
    {
        List<TipoModelo> obtenTiposSegunIdModelo(int IdModelo);
    }

    public class AccionesTipoModelo : IServiciosTipoModelo
    {
        private RoverDataContext contexto;

        public AccionesTipoModelo()
        {
            this.contexto = new RoverDataContext();
        }

        public AccionesTipoModelo(RoverDataContext contexto)
        {
            this.contexto = contexto;
        }


        public List<TipoModelo> obtenTiposSegunIdModelo(int IdModelo)
        {
            return this.contexto.TipoModelo.Where(tp => tp.IdModelo == IdModelo).ToList();
        }
    }
}
