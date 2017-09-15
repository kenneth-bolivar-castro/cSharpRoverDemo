using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnRoverControl;

namespace slnRoverUI
{
    public partial class Registrese : System.Web.UI.Page
    {
        private IServiciosModelos modelos = new AccionesModelos();
        private IServiciosTipoModelo tipoModelo = new AccionesTipoModelo();
        private IServiciosCombustibles combustibles = new AccionesCombustibles();
        private IServiciosUsuarios usuarios = new AccionesUsuarios();
        private ServicioWebRover ServicioWeb = new ServicioWebRover();

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
            this.txtTelefono.Text = this.txtDireccion.Text = this.txtA_o.Text = this.txtVIN.Text = null;
            this.ddlCombustibles.SelectedIndex = this.ddlModelos.SelectedIndex = 0;
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string nombre = this.txtNombre.Text;
                    string apellidos = this.txtApellidos.Text;
                    string correo = this.txtCorreoElectronico.Text;
                    string clave = ServicioWeb.encriptaClave(this.txtClave.Text);
                    string telefono = this.txtTelefono.Text;
                    string direccion = this.txtDireccion.Text;
                    int IdTipoModelo = Convert.ToInt32(this.ddlTipoModelo.SelectedValue);
                    int IdCombustible = Convert.ToInt32(this.ddlCombustibles.SelectedValue);
                    int a_o = Convert.ToInt32(this.txtA_o.Text);
                    string vin = this.txtVIN.Text;
                    this.usuarios.incluirUsuarioDetalleVehiculo(correo, clave, false, true,
                        nombre, apellidos, direccion, telefono,
                        IdTipoModelo, a_o, vin, IdCombustible); 
                    this.inicializaCampos();
                    this.hlnkIniciaSession.Visible = true;
                    ClientScript.RegisterStartupScript(this.GetType(),
                        "RegistroCorrecto",
                        ServicioWeb.codigoMensajeEmergente("Se Ha Registrado Correctamente"));
                }
                catch (Exception ex)
                {
                    this.lblMensajeProceso.Text = ex.Message;
                }
            }
        }

    }
}