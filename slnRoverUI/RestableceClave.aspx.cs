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
    public partial class RestableceClave : System.Web.UI.Page
    {
        private IServiciosUsuarios usuarios = new AccionesUsuarios();
        private Configuraciones configuracion = Configuraciones.Instancia;
        private ServicioWebRover ServicioWeb = new ServicioWebRover();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["i"] != null && Request.QueryString["token"] != null)
            {
                if (this.usuarios.esCorrectaClaveToken(
                    Convert.ToInt32(Request.QueryString["i"]),
                    Request.QueryString["token"].ToString()))
                {
                    this.hfIdentificadorUsuario.Value = Request.QueryString["i"];
                    this.pnlSolicitaRestablecer.Visible = false;
                    this.pnlRestableceClave.Visible = true;
                }
                else
                {
                    this.lblProceso.Text = "El Token De Seguridad Fallo: <ul><li>Trate Nuevamente Para Restaurar Su Clave.</li><li>Contactenos Para Poder Ayudarle: <a href='/Contactenos.aspx' title='Contactenos'>Contactenos</a></li></ul>";
                }
            }
        }

        protected void btnRestablecer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string correo = this.txtCorreo.Text.Trim();
                    if (!this.usuarios.existeCorreo(correo))
                    {
                        throw new ArgumentException("No Existe Registro Del Correo Electronico");
                    }
                    this.usuarios.defineTokenSeguridad(correo, ServicioWeb.obtenTokenSeguridadAleatorio());
                    var vista = this.usuarios.obtenVistaUsuarioSegunCorreo(correo);
                    string cuerpoCorreo = ServicioWeb.obtenPlantillaSegunNombre("RestableceClave");
                    cuerpoCorreo = cuerpoCorreo.Replace("[NOMBRE]", vista.Nombre);
                    cuerpoCorreo = cuerpoCorreo.Replace("[APELLIDOS]", vista.Apellidos);
                    cuerpoCorreo = cuerpoCorreo.Replace("[CORREO]", correo);
                    cuerpoCorreo = cuerpoCorreo.Replace("[URL_RESTABLECER]",
                        configuracion.Sitio +
                        string.Format("RestableceClave.aspx?i={0}&token={1}", vista.IdUsuario, vista.Token));
                    cuerpoCorreo = cuerpoCorreo.Replace("[URL_SITIO]", configuracion.Sitio);
                    if (!new CorreoElectronico().enviarCorreoRestableceClave(correo, cuerpoCorreo))
                    {
                        throw Herramientas.Excepcion;
                    }
                    this.txtCorreo.Enabled = this.btnRestablecer.Enabled = false;
                    this.lblProceso.Style.Add("color", "green");
                    this.lblProceso.Text = "Se Ha Enviado Un Correo Electronico Con Las Instrucciones Para Restablecer Su Clave.";
                }
                catch (Exception ex)
                {
                    this.lblProceso.Text = ex.Message;
                }
            }
        }

        protected void btnActualizaClave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int IdUsuario = Convert.ToInt32(this.hfIdentificadorUsuario.Value);
                    this.usuarios.defineTokenSeguridad(IdUsuario, null);
                    this.usuarios.actualizaClaveUsuario(IdUsuario,
                        ServicioWeb.encriptaClave(this.txtClave.Text));
                    this.lblProceso.Style.Add("color", "green");
                    this.lblProceso.Text = "Se Actualizo La Clave Correctamente.<br/><a href='/IniciarSession.aspx' title='Inicio Session'>Iniciar Session</a>";
                }
                catch (Exception ex)
                {
                    this.lblProceso.Text = ex.Message;
                }
            }
        }
    }
}