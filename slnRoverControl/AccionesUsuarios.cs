using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using slnRoverDatos;
using System.Transactions;

namespace slnRoverControl
{
    public interface IServiciosUsuarios
    {
        List<Usuarios> obtenTodosLosUsuarios();
        Usuarios obtenUsuarioSegunIdentificador(int Id);
        Usuarios obtenUsuarioSegunIdentificador(string Correo);
        void incluirUsuario(string Correo, string Clave, bool EsAdministrador, bool EstaHabilitado);
        void incluirUsuarioDetalle(Usuarios usuario, string Nombre, string Apellidos, string Direccion, string Telefono);
        void incluirUsuarioVehiculo(Usuarios usuario, int IdTipoModelo, int A_o, string VIN, int IdCombustible);
        void incluirUsuarioDetalleVehiculo(string Correo, string Clave, bool EsAdministrador, bool EstaHabilitado,
            string Nombre, string Apellidos, string Direccion, string Telefono,
            int IdTipoModelo, int A_o, string VIN, int IdCombustible);
        bool iniciarSession(out int? IdUsuario, string Correo, string Clave, out int? IdCarrito);
        Carritos obtenCarritoActualSegunIdUsuario(int IdUsuario);
        void incluirCarritoUsuario(Usuarios usuario, DateTime Fecha);
        bool existeCorreo(string Correo);
        v_Usuarios obtenVistaUsuarioSegunCorreo(string Correo);
        void actualizaClaveUsuario(int Id, string Clave);
        bool esCorrectaClaveToken(int I, string Token);
        void defineTokenSeguridad(int IdUsuario, string Token);
        void defineTokenSeguridad(string Correo, string Token);
        bool iniciarAdministracion(out int? IdAdmin, string Correo, string Clave);
    }

    public class AccionesUsuarios : IServiciosUsuarios
    {
        private RoverDataContext contexto;
        private AccionesDetalleUsuario detalle;
        private AccionesVehiculoUsuario vehiculo;
        private AccionesCarritos carritos;

        public AccionesUsuarios()
        {
            this.contexto = new RoverDataContext();
        }

        public AccionesUsuarios(RoverDataContext contexto)
        {
            this.contexto = contexto;
        }

        public List<Usuarios> obtenTodosLosUsuarios()
        {
            return this.contexto.Usuarios.ToList();
        }

        public Usuarios obtenUsuarioSegunIdentificador(int Id)
        {
            return this.contexto.Usuarios.FirstOrDefault(u => u.Id == Id);
        }

        public void incluirUsuario(string Correo, string Clave, bool EsAdministrador, bool EstaHabilitado)
        {
            this.contexto.Usuarios.InsertOnSubmit(new Usuarios { Correo = Correo, Clave = Clave, Administrador = EsAdministrador, Habilitado = EstaHabilitado });
            this.contexto.SubmitChanges();
        }


        public void incluirUsuarioDetalle(Usuarios usuario, string Nombre, string Apellidos, string Direccion, string Telefono)
        {
            this.detalle = new AccionesDetalleUsuario(this.contexto);
            this.detalle.incluirDetalleUsuario(usuario, Nombre, Apellidos, Direccion, Telefono);
        }

        public void incluirUsuarioVehiculo(Usuarios usuario, int IdTipoModelo, int A_o, string VIN, int IdCombustible)
        {
            this.vehiculo = new AccionesVehiculoUsuario(this.contexto);
            this.vehiculo.incluirVehiculoUsuario(usuario, IdTipoModelo, A_o, VIN, IdCombustible);

        }


        public void incluirUsuarioDetalleVehiculo(string Correo, string Clave, bool EsAdministrador, bool EstaHabilitado, string Nombre, string Apellidos, string Direccion, string Telefono, int IdTipoModelo, int A_o, string VIN, int IdCombustible)
        {
            using (TransactionScope transaccion = new TransactionScope())
            {
                Usuarios usuario = new Usuarios
                {
                    Correo = Correo,
                    Clave = Clave,
                    Administrador = EsAdministrador,
                    Habilitado = EstaHabilitado
                };
                this.contexto.Usuarios.InsertOnSubmit(usuario);
                this.contexto.SubmitChanges();
                this.incluirUsuarioDetalle(usuario, Nombre, Apellidos, Direccion, Telefono);
                this.incluirUsuarioVehiculo(usuario, IdTipoModelo, A_o, VIN, IdCombustible);
                transaccion.Complete();
            }
        }


        public bool iniciarSession(out int? IdUsuario, string Correo, string Clave, out int? IdCarrito)
        {
            bool salida = false;
            IdUsuario = IdCarrito = null;
            Usuarios usuario = this.contexto.Usuarios.
                FirstOrDefault(u => u.Correo.Equals(Correo) && u.Clave.Equals(Clave));
            if (usuario != null)
            {
                if (usuario.Habilitado)
                {
                    Carritos carrito = this.obtenCarritoActualSegunIdUsuario(usuario.Id);
                    if (carrito == null)
                    {
                        this.incluirCarritoUsuario(usuario, DateTime.Now);
                    }
                    IdCarrito = carrito.Id;
                    IdUsuario = usuario.Id;
                    salida = true;
                }
                else
                {
                    throw new Exception("Usuario inhabilitado, contacte con el administrador");
                }
            }
            return salida;
        }


        public Carritos obtenCarritoActualSegunIdUsuario(int IdUsuario)
        {
            this.carritos = new AccionesCarritos(this.contexto);
            return this.carritos.obtenCarritoActualSegunIdUsuario(IdUsuario);
        }


        public void incluirCarritoUsuario(Usuarios usuario, DateTime Fecha)
        {
            this.carritos = new AccionesCarritos(this.contexto);
            this.carritos.incluirCarritoUsuario(usuario, Fecha);
        }


        public bool existeCorreo(string Correo)
        {
            return (this.contexto.Usuarios.Where(u => u.Correo.Equals(Correo)).Count() == 1) ? true : false;
        }

        public Usuarios obtenUsuarioSegunCorreo(string Correo)
        {
            return this.contexto.Usuarios.FirstOrDefault(u => u.Correo.Equals(Correo));
        }


        public v_Usuarios obtenVistaUsuarioSegunCorreo(string Correo)
        {
            return this.contexto.v_Usuarios.FirstOrDefault(u => u.Correo.Equals(Correo));
        }


        public void actualizaClaveUsuario(int Id, string Clave)
        {
            Usuarios usuario = this.obtenUsuarioSegunIdentificador(Id);
            usuario.Clave = Clave;
            this.contexto.SubmitChanges();
        }

        public bool esCorrectaClaveToken(int I, string Token)
        {
            return (this.contexto.Usuarios.Where(u => u.Id == I && u.Token.Equals(Token)).Count() == 1) ? true : false;
        }


        public void defineTokenSeguridad(int IdUsuario, string Token)
        {
            Usuarios usuario = this.obtenUsuarioSegunIdentificador(IdUsuario);
            usuario.Token = Token;
            this.contexto.SubmitChanges();
        }


        public void defineTokenSeguridad(string Correo, string Token)
        {
            Usuarios usuario = this.obtenUsuarioSegunIdentificador(Correo);
            usuario.Token = Token;
            this.contexto.SubmitChanges();
        }


        public Usuarios obtenUsuarioSegunIdentificador(string Correo)
        {
            return this.contexto.Usuarios.FirstOrDefault(u => u.Correo.Equals(Correo));
        }


        public bool iniciarAdministracion(out int? IdAdmin, string Correo, string Clave)
        {
            bool salida = false;
            IdAdmin = null;
            Usuarios usuario = this.contexto.Usuarios.
                FirstOrDefault(u => u.Correo.Equals(Correo) && u.Clave.Equals(Clave));
            if (usuario != null)
            {
                if (!usuario.Habilitado)
                {
                    throw new Exception("Usuario inhabilitado, contacte con el administrador");
                }
                if (!usuario.Administrador)
                {
                    throw new Exception("Usuario sin credenciales para administrar");
                }
                IdAdmin = usuario.Id;
                salida = true;
            }
            return salida;
        }
    }
}
