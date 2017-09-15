using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Services;
using slnRoverHerramientas;

namespace slnRoverUI
{
    /// <summary>
    /// Summary description for ServicioWebRover
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioWebRover : System.Web.Services.WebService
    {
        private JavaScript javascript = JavaScript.Instancia;
        private Configuraciones configuracion = Configuraciones.Instancia;
        private const string CARPETA_PLANTILLAS = "plantillas/";

        [WebMethod]
        public string obtenTokenSeguridadAleatorio()
        {
            int milisegundo = DateTime.Now.Millisecond;
            Random aleatorio = new Random(milisegundo);
            StringBuilder token = new StringBuilder();
            char ch;
            for (int i = 0; i < milisegundo; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * aleatorio.NextDouble() + 65)));
                token.Append(ch);
            }
            return this.encriptaClave(token.ToString());
        }

        [WebMethod]
        public string encriptaClave(string clave)
        {
            System.Security.Cryptography.MD5 hasher = System.Security.Cryptography.MD5.Create();
            byte[] data = hasher.ComputeHash(Encoding.Default.GetBytes(clave));
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                strBuilder.Append(data[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }

        [WebMethod]
        public string codigoMensajeEmergente(string Aviso)
        {
            string codigo = javascript.codigoMensajeEmergente();
            return codigo.Replace("{0}", Aviso);
        }

        [WebMethod]
        public string obtenPlantillaSegunNombre(string Plantilla)
        {
            string Sitio = configuracion.Sitio;
            WebRequest peticion = WebRequest.Create(string.Concat(Sitio, CARPETA_PLANTILLAS, "_", Plantilla, ".html"));
            WebResponse respuesta = peticion.GetResponse();
            StreamReader lector = new StreamReader(respuesta.GetResponseStream());
            return lector.ReadToEnd();
        }

        [WebMethod]
        public string obtenCodigoRegistrarFuente(string fuente)
        {
            StringBuilder script = new StringBuilder();
            script.Append("<script language=JavaScript>");
            script.Append(fuente);
            script.Append("</script>");
            return script.ToString();
        }
    }
}
