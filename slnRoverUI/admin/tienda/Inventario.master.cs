using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace slnRoverUI.admin.tienda
{
    public partial class Inventario : System.Web.UI.MasterPage
    {
        public string Modulo 
        { 
            get 
            {
                return "Tienda Virtual";
            } 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}