using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using slnRoverDatos;

namespace slnRoverControl
{
    public interface IServiciosCombustibles
    {
        List<Combustibles> obtenTodosLosCombustibles();
        List<Combustibles> obtenCombustiblesDondeNombreIgual(string nombre);
        List<Combustibles> obtenCombustiblesDondeNombreDiferente(string nombre);
        Combustibles obtenCombustiblesSegundIdentificador(int Id);
    }

    public class AccionesCombustibles:IServiciosCombustibles
    {
        private RoverDataContext contexto;

        public AccionesCombustibles()
        {
            this.contexto = new RoverDataContext();
        }

        public AccionesCombustibles(RoverDataContext contexto)
        {
            this.contexto = contexto;
        }

        public List<Combustibles> obtenTodosLosCombustibles()
        {
            return this.contexto.Combustibles.ToList();
        }

        public Combustibles obtenCombustiblesSegundIdentificador(int Id)
        {
            return this.contexto.Combustibles.FirstOrDefault(c => c.Id == Id);
        }


        public List<Combustibles> obtenCombustiblesDondeNombreIgual(string nombre)
        {
            return this.contexto.Combustibles.Where(c => c.Nombre.Equals(nombre)).ToList();
        }


        public List<Combustibles> obtenCombustiblesDondeNombreDiferente(string nombre)
        {
            return this.contexto.Combustibles.Where(c => !c.Nombre.Equals(nombre)).ToList();
        }
    }
}
