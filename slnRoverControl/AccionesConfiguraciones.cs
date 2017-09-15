using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using slnRoverDatos;

namespace slnRoverControl
{
    public interface IServiciosConfiguraciones
    {
        Monedas obtenConfiguracionMoneda();
    }

    public class AccionesConfiguraciones : IServiciosConfiguraciones
    {
        private RoverDataContext contexto;

        public AccionesConfiguraciones()
        {
            this.contexto = new RoverDataContext();
        }

        public AccionesConfiguraciones(RoverDataContext contexto)
        {
            this.contexto = contexto;
        }

        public Monedas obtenConfiguracionMoneda()
        {
            return new AccionesMonedas(this.contexto)
                .obtenMonedaSegunId(Convert.ToInt32(
                this.contexto.Configuraciones.First(
                c => c.Clave.Equals("MONEDA")).Valor));
        }
    }
}
