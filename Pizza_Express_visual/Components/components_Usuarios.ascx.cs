using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Pizza_Express_visual.Services;
namespace Pizza_Express_visual.Components
{
    public partial class components_Usuarios : System.Web.UI.UserControl
    {
        private QueryUsuario accesoUsuario = new QueryUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                idTabla.DataSource = accesoUsuario.filtrarUsuarios();
                idTabla.DataBind();
            }
        }

        protected void bRegistrarUsuario_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
            uModalUsuario.Update();
        }

        protected void idTabla_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
            uModalUsuario.Update();

            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("ideditar"))
            {
                trut.Text = trut.Text = idTabla.Rows[fila].Cells[0].Text;
                tnombre.Text = tnombre.Text = idTabla.Rows[fila].Cells[1].Text;
                temail.Text = temail.Text = idTabla.Rows[fila].Cells[2].Text;
                tclave.Text = tclave.Text = idTabla.Rows[fila].Cells[3].Text;

                fTipoUsuario.SelectedValue = idTabla.Rows[fila].Cells[4].Text;
            }

        }

        }
    }
