using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnRoverHerramientas;

namespace slnRoverUI.admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        private UsuarioSession session = UsuarioSession.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.cargaOpciones();
            }
        }

        private void cargaOpciones()
        {
            Boolean predeterminado = true;
            if (session.PaginaActual.Equals("configuracion.aspx"))
            {
                predeterminado = false;
            }
            this.cargaVistaOpcionesPredeterminada(predeterminado);
        }

        private void cargaVistaOpcionesPredeterminada(Boolean B)
        {
            this.PnlOpciones.Visible = B;
            this.PnlOpConfg.Visible = !B;
        }
    }
}