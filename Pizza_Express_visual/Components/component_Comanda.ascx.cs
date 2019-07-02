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
        static List<object> prod_dispo = new List<object>();
        static List<object> carroCompra = new List<object>();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void tabGrande_Click(object sender, EventArgs e)
        {
            int cantidad = 1;
            try
            {
                prod_dispo = accesoComanda.filtrarCategoriaMenu(8, 2);               
                idMostrarMenu.DataSource = prod_dispo;
                idMostrarMenu.DataBind();
            }
            catch (Exception)
            {
                //NO ESTA EL PRODUCTO EN EL CARRO
               
            }
        }


        protected void idMostrarMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("idselected"))
            {

                //AGREGAR PRODUCTO AL CARRO
                carroCompra.Add(prod_dispo);
                idCargarSeleccion.DataSource = carroCompra;
                idCargarSeleccion.DataBind();
            }
        }
    }
}