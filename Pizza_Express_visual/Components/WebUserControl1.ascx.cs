using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pizza_Express_visual.Components
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBarra_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
            uModalTest.Update();
            uContenedorTest.Update();
           
        }

        protected void idtest_Click(object sender, EventArgs e)
        {
            if (t1.Text.Equals("")) {
                error.Text = "*"; 
            }
            else
            {

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                uModalTest.Update();
                uContenedorTest.Update();
                ms.Text = "up panel 1";
            }

          
        }
    }
}