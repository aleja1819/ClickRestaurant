using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Pizza_Express_visual.Services;
namespace Pizza_Express_visual.Components
{
    public partial class components_CartaMenu : System.Web.UI.UserControl
    {

        private QueryMenu accesoMenu = new QueryMenu();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //PARA MOSTRAR LOS USUARIOS DE LA BASE DE DATOS
                idTabla.DataSource = accesoMenu.filtrarMenu();
                idTabla.DataBind();

                uModalMenu.Update();
                uContenedorMenu.Update();

                //PARA MOSTRAR LOS TAMAÑOS DE PIZZA
                ftamaño.DataSource = accesoMenu.filtrarTamañoP();
                idTabla.DataBind();

                uModalMenu.Update();
                uContenedorMenu.Update();

                //PARA CATEGORIAS
                fcategoria.DataSource = accesoMenu.filtrarCategoria();
                idTabla.DataBind();

                uModalMenu.Update();
                uContenedorMenu.Update();

            }
        }

        protected void bRegistrarMenu_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
            uModalMenu.Update();
            uContenedorMenu.Update();
        }
    }
}