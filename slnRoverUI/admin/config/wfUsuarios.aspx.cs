using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnRoverControl;
using slnRoverHerramientas;

namespace slnRoverUI.admin.config
{
    public partial class wfUsuarios : System.Web.UI.Page
    {
        private static UsuarioSession session = UsuarioSession.Instancia;
        private IServiciosUsuarios usuarios = new AccionesUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    session.PaginaActual = "wfUsuarios.aspx";
                    this.jQGridTable1.Datos = this.usuarios.obtenTodosLosUsuarios();
                }
                catch (Exception ex)
                {
                    this.jQGridTable1.Mensaje = ex.Message;
                }
            }

            ClientScript.RegisterStartupScript(this.GetType(), "ActivaMenu",
              Global.ServicioWeb.obtenCodigoRegistrarFuente("activaMenu('" + Master.Modulo + "');"));
        }
    }
}