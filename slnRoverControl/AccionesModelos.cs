using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using slnRoverDatos;

namespace slnRoverControl
{
    public interface IServiciosModelos
    {
        List<Modelos> obtenTodosLosModelos();
        Modelos obtenModeloSegunIdentificador(int Id);
        List<v_Modelos> obtenVistaModelos();
    }
   
    public class AccionesModelos:IServiciosModelos
    {
        private RoverDataContext contexto;

        public AccionesModelos() 
        {
            this.contexto = new RoverDataContext();
        }

        public AccionesModelos(RoverDataContext contexto)
        {
            this.contexto = contexto;
        }

        public List<Modelos> obtenTodosLosModelos()
        {
            return this.contexto.Modelos.ToList();
        }
          
        public Modelos obtenModeloSegunIdentificador(int Id)
        {
            return this.contexto.Modelos.FirstOrDefault(m => m.Id == Id);
        }
         
        List<v_Modelos> IServiciosModelos.obtenVistaModelos()
        {
            return this.contexto.v_Modelos.ToList();
        }
    }
}
