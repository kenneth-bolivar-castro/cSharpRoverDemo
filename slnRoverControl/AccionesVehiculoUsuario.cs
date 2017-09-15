using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using slnRoverDatos;

namespace slnRoverControl
{
    public interface IServiciosVehiculoUsuario
    {
        void incluirVehiculoUsuario(Usuarios usuario, int IdTipoModelo, int A_o, string VIN, int IdCombustible);
    }

    public class AccionesVehiculoUsuario : IServiciosVehiculoUsuario
    {
        private RoverDataContext contexto;

        public AccionesVehiculoUsuario()
        {
            this.contexto = new RoverDataContext();
        }

        public AccionesVehiculoUsuario(RoverDataContext contexto)
        {
            this.contexto = contexto;
        } 

        public void incluirVehiculoUsuario(Usuarios usuario, int IdTipoModelo, int A_o, string VIN, int IdCombustible)
        {
            this.contexto.VehiculoUsuario.InsertOnSubmit(new VehiculoUsuario { Usuarios = usuario, IdTipoModelo = IdTipoModelo, A_o = A_o, VIN = VIN, IdCombustible = IdCombustible });
            this.contexto.SubmitChanges();
        }
    }
}
