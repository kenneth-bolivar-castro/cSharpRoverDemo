using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace slnRoverUI.admin.config
{
    public partial class Configuracion : System.Web.UI.MasterPage
    {
        public string Modulo
        {
            get
            {
                return "Configuraciones";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}