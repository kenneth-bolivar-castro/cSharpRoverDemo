using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnRoverHerramientas;
using slnRoverControl;
using System.Text;

namespace slnRoverUI
{
    public partial class Inicio : System.Web.UI.MasterPage
    {
        private static UsuarioSession session = UsuarioSession.Instancia;
        private static Configuraciones configuracion = Configuraciones.Instancia;
        private IServiciosRepuestos repuestos = new AccionesRepuestos();
        private IServiciosUsuarios usuarios = new AccionesUsuarios();
        private ServicioWebRover servicioWeb = new ServicioWebRover();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!session.IdTipoModelo.HasValue)
            {
                Response.Redirect("~/Default.aspx");
            }
            this.lblLgnInicioSession.Text = "";
            if (session.EstaIniciado)
            {
                this.cambiaVistaSessionIniciada(true);
                this.LblLogin.Text = "<strong>Bienvenido: </strong>"+session.CorreoUsuario; 
            }
            this.cargarProductosIniciales();
            this.cargarCategorias();
        }

        private void cambiaVistaSessionIniciada(bool iniciada)
        {
            this.pnlSessionIniciada.Visible = this.LblLogin.Visible = this.lnkbtnCerrarSession.Visible =
                   this.hypOrdenes.Visible = this.hlnkCarrito.Visible = iniciada;
            this.lgnInicioSession.Visible = !iniciada;
        }

        private void cargarProductosIniciales()
        {
            var coleccion = this.repuestos.tomaNRepuestosSegunIdTipoModelo(session.IdTipoModelo.Value, 3);
            if (coleccion.Count() > 0)
            {
                int i = 0;
                foreach (var repuesto in coleccion)
                {
                    string UrlDestino = "Repuestos.aspx?Id={0}";
                    switch (i)
                    {
                        case 0:
                            this.lblProductoPrimer.Text = repuesto.Nombre;
                            this.imgProductoPrimer.ImageUrl = string.IsNullOrEmpty(repuesto.Foto) ?
                                configuracion.IMAGEN_PREDETERMINADA : repuesto.Foto.Remove(0, 2);
                            this.hlnkProductoPrimer.NavigateUrl = string.Format(UrlDestino, repuesto.IdRepuesto);
                            break;
                        case 1:
                            this.lblProductoSegundo.Text = repuesto.Nombre;
                            this.imgProductoSegundo.ImageUrl = string.IsNullOrEmpty(repuesto.Foto) ?
                                configuracion.IMAGEN_PREDETERMINADA : repuesto.Foto.Remove(0, 2);
                            this.hlnkProductoSegundo.NavigateUrl = string.Format(UrlDestino, repuesto.IdRepuesto);
                            break;
                        case 2:
                            this.lblProductoTercer.Text = repuesto.Nombre;
                            this.imgProductoTercer.ImageUrl = string.IsNullOrEmpty(repuesto.Foto) ?
                                configuracion.IMAGEN_PREDETERMINADA : repuesto.Foto.Remove(0, 2);
                            this.hlnkProductoTercer.NavigateUrl = string.Format(UrlDestino, repuesto.IdRepuesto);
                            break;
                    };
                    i++;
                }
            }
            else
            {
                this.lblProductoPrimer.Text = this.lblProductoSegundo.Text = this.lblProductoTercer.Text = "NO HAY PRODUCTOS";
            }
        }

        private void cargarCategorias()
        {
            var coleccion = this.repuestos.obtenLasDiferentesCategoriasSegunIdTipoModelo(session.IdTipoModelo.Value);
            if (coleccion.Count() > 0)
            {
                int i = 0;
                StringBuilder HTML = new StringBuilder();
                foreach (var categoria in coleccion)
                {
                    if (i % 2 == 0)
                    {
                        HTML.AppendFormat("<div class=\"linksiz\"><a href=\"{0}\">{1}</a></div>",
                            "ProductosCategorias.aspx?IdCategoria=" + categoria.IdCategoria, categoria.Categoria);
                    }
                    else
                    {
                        HTML.AppendFormat("<div class=\"linksiz-negro\"><a href=\"{0}\">{1}</a></div>",
                            "ProductosCategorias.aspx?IdCategoria=" + categoria.IdCategoria, categoria.Categoria);
                    }
                    i++;
                }
                ltlCategorias.Text = HTML.ToString();
            }
        }

        protected void lnkbtnIrPortada_Click(object sender, EventArgs e)
        {
            session.IdTipoModelo = null;
            Response.Redirect("~/Default.aspx");
        }

        protected void lgnInicioSession_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int? IdUsuario, IdCarrito = null;
                    if (this.usuarios.iniciarSession(out IdUsuario, this.lgnInicioSession.UserName,
                        this.servicioWeb.encriptaClave(this.lgnInicioSession.Password), out IdCarrito))
                    {
                        session.CorreoUsuario = this.lgnInicioSession.UserName;
                        session.IdUsuario = IdUsuario.Value;
                        session.IdCarrito = IdCarrito.Value;
                        session.EstaIniciado = e.Authenticated = true;
                    }
                    else
                    {
                        this.lblLgnInicioSession.Text = "Correo y/o Clave incorrectas. Intente de nuevo.";
                        e.Authenticated = false;
                    }
                }
                catch (Exception ex)
                {
                    this.lblLgnInicioSession.Text = ex.Message;
                }
            }
        }

        protected void lnkbtnCerrarSession_Click(object sender, EventArgs e)
        {
            session.terminarSession();
            Response.Redirect("~/Default.aspx");
        }
    }
}