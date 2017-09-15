using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnRoverControl;
using slnRoverHerramientas;

namespace slnRoverUI.admin
{
    public partial class Default : System.Web.UI.Page
    {
        private static UsuarioSession session = UsuarioSession.Instancia;
        private IServiciosUsuarios usuarios = new AccionesUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                session.PaginaActual = "Default.aspx";
            }
        }

        protected void lgnIngresar_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int? idAdmin = null;
                    session.AdminIniciado =  e.Authenticated = this.usuarios.iniciarAdministracion(out idAdmin, 
                        this.lgnIngresar.UserName, 
                        Global.ServicioWeb.encriptaClave(this.lgnIngresar.Password));
                    session.IdAdmin = idAdmin;
                }
                catch (Exception ex)
                {
                    e.Authenticated = false;
                    this.lgnIngresar.FailureText = ex.Message;
                }
            }
        }
    }
}