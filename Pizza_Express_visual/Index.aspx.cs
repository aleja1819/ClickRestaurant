using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Pizza_Express_visual.Services;
namespace Pizza_Express_visual
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mcontenedor.SetActiveView(vBienvenida);

            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            uModal.Update();
        }

        protected void Menu_home_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vBienvenida);
            uContenido.Update();
        }

        protected void Menu_MontoInicial_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vMonto_Inicial);
            uContenido.Update();
        }

        protected void Menu_CartaMenu_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vCarta_menu);
            uContenido.Update();
        }

        protected void Menu_Inventario_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vInventario);
            uContenido.Update();
        }

        protected void Menu_NumeroMesa_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vNumero_mesa);
            uContenido.Update();
        }

        protected void Menu_Proveedores_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vProveedores);
            uContenido.Update();
        }

        protected void Menu_RegistrarProductos_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vRegistrar_producto);
            uContenido.Update();
        }

        protected void Menu_Reportes_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vReportes);
            uContenido.Update();
        }

        protected void Menu_Reservas_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vReservas);
            uContenido.Update();
        }

        protected void Menu_usuarios_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vUsuarios);
            uContenido.Update();
        }

        protected void bingresar_login_Click(object sender, EventArgs e)
        {
            
        }

        protected void Menu_comanda_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vComanda);
            uContenido.Update();
        }
    }
}