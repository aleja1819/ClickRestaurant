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
        private QueryTipoUsuario accesoTipoUsuario = new QueryTipoUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //PARA MOSTRAR LOS USUARIOS DE LA BASE DE DATOS
                idTabla.DataSource = accesoUsuario.filtrarUsuarios();
                idTabla.DataBind();

                //MOSTRAR LA LISTA DE LOS TIPOS DE USUARIOS DE LA BASE DE DATOS
                fTipoUsuario.DataSource = accesoTipoUsuario.FiltroListaTipoUsuario();
                fTipoUsuario.DataBind();

            }
        }

        //PARA ABRIR EL MODAL
        protected void bRegistrarUsuarioModal_Click(object sender, EventArgs e) //MODAL 
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
            uModalUsuario.Update();
        }
    

        //BOTON EDITAR USUARIOS, SELECCIONA LOS CAMPOS
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

        protected void bregistrarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                //LEER LOS DATOS INGRESADOS POR EL USUARIO
                string rut_u = trut.Text;
                string nombre_u = tnombre.Text;
                string email_u = temail.Text;
                string contraseña_u = tclave.Text;
                string tipo_usu = fTipoUsuario.SelectedItem.Value;

                int id = Convert.ToInt32(fTipoUsuario.SelectedItem.Value);

                //GUARDAR LOS DATOS
                accesoUsuario.addUsuario(
                    new Models.Usuario
                    {
                        rut_usuario = rut_u,
                        nombre_usuario = nombre_u,
                        email_usuario = email_u,
                        contraseña_usuario = contraseña_u,
                        codigo_tipoUsuario = id
                    });

                //MOSTRAR LOS DATOS EN LA TABLA
                idTabla.DataSource = accesoUsuario.filtrarUsuarios();
                idTabla.DataBind();

                alerta.Visible = true;
                alerta.CssClass = "alert alert-success animated zoomInUp";
                mensaje2.Text = "Usuario agregado con éxito.";
                mensaje.Text = "Usuario agregado con éxito.";

            }
            catch (Exception )
            {
                alerta.Visible = true;
                alerta.CssClass = "alert alert-success animated zoomInUp";
                mensaje2.Text = "Usuario No agregado." ;
                mensaje.Text = "Usuario no con éxito.";
            }
        }

        //REGISTRAR UN USUARIO

    }
}
    
