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
    public partial class Default : System.Web.UI.Page
    {
        private IServiciosModelos modelos = new AccionesModelos();
        private IServiciosTipoModelo tipoModelo = new AccionesTipoModelo();

        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!Page.IsPostBack)
            {
                this.ddlModelos.DataSource = this.modelos.obtenVistaModelos();
                this.ddlModelos.DataBind();
            }
            this.ddlTipoModelo.DataSource = this.tipoModelo.obtenTiposSegunIdModelo(Convert.ToInt32(this.ddlModelos.SelectedValue));
            this.ddlTipoModelo.DataBind();
        }

        protected void imgBtnIngresar_Click(object sender, ImageClickEventArgs e)
        {
            UsuarioSession session = UsuarioSession.Instancia;
            session.IdTipoModelo = Convert.ToInt32(this.ddlTipoModelo.SelectedValue);
            Response.Redirect("~/Inicio.aspx");
        }
    }
}