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

        QueryComanda accesoComanda = new QueryComanda();

        protected void Page_Load(object sender, EventArgs e)
        {
            idMostrarMenu.Visible = true;
            idCargarSeleccion.Visible = true;
        }

        protected void tabGrande_Click(object sender, EventArgs e)
        {
            idMostrarMenu.Visible = true;
            int filtro = Convert.ToInt32(idOpciones.SelectedValue);
            
            int cant = accesoComanda.filtrarCategoriaMenu(idOpciones.Text, filtro).Count;
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