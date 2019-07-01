using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Pizza_Express_visual.Services;
namespace Pizza_Express_visual.Components
{
    public partial class component_Comanda : System.Web.UI.UserControl
    {

        QueryMenu accesoMenuTabla = new QueryMenu();

        protected void Page_Load(object sender, EventArgs e)
        {
            idMostrarMenu.Visible = true;
            idCargarSeleccion.Visible = true;
        }

        protected void tabfamiliar_Click(object sender, EventArgs e)
        {
            idMostrarMenu.Visible = true;
            idMostrarMenu.DataSource = accesoMenuTabla.filtrarMenu();
            idMostrarMenu.DataBind();
        }

        protected void idMostrarMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("idselected"))
            {
                idCargarSeleccion.Visible = true;
                
                
            }
        }
    }
}