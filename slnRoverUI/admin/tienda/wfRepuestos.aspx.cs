using System;
using System.Web.UI;
using slnRoverControl;
using slnRoverHerramientas;

namespace slnRoverUI.admin.tienda
{
    public partial class wfRepuestos : System.Web.UI.Page
    {
        private static UsuarioSession session = UsuarioSession.Instancia;
        private IServiciosRepuestos repuestos = new AccionesRepuestos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    session.PaginaActual = "wfRepuestos.aspx";
                    this.jQGridTable1.Datos = this.repuestos.obtenerTodos();
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