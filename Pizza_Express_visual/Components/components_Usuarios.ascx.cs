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

        static List<Models.Usuario> usuarios = new List<Models.Usuario>();
        static int filaEdit = -1;

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
                uContenedorUsuario.Update();
                uModalUsuario.Update();

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
            uModalUsuario.Update();
            uContenedorUsuario.Update();


        }

        //BOTON EDITAR USUARIOS, SELECCIONA LOS CAMPOS
        protected void idTabla_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
            //uModalUsuario.Update();
            //uContenedorUsuario.Update();

            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("ideditar"))
            {

                trut.Text = idTabla.Rows[fila].Cells[0].Text;
                tnombre.Text = idTabla.Rows[fila].Cells[1].Text;
                temail.Text =  idTabla.Rows[fila].Cells[2].Text;
                tclave.Text =  idTabla.Rows[fila].Cells[3].Text;

                
            }
            else if (e.CommandName.Equals("ideliminar"))
            {
                // ELIMINAR UN PRODUCTO DE LA LISTA
                string codigo = idTabla.Rows[fila].Cells[1].Text;
                usuarios.RemoveAll(u => u.codigo_tipoUsuario.Equals(codigo));

               
                idTabla.DataSource = accesoUsuario.filtrarUsuarios();
                idTabla.DataBind();

                

                mensaje.Visible = true;
                mensaje.Text = "Usuario eliminado";

            }
        }

        //REGISTRAR UN USUARIO
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
                idTabla.DataSource = accesoUsuario.filtrarUsuarios();
                idTabla.DataBind();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                uModalUsuario.Update();
                uContenedorUsuario.Update();
               

                limpiarTodo(2);

            }
            catch (Exception)
            {
                mensaje.Text = "Usuario No agregado";

            }
        }

        protected void idBuscarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                int filtro = Convert.ToInt32(idOpciones.SelectedValue);

                int cant = accesoUsuario.filtrarUsuarios().Count;

                idTabla.DataSource = accesoUsuario.filtrarUsuarios();

                idTabla.DataBind();

                uContenedorUsuario.Update();

                if (cant ==0)
                {
                    mensaje.Visible = true;
                    mensaje.Text = "Usuario no encontrado";
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ideditarUsuarioBoton_Click(object sender, EventArgs e)
        {
            try
            {
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

                accesoUsuario.editarUsuario(new Models.Usuario
                {

                    rut_usuario = rut_u,
                    nombre_usuario = nombre_u,
                    email_usuario = email_u,
                    contraseña_usuario = tclave.Text,
                    TipoUsuario = tipo_U

                });

                //MOSTRAR LOS DATOS EN LA TABLA
                idTabla.DataSource = accesoUsuario.filtrarUsuarios();
                idTabla.DataBind();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                uModalUsuario.Update();
                uContenedorUsuario.Update();


                limpiarTodo(2);

            }
            catch (Exception)
            {

                throw;
            }
         
        }
    }
}
    
