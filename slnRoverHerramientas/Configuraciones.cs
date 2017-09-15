using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;

namespace slnRoverHerramientas
{
    public class Configuraciones
    {
        private static readonly Configuraciones _instancia = new Configuraciones();

        private Configuraciones()
        {

        }

        public static Configuraciones Instancia
        {
            get 
            {
                return Configuraciones._instancia;
            }
        }

        public int MaximoPorPagina
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["MaximoPorPagina"]);
            }
        }

        public string CorreoContactenos
        {
            get
            {
                return ConfigurationManager.AppSettings["CorreoContactenos"].ToString();
            }
        }

        public string SRV_SMTP
        {
            get
            {
                return ConfigurationManager.AppSettings["SRV_SMTP"].ToString();
            }
        }

        public int PRT_SRV_SMTP
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["PRT_SRV_SMTP"].ToString());
            }
        }

        public string USR_SMTP
        {
            get
            {
                return ConfigurationManager.AppSettings["USR_SMTP"].ToString();
            }
        }

        public string CLV_USR_SMTP
        {
            get
            {
                return ConfigurationManager.AppSettings["CLV_USR_SMTP"].ToString();
            }
        }

        public string IMAGEN_PREDETERMINADA
        {
            get
            {
                return ConfigurationManager.AppSettings["ImgPredeterminada"].ToString();
            }
        }

        public string Sitio
        {
            get
            {
                return ConfigurationManager.AppSettings["Sitio"].ToString();
            }
        }
    }
}
