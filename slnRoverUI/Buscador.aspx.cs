using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnRoverControl;
using slnRoverHerramientas;

namespace slnRoverUI
{
    public partial class Buscador : System.Web.UI.Page
    {
        private IServiciosModelos modelos = new AccionesModelos();
        private IServiciosTipoModelo tipoModelo = new AccionesTipoModelo();
        private IServiciosCombustibles combustibles = new AccionesCombustibles();
        private IServiciosCategorias categorias = new AccionesCategorias();
        private IServiciosRepuestos repuestos = new AccionesRepuestos();
        private IServiciosConfiguraciones configuraciones = new AccionesConfiguraciones();
        private ServicioWebRover ServicioWeb = new ServicioWebRover();
        private static Configuraciones configuracion = Configuraciones.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.ddlModelos.DataSource = this.modelos.obtenVistaModelos();
                this.ddlCombustible.DataSource = this.combustibles.obtenTodosLosCombustibles();
                this.ddlCategorias.DataSource = this.categorias.obtenTodasLasCategorias();
                this.ddlModelos.DataBind();
                this.ddlCombustible.DataBind();
                this.ddlCategorias.DataBind();
                this.ddlCategorias.Items.Add(new ListItem("TODAS", "0"));
                this.ddlCategorias.SelectedValue = "0";
            }
            this.ddlTipoModelo.DataSource = this.tipoModelo.obtenTiposSegunIdModelo(Convert.ToInt32(this.ddlModelos.SelectedValue));
            this.ddlTipoModelo.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = string.IsNullOrEmpty(this.txtNombre.Text) ? "" : this.txtNombre.Text;
            int idCategoria = Convert.ToInt32(this.ddlCategorias.SelectedValue);
            int idTipoModelo = Convert.ToInt32(this.ddlTipoModelo.SelectedValue);
            int idCombustible = Convert.ToInt32(this.ddlCombustible.SelectedValue);
            bool esUsado = Convert.ToBoolean(this.rblEsUsado.SelectedValue);
            var coleccion = repuestos.buscaRepuestosSegunCriterios(nombre,idCategoria,idTipoModelo,idCombustible,esUsado);
            if (coleccion.Count() == 0)
            {
                this.ltlRepuestos.Text = "NO SE ENCONTRARON REGISTROS";
            }
            else 
            {
                var moneda = configuraciones.obtenConfiguracionMoneda();
                string plantilla = ServicioWeb.obtenPlantillaSegunNombre("ListaRepuestos");
                StringBuilder HTML = new StringBuilder();
                foreach(var repuesto in coleccion){
                    string cadena = plantilla;
                    cadena = cadena.Replace("[ENLACE]","Repuestos.aspx?Id="+repuesto.IdRepuesto.ToString());
                    cadena = cadena.Replace("[FOTO]", 
                        string.IsNullOrEmpty(repuesto.Foto) ? configuracion.IMAGEN_PREDETERMINADA : repuesto.Foto);
                    cadena = cadena.Replace("[NOMBRE]", repuesto.Nombre);
                    cadena = cadena.Replace("[PRECIO]", moneda.Simbolo + repuesto.Precio.ToString("0.00"));
                    cadena = cadena.Replace("[CANTIDAD]", repuesto.Cantidad.ToString());
                    HTML.Append(cadena);   
                }
                this.ltlRepuestos.Text = HTML.ToString();
            }
        }
    }
}