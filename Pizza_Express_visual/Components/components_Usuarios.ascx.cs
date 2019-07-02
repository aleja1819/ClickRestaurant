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
        //private QueryTipoUsuario accesoTipoUsuario = new QueryTipoUsuario();

            

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {             

                //PARA MOSTRAR LOS USUARIOS DE LA BASE DE DATOS
                idTabla.DataSource = accesoUsuario.filtrarUsuarios();
                idTabla.DataBind();

                //MOSTRAR LA LISTA DE LOS TIPOS DE USUARIOS DE LA BASE DE DATOS
                fTipoUsuario.DataSource = accesoUsuario.filtrarTipoUsuarios();
                fTipoUsuario.DataBind();

                uContenedorUsuario.Update();
                uModalUsuario.Update();

                //MOSTRAR LISTA ESTADO USUARIO
                fEstado.DataSource = accesoUsuario.filtrarEstado();
                fEstado.DataBind();

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
                fEstado.SelectedIndex = 0;
            }
            else
            {

                //AL GUARDAR UN PRODUCTO

                trut.Text = "";
                tnombre.Text = "";
                temail.Text = "";
                tclave.Text = "";
                fTipoUsuario.SelectedIndex = 0;
                fEstado.SelectedIndex = 0;

            }
        }

        //PARA ABRIR EL MODAL
        protected void bRegistrarUsuarioModal_Click(object sender, EventArgs e) //MODAL 
        {
            ideditarUsuarioBoton.Visible = false;

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
            uModalUsuario.Update();
            uContenedorUsuario.Update();

            

        }

        //BOTON EDITAR USUARIOS, SELECCIONA LOS CAMPOS
        protected void idTabla_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            alerta.Visible = false;
            idregistrar.Visible = false;
            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("ideditar"))
            {

                cod_orginal.Text = idTabla.Rows[fila].Cells[0].Text;
                trut.Text = idTabla.Rows[fila].Cells[1].Text;
                tnombre.Text = idTabla.Rows[fila].Cells[2].Text;
                temail.Text = idTabla.Rows[fila].Cells[3].Text;
                tclave.Text = idTabla.Rows[fila].Cells[4].Text;

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('show');", true);
                uModalUsuario.Update();
                uContenedorUsuario.Update();

            }
            else if (e.CommandName.Equals("ideliminar"))
            {
               
                // ELIMINAR UN PRODUCTO DE LA LISTA
                string codigo = idTabla.Rows[fila].Cells[0].Text;
                int id = Convert.ToInt32(codigo);
                accesoUsuario.eliminarUsuario(id);
                idTabla.DataSource = accesoUsuario.filtrarUsuarios();
                idTabla.DataBind();

                alerta.Visible = true;
                alerta.CssClass = "alert alert-primary animated zoomInUp";
                mensaje3.Text = "USUARIO ELIMINADO CON EXITO.";

            }
        }

        private void MostrarError(TextBox t, Label l, int r) {

            if (r == 0)
            {
                t.CssClass = "form-control is-invalid";
                l.CssClass = "invalid-feedback";
            }
            else {
                t.CssClass = "form-control is-valid";
                l.CssClass = "valid-feedback";
            }
        }

        private bool validaCampos() {

            bool correcto = true;

            if (trut.Text.Equals(""))
            {
                MostrarError(trut, valida_trut, 0);
                correcto = false;
            }
            else {
                MostrarError(trut, valida_trut, 1);
            }
            if (tnombre.Text.Equals(""))
            {
                MostrarError(tnombre, valida_tnombre, 0);
                correcto = false;
            }
            else {
                MostrarError(tnombre, valida_tnombre, 1);
            };

            if (temail.Text.Equals(""))
            {
                MostrarError(temail, valida_temail, 0);
                correcto = false;
            }
            else {
                MostrarError(temail, valida_temail, 1);
            }
            if (tclave.Text.Equals(""))
            {
                MostrarError(tclave, valida_tcalve, 0);
                correcto = false;
            }
            else {
                MostrarError(tclave, valida_tcalve, 1);
            }
            return correcto;
        }

        //REGISTRAR UN USUARIO
        protected void idregistrarUsuario_Click(object sender, EventArgs e)
        {
            try
            {

                if (validaCampos() == false)
                {

                }
                else
                {

                    //LEER LOS DATOS INGRESADOS
                    string rut_u = trut.Text;
                    string nombre_u = tnombre.Text;
                    string email_u = temail.Text;
                    string clave_u = tclave.Text;

                    int id = Convert.ToInt32(fTipoUsuario.SelectedItem.Value);
                    int idE = Convert.ToInt32(fEstado.SelectedItem.Value);

                    //GUARDAR LOS DATOS EN LA LISTA
                    accesoUsuario.addUsuario(new Models.Usuario
                    {

                        rut_usuario = rut_u,
                        nombre_usuario = nombre_u,
                        email_usuario = email_u,
                        contraseña_usuario = clave_u,
                        codigo_tipoUsuario = id,
                        codigo_estado = idE
                        

                    });

                    //MOSTRAR LOS DATOS EN LA TABLA
                    idTabla.DataSource = accesoUsuario.filtrarUsuarios();
                    idTabla.DataBind();

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                    uModalUsuario.Update();
                    uContenedorUsuario.Update();

                    limpiarTodo(2);

                    alerta.Visible = true;
                    alerta.CssClass = "alert alert-primary animated zoomInUp";
                    mensaje3.Text = "USUARIO AGREGADO CON EXITO.";

                }
            }
            catch (Exception)
            {
                alerta.Visible = true;
                alerta.CssClass = "alert alert-danger animated zoomInUp";
                mensaje3.Text = "USUARIO NO AGREGADO.";
            }
        }
    
        protected void idBuscarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                alerta.Visible = false;
                int filtro = Convert.ToInt32(idOpciones.SelectedValue);

                int cant = accesoUsuario.BuscarrUsuarios(tdatoBuscar.Text, filtro).Count;

                idTabla.DataSource = accesoUsuario.BuscarrUsuarios(tdatoBuscar.Text, filtro);
                idTabla.DataBind();

                uModalUsuario.Update();
                uContenedorUsuario.Update();


                if (cant == 0)
                {
                    alerta.Visible = true;
                    alerta.CssClass = "alert alert-danger animated zoomInUp";
                    mensaje3.Text = "USUARIO NO ECONTRADO.";
                }

            }
            catch (Exception)
            {

            }
        }

        protected void ideditarUsuarioBoton_Click(object sender, EventArgs e)
        {
            try
            {
              

                if (validaCampos() == false)
                {

                }
                else {
                }

                //LEER LOS DATOS INGRESADOS
                string rut_u = trut.Text;
                string nombre_u = tnombre.Text;
                string email_u = temail.Text;
                string clave_u = tclave.Text;

                int id_tipoU = Convert.ToInt32(fTipoUsuario.SelectedItem.Value);
                string codigo_original = cod_orginal.Text;
                int idE = Convert.ToInt32(fEstado.SelectedItem.Value);
                accesoUsuario.editarUsuario(new Models.Usuario
                {

                    rut_usuario = rut_u,
                    nombre_usuario = nombre_u,
                    email_usuario = email_u,
                    contraseña_usuario = clave_u,
                    codigo_tipoUsuario = id_tipoU,
                    codigo_estado = idE

                }, codigo_original);

                //MOSTRAR LOS DATOS EN LA TABLA
                idTabla.DataSource = accesoUsuario.filtrarUsuarios();
                idTabla.DataBind();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                uModalUsuario.Update();
                uContenedorUsuario.Update();

                limpiarTodo(2);

                alerta.Visible = true;
                alerta.CssClass = "alert alert-primary animated zoomInUp";
                mensaje3.Text = "USUARIO MODIFICADO CON EXITO.";

            }
            catch (Exception)
            {
                alerta.Visible = true;
                alerta.CssClass = "alert alert-danger animated zoomInUp";
                mensaje3.Text = "USUARIO NO MODIFICADO.";

            }
         
        }
    }
}
    
