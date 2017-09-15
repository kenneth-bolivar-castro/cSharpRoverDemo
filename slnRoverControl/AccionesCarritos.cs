using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using slnRoverDatos;

namespace slnRoverControl
{
    public interface IServiciosCarritos
    {
        Carritos obtenCarritoActualSegunIdUsuario(int IdUsuario);
        void incluirCarrito(int IdUsuario, DateTime Fecha);
        void incluirCarritoUsuario(Usuarios Usuario, DateTime Fecha);
    }

    public class AccionesCarritos : IServiciosCarritos
    {
        private RoverDataContext contexto;

        public AccionesCarritos()
        {
            this.contexto = new RoverDataContext();
        }

        public AccionesCarritos(RoverDataContext contexto)
        {
            this.contexto = contexto;
        }

        public Carritos obtenCarritoActualSegunIdUsuario(int IdUsuario)
        {
            return (from c in this.contexto.Carritos
                    where
                    c.IdUsuario == IdUsuario &&
                    !(from o in this.contexto.Ordenes
                      select o.IdCarrito).Contains(c.Id)
                    select c).FirstOrDefault();
        }


        public void incluirCarrito(int IdUsuario, DateTime Fecha)
        {
            this.contexto.Carritos.InsertOnSubmit(new Carritos { IdUsuario = IdUsuario, Fecha = Fecha });
            this.contexto.SubmitChanges();
        }

        public void incluirCarritoUsuario(Usuarios Usuario, DateTime Fecha)
        {
            this.contexto.Carritos.InsertOnSubmit(new Carritos { Usuarios = Usuario, Fecha = Fecha });
            this.contexto.SubmitChanges();
        }
    }
}
