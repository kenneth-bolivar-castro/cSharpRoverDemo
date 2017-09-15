using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using slnRoverDatos;

namespace slnRoverControl
{
    public interface IServiciosCategorias
    {
        List<Categorias> obtenTodasLasCategorias();
    }

    public class AccionesCategorias : IServiciosCategorias
    {
        private RoverDataContext contexto;

        public AccionesCategorias()
        {
            this.contexto = new RoverDataContext();
        }

        public AccionesCategorias(RoverDataContext contexto)
        {
            this.contexto = contexto;
        }

        public List<Categorias> obtenTodasLasCategorias()
        {
            return this.contexto.Categorias.ToList();
        }
        //TODO insertar categorias

    }
}
