using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    }
}