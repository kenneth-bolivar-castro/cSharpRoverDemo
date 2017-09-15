using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace slnRoverHerramientas
{
    //TODO mejorar esto porque no permite mas de un usuario concurrente
    public class UsuarioSession
    {
        private static UsuarioSession _instancia;
        private static int? _idUsuario;
        private static string _correoUsuario;
        private static int? _idCarrito;
        private static bool _iniciado;
        private static int? _idTipoModelo;
        private static int? _idAdmin;
        private static bool _adminIniciado;
        private static string _paginaActual;

        private UsuarioSession()
        {

        }

        public static UsuarioSession Instancia
        {
            get
            {
                if (UsuarioSession._instancia == null) { UsuarioSession._instancia = new UsuarioSession(); }
                return UsuarioSession._instancia;
            }
            set
            {
                if (value == null) { throw new ArgumentException("La Instancia No Puede Ser NULL"); }
                UsuarioSession._instancia = value;
            }
        }

        public int? IdAdmin
        {
            get { return UsuarioSession._idAdmin; }
            set { UsuarioSession._idAdmin = value; }
        }

        public bool AdminIniciado
        {
            get { return UsuarioSession._adminIniciado; }
            set { UsuarioSession._adminIniciado = value; }
        }

        public int? IdUsuario
        {
            get { return UsuarioSession._idUsuario; }
            set { UsuarioSession._idUsuario = value; }
        }

        public string CorreoUsuario
        {
            get { return UsuarioSession._correoUsuario; }
            set { UsuarioSession._correoUsuario = value; }
        }

        public int? IdCarrito
        {
            get { return UsuarioSession._idCarrito; }
            set { UsuarioSession._idCarrito = value; }
        }

        public bool EstaIniciado
        {
            get { return UsuarioSession._iniciado; }
            set { UsuarioSession._iniciado = value; }
        }

        public int? IdTipoModelo
        {
            get { return UsuarioSession._idTipoModelo; }
            set { UsuarioSession._idTipoModelo = value; }
        }

        public string PaginaActual
        {
            get { return UsuarioSession._paginaActual; }
            set { UsuarioSession._paginaActual = value; }
        }

        public void terminarSession()
        {
            this.IdUsuario = this.IdCarrito = this.IdTipoModelo = null;
            this.CorreoUsuario = null;
            EstaIniciado = false;
        }
    }
}
