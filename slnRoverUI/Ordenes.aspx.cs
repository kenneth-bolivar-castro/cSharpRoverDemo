using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnRoverControl;
using slnRoverHerramientas;

namespace slnRoverUI
{
    public partial class Ordenes : System.Web.UI.Page
    {
        private IServiciosOrdenes ordenes = new AccionesOrdenes();
        private UsuarioSession session = UsuarioSession.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.gvOrdenes.DataSource = ordenes.obtenOrdenesSegunIdUsuario(session.IdUsuario);
                this.gvOrdenes.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }
    }
}