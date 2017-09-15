using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace slnRoverUI.controles.jQGridTable
{
    public partial class jQGridTable : System.Web.UI.UserControl
    {
        public int[] ColumnasIds { get; set; }

        public object Datos
        {
            set
            {
                this.gvDatos.DataSource = value;
            }
        }

        public string Mensaje
        {
            get { return this.lblInformacion.Text; }
            set { this.lblInformacion.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.gvDatos.DataBind();
                this.ocultaColumnas();
            }
        }

        private void ocultaColumnas()
        {
            if (this.gvDatos.Rows.Count > 0)
            {
                if (ColumnasIds != null)
                {
                    foreach (int i in ColumnasIds)
                    {
                        this.gvDatos.HeaderRow.Cells[i].Visible = false;
                        foreach (GridViewRow fila in this.gvDatos.Rows)
                        {
                            fila.Cells[i].Visible = false;
                        }
                    }
                }
            }
        }
    }
}