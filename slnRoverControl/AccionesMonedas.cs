using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using slnRoverDatos;

namespace slnRoverControl
{
    public interface IServiciosMonedas
    {
        Monedas obtenMonedaSegunId(int Id);
    }

    public class AccionesMonedas : IServiciosMonedas
    {
        private RoverDataContext contexto;

        public AccionesMonedas()
        {
            this.contexto = new RoverDataContext();
        }

        public AccionesMonedas(RoverDataContext contexto)
        {
            this.contexto = contexto;
        }

        public Monedas obtenMonedaSegunId(int Id)
        {
            return this.contexto.Monedas.First(m => m.Id == Id);
        }
    }
}
