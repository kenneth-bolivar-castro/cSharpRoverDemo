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
    public partial class Contactenos : System.Web.UI.Page
    {
        private IServiciosModelos modelos = new AccionesModelos();
        private IServiciosTipoModelo tipoModelo = new AccionesTipoModelo();
        private IServiciosCombustibles combustibles = new AccionesCombustibles();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.ddlCombustibles.DataSource = this.combustibles.obtenCombustiblesDondeNombreDiferente("TODOS");
                this.ddlModelos.DataSource = this.modelos.obtenVistaModelos();
                this.ddlModelos.DataBind();
                this.ddlCombustibles.DataBind();
            }
            this.ddlTipoModelo.DataSource = this.tipoModelo.obtenTiposSegunIdModelo(Convert.ToInt32(this.ddlModelos.SelectedValue));
            this.ddlTipoModelo.DataBind(); 
        }

        private void inicializaCampos()
        {
            this.txtNombre.Text = this.txtApellidos.Text = this.txtCorreoElectronico.Text =
            this.txtTelefono.Text = this.txtComentario.Text = this.txtA_o.Text = this.txtVIN.Text = null;
            this.ddlCombustibles.SelectedIndex = this.ddlModelos.SelectedIndex = 0;
        }

        private string crearCuerpoCorreo() {
            string nombre = this.txtNombre.Text;
            string apellidos = this.txtApellidos.Text;
            string correo = this.txtCorreoElectronico.Text;
            string telefono = this.txtTelefono.Text;
            string comentario = this.txtComentario.Text;
            string modelo = this.ddlModelos.SelectedItem.Text;
            string tipo = this.ddlTipoModelo.SelectedItem.Text;
            string combustible = this.ddlCombustibles.SelectedItem.Text;
            string a_o = this.txtA_o.Text;
            string vin = this.txtVIN.Text; 
            string cuerpoCorreo = new ServicioWebRover().obtenPlantillaSegunNombre("Contactenos");
            cuerpoCorreo = cuerpoCorreo.Replace("[NOMBRE]",nombre);
            cuerpoCorreo = cuerpoCorreo.Replace("[APELLIDOS]",apellidos);
            cuerpoCorreo = cuerpoCorreo.Replace("[CORREO]",correo);
            cuerpoCorreo = cuerpoCorreo.Replace("[TELEFONO]",telefono);
            cuerpoCorreo = cuerpoCorreo.Replace("[COMENTARIO]",comentario);
            cuerpoCorreo = cuerpoCorreo.Replace("[MODELO]",modelo);
            cuerpoCorreo = cuerpoCorreo.Replace("[TIPO]", tipo);
            cuerpoCorreo = cuerpoCorreo.Replace("[COMBUSTIBLE]",combustible);
            cuerpoCorreo = cuerpoCorreo.Replace("[A_O]",a_o);
            cuerpoCorreo = cuerpoCorreo.Replace("[VIN]",vin);
            return cuerpoCorreo;
        }

        protected void btnContactenos_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                { 
                    string mensajeEnvioCorreo = "Se Ha Enviado Correctamente Su Mensaje";
                    if (!new CorreoElectronico().enviarCorreoContactenos(this.crearCuerpoCorreo()))
                    {
                        mensajeEnvioCorreo = Herramientas.Excepcion.Message;
                    }
                    this.inicializaCampos();
                    ClientScript.RegisterStartupScript(this.GetType(),
                        "RegistroCorrecto",
                        new ServicioWebRover().codigoMensajeEmergente(mensajeEnvioCorreo));
                }
                catch (Exception ex)
                { 
                    this.lblMensajeProceso.Text = ex.Message;
                }
            }
        }
    }
}