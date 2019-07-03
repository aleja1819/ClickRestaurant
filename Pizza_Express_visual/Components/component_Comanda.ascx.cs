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
        static List<Services.carro> carroCompra = new List<Services.carro>();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void tabGrande_Click(object sender, EventArgs e)
        {
           
            try
            {
                
                prod_dispo = accesoComanda.filtrarCategoriaMenu(8, 2);               
                idMostrarMenu.DataSource = prod_dispo;
                idMostrarMenu.DataBind();
            }
            catch (Exception)
            {
               
            }
        }

        protected void idMostrarMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("idselected"))
            {
                string codigoMenu = "";
                string nombre_menu = "";
                string precio_Menu = "";
                string ingre = "";
                

                try
                {
                    codigoMenu = idMostrarMenu.Rows[fila].Cells[0].Text;
                    nombre_menu = idMostrarMenu.Rows[fila].Cells[1].Text.Replace("&#243;", "ó").Replace("&#233;", "é").Replace("&#241;", "ñ").Replace(".","");
                    precio_Menu = idMostrarMenu.Rows[fila].Cells[2].Text.Replace("&#243;", "ó").Replace("&#233;", "é").Replace("&#241;", "ñ").Replace(".", "");
                    ingre = idMostrarMenu.Rows[fila].Cells[3].Text.Replace("&#243;", "ó").Replace("&#233;", "é").Replace("&#241;", "ñ").Replace(".", "");

                    int codM = Convert.ToInt32(codigoMenu);
                    //AGREGAR PRODUCTO AL CARRO
                    carro carro_comp = new carro();
                    carro_comp = carroCompra.First(p => p.codigo_M == codM);
                    carroCompra[carroCompra.IndexOf(carro_comp)].cantidad += 1;
                    carroCompra[carroCompra.IndexOf(carro_comp)].precio_M += carro_comp.precio_M;

                    idCargarSeleccion.DataSource = carroCompra;
                    idCargarSeleccion.DataBind();

                }
                catch (Exception)
                {

                    int codM = Convert.ToInt32(codigoMenu);
                    int precioM = Convert.ToInt32(precio_Menu);

                    carroCompra.Add(new carro { codigo_M = codM, nombre_M =nombre_menu, precio_M = precioM, ingre_M = ingre, cantidad=1});

                }
                finally {
                    idCargarSeleccion.DataSource = carroCompra;
                    idCargarSeleccion.DataBind();
                    codigoMenu= "";
                    
                } 
            }
        }

        protected void tabmediana_Click(object sender, EventArgs e)
        {
            try
            {

                prod_dispo = accesoComanda.filtrarCategoriaMenu(8, 3);
                idMostrarMenu.DataSource = prod_dispo;
                idMostrarMenu.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void tabindividual_Click(object sender, EventArgs e)
        {

            try
            {

                prod_dispo = accesoComanda.filtrarCategoriaMenu(8, 4);
                idMostrarMenu.DataSource = prod_dispo;
                idMostrarMenu.DataBind();
            }
            catch (Exception)
            {

            }
        }
    }
    }
