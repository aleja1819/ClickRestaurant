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

        private void limpiarTodo(int op)
        {

            if (op == 1)
            {
                trut.Text = "";
                tnombre.Text = "";
                temail.Text = "";
                tclave.Text = "";
                fTipoUsuario.SelectedIndex = 0;
            }
            else
            {

                //AL GUARDAR UN PRODUCTO

                trut.Text = "";
                tnombre.Text = "";
                temail.Text = "";
                tclave.Text = "";
                fTipoUsuario.SelectedIndex = 0;

            }
        }

        //PARA ABRIR EL MODAL
        protected void bRegistrarUsuarioModal_Click(object sender, EventArgs e) //MODAL 
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
//            uModalUsuario.Update();

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

                //fTipoUsuario.SelectedValue = idTabla.Rows[fila].Cells[4].Text;
            }
            else if (e.CommandName.Equals("ideliminar"))
            {

                // ELIMINAR UN PRODUCTO DE LA LISTA
                string rut = idTabla.Rows[fila].Cells[0].Text;
                accesoUsuario.eliminarUsuario(rut);



                idTabla.DataSource = accesoUsuario.ListarTodosLosUsuarios();
                idTabla.DataBind();

                alerta.Visible = true;
                alerta.CssClass = "alert alert-success animated zoomInUp";
                mensaje2.Text = "Usuario eliminado con éxito.";

            }
        }

        protected void idregistrarUsuario_Click(object sender, EventArgs e)
        {
            try {
                mensaje.Visible = true;
                //LEER LOS DATOS INGRESADOS
                string rut_u = trut.Text;
                string nombre_u = tnombre.Text;
                string email_u = temail.Text;
                string clave_u = tclave.Text;

                int id = Convert.ToInt32(fTipoUsuario.SelectedItem.Value);
                Models.TipoUsuario tipo_U = new Models.TipoUsuario
                {
                    codigo_tipoUsuario = id,
                    nombre_tipoUsuario = fTipoUsuario.SelectedItem.Text
                };

                //GUARDAR LOS DATOS EN LA LISTA
                accesoUsuario.addUsuario(new Models.Usuario
                {

                    rut_usuario = rut_u,
                    nombre_usuario = nombre_u,
                    email_usuario = email_u,
                    contraseña_usuario = tclave.Text,
                    TipoUsuario = tipo_U

                });

                //MOSTRAR LOS DATOS EN LA TABLA
                idTabla.DataSource = accesoUsuario.ListarTodosLosUsuarios();
                idTabla.DataBind();

                limpiarTodo(2);

                mensaje.Text = "Usuario agregado";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);

            }
            catch (Exception)
            {
                mensaje.Text = "Usuario No agregado";

            }
        }

        protected void idtest_Click(object sender, EventArgs e)
        {
            string rut_u = trut.Text;
        }

        //REGISTRAR UN USUARIO

    }
}
    
