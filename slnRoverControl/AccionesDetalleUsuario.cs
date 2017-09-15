using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using slnRoverDatos;

namespace slnRoverControl
{
    public interface IServiciosDetalleUsuario
    {   
        void incluirDetalleUsuario(Usuarios usuario, string Nombre, string Apellidos, string Direccion, string Telefono);
    }

    public class AccionesDetalleUsuario : IServiciosDetalleUsuario
    {
        private RoverDataContext contexto;

        public AccionesDetalleUsuario()
        {
            this.contexto = new RoverDataContext();
        }

        public AccionesDetalleUsuario(RoverDataContext contexto)
        {
            this.contexto = contexto;
        }
  //TODO cambiar esto para que la firma reciba un DetalleUsuario
        public void incluirDetalleUsuario(Usuarios usuario, string Nombre, string Apellidos, string Direccion, string Telefono)
        {
            this.contexto.DetalleUsuario.InsertOnSubmit(new DetalleUsuario { Usuarios = usuario, Nombre = Nombre, Apellidos = Apellidos, Direccion = Direccion, Telefono = Telefono });
            this.contexto.SubmitChanges();
        }
    }
}
