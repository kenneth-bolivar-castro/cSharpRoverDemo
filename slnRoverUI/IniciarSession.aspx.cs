using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnRoverControl;
using slnRoverHerramientas;

namespace slnRoverUI
{
    public partial class IniciarSession : System.Web.UI.Page
    {
        private static UsuarioSession session = UsuarioSession.Instancia;
        private IServiciosUsuarios usuarios = new AccionesUsuarios();
        private ServicioWebRover servicioWeb = new ServicioWebRover();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciaSession_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int? IdUsuario, IdCarrito = null;
                    if (this.usuarios.iniciarSession(out IdUsuario, this.txtCorreo.Text,
                        this.servicioWeb.encriptaClave(this.txtClave.Text), out IdCarrito))
                    {
                        session.CorreoUsuario = this.txtCorreo.Text;
                        session.IdUsuario = IdUsuario.Value;
                        session.IdCarrito = IdCarrito.Value;
                        session.EstaIniciado = true;
                        Response.Redirect("~/Inicio.aspx");
                    }
                    else
                    {
                        this.lblInicioSession.Text = "Correo y/o Clave incorrectas. Intente de nuevo."; 
                    }
                }
                catch (Exception ex)
                {
                    this.lblInicioSession.Text = ex.Message;
                }
            }
        }
    }
}