using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace slnRoverUI
{
    public class Global : System.Web.HttpApplication
    {
        private static ServicioWebRover _servicioWeb;

        public static ServicioWebRover ServicioWeb
        {
            get { return Global._servicioWeb; }
            set { Global._servicioWeb = value; }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            ServicioWeb = new ServicioWebRover();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}