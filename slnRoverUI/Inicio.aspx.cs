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
    public partial class Inicio1 : System.Web.UI.Page
    {
        private static UsuarioSession session = UsuarioSession.Instancia;
        private IServiciosConfiguraciones configuraciones = new AccionesConfiguraciones();
        private Configuraciones configuracion = Configuraciones.Instancia;
        private IServiciosRepuestos repuestos = new AccionesRepuestos();
        private ServicioWebRover ServicioWeb = new ServicioWebRover();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!session.IdTipoModelo.HasValue)
            {
                Response.Redirect("~/Default.aspx");
            }
            var repuestos = this.repuestos.tomaNRepuestosSegunIdTipoModelo(session.IdTipoModelo.Value, 16);
            if (repuestos.Count() == 0)
            {
                this.pnlImgPrincipales.Visible = false;
                this.ltlRepuestos.Text = "NO SE ENCONTRARON PRODUCTOS.<br/> <a title='buscar' href='/Buscador.aspx' >IR AL BUSCADOR</a>";
            }
            else
            {
                var moneda = configuraciones.obtenConfiguracionMoneda();
                string plantilla = ServicioWeb.obtenPlantillaSegunNombre("InfoRepuestos");
                StringBuilder HTML = new StringBuilder();
                foreach (var repuesto in repuestos)
                {
                    string cadena = plantilla;
                    cadena = cadena.Replace("[ENLACE]", "Repuestos.aspx?Id=" + repuesto.IdRepuesto.ToString());
                    cadena = cadena.Replace("[FOTO]",
                        string.IsNullOrEmpty(repuesto.Foto) ? configuracion.IMAGEN_PREDETERMINADA : repuesto.Foto);
                    cadena = cadena.Replace("[NOMBRE]", repuesto.Nombre);
                    cadena = cadena.Replace("[PRECIO]", moneda.Simbolo + repuesto.Precio.ToString("0.00"));
                    string disponible = (repuesto.Cantidad <= 0) ? "<label style='font-size: small;'>NO EXISTEN DISPONIBLES</label>" : "";
                    cadena = cadena.Replace("[DISPONIBLE]", disponible);
                    HTML.Append(cadena);
                }
                this.ltlRepuestos.Text = HTML.ToString();
            }
        }
    }
}