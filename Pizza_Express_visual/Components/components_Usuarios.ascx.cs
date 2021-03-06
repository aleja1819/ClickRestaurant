﻿using Pizza_Express_visual.Services;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Pizza_Express_visual.Components
{
    public partial class components_Usuarios : System.Web.UI.UserControl
    {
        private QueryUsuario accesoUsuario = new QueryUsuario();

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

                trut.Text = "";
                tnombre.Text = "";
                temail.Text = "";
                tclave.Text = "";
                fTipoUsuario.SelectedIndex = 0;
                fEstado.SelectedIndex = 0;

            }
        }

        protected void bRegistrarUsuarioModal_Click(object sender, EventArgs e) //MODAL 
        {
            alerta.Visible = false;
            idregistrar.Visible = true;
            ideditarUsuarioBoton.Visible = false;

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
            uModalUsuario.Update();
            uContenedorUsuario.Update();

        }

        protected void idTabla_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            alerta.Visible = false;
            idregistrar.Visible = false;
            ideditarUsuarioBoton.Visible = true;

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

        private void MostrarError(TextBox t, Label l, int r)
        {

            if (r == 0)
            {
                t.CssClass = "form-control is-invalid";
                l.CssClass = "invalid-feedback";
            }
            else
            {
                t.CssClass = "form-control is-valid";
                l.CssClass = "valid-feedback";
            }
        }

        private bool validaCampos()
        {

            bool correcto = true;

            if (trut.Text.Equals(""))
            {
                MostrarError(trut, valida_trut, 0);
                correcto = false;
            }
            else
            {
                MostrarError(trut, valida_trut, 1);
            }
            if (tnombre.Text.Equals(""))
            {
                MostrarError(tnombre, valida_tnombre, 0);
                correcto = false;
            }
            else
            {
                MostrarError(tnombre, valida_tnombre, 1);
            };

            if (temail.Text.Equals(""))
            {
                MostrarError(temail, valida_temail, 0);
                correcto = false;
            }
            else
            {
                MostrarError(temail, valida_temail, 1);
            }
            if (tclave.Text.Equals(""))
            {
                MostrarError(tclave, valida_tcalve, 0);
                correcto = false;
            }
            else
            {
                MostrarError(tclave, valida_tcalve, 1);
            }
            return correcto;
        }

        protected void idregistrarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (validaCampos() == false)
                {

                }
                else
                {

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

                    idTabla.DataSource = accesoUsuario.filtrarUsuarios();
                    idTabla.DataBind();

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                    uModalUsuario.Update();
                    uContenedorUsuario.Update();

                    limpiarTodo(2);

                    alerta.Visible = true;
                    alerta.CssClass = "alert alert-primary animated zoomInUp";
                    mensaje3.Text = "DATOS INGRESADOS CON EXITO,USUARIO AGREGADO.";

                }
            }
            catch (Exception)
            {
                alerta.Visible = true;
                alerta.CssClass = "alert alert-danger animated zoomInUp";
                mensaje3.Text = "DATOS INCORRECTOS,USUARIO NO AGREGADO.";
            }
        }

        protected void idBuscarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                alerta.Visible = false;
                int filtro = Convert.ToInt32(idOpciones.SelectedValue);

                int cant = accesoUsuario.BuscarUsuarios(tdatoBuscar.Text, filtro).Count;

                idTabla.DataSource = accesoUsuario.BuscarUsuarios(tdatoBuscar.Text, filtro);
                idTabla.DataBind();

                uModalUsuario.Update();
                uContenedorUsuario.Update();

                alerta.Visible = true;
                alerta.CssClass = "alert alert-primary animated zoomInUp";
                mensaje3.Text = "USUARIO ECONTRADO.";

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
                else
                {
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

        protected void idTabla_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                int filtro = Convert.ToInt32(idOpciones.SelectedValue);
                idTabla.PageIndex = e.NewPageIndex;
                idTabla.DataSource = accesoUsuario.filtrarUsuarios();
                idTabla.DataBind();

            }
            catch (Exception)
            {

            }
        }

        protected void btnVolverU_Click(object sender, EventArgs e)
        {
            alerta.Visible = false;
            idTabla.DataSource = accesoUsuario.filtrarUsuarios();
            idTabla.DataBind();
        }
    }
}

