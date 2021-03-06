﻿using Pizza_Express_visual.Services;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Pizza_Express_visual.Components
{
    public partial class components_Reservas : System.Web.UI.UserControl
    {

        private QueryReservas accesoReservas = new QueryReservas();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                idTabla.DataSource = accesoReservas.filtrarReservas();
                idTabla.DataBind();

                uModalReserva.Update();
                uContenedorReservas.Update();
            }
        }

        protected void bRegistrarReservarModal_Click(object sender, EventArgs e)
        {
            alerta.Visible = false; 
            ideditarReservaBoton.Visible = false;
            idregistrarReservas.Visible = true;

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
            uModalReserva.Update();
            uContenedorReservas.Update();
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

            if (tnMesa.Text.Equals(""))
            {
                MostrarError(tnMesa, valida_tnMesa, 0);
                correcto = false;
            }
            else
            {
                MostrarError(tnMesa, valida_tnMesa, 1);
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

            if (tfecha.Text.Equals(""))
            {
                MostrarError(tfecha, valida_tfecha, 0);
                correcto = false;
            }
            else
            {
                MostrarError(tfecha, valida_tfecha, 1);
            }

            return correcto;
        }

        protected void idregistrarReservas_Click(object sender, EventArgs e)
        {
            alerta.Visible = false;
            try
            {

                if (validaCampos() == false)
                {

                }
                else
                {

                    //LEER LOS DATOS INGRESADOS
                    string nuMesa = tnMesa.Text;
                    string nombre_R = tnombre.Text;
                    string fecha = tfecha.Text;
                    string hor = thora.Text;

                    DateTime date = Convert.ToDateTime(tfecha.Text);
                    int numeMesa = Convert.ToInt32(nuMesa);
                    DateTime hora = Convert.ToDateTime(thora.Text);

                    //int cod = accesoReservas.codigoMesaRegistrar(nuMesa);
                    //int idReser = 0;
                    //if (cod == -1)
                    //{

                    //}
                    //else
                    //{

                        //string numerMesa = tnMesa.Text;
                        accesoReservas.addReserva(new Models.Reserva
                        {

                            idMesa = numeMesa,
                            nombre_reserva = nombre_R,
                            fecha_reser = date,
                            hora_reser = hora.TimeOfDay

                        } /*ref idReser*/);

                        //accesoReservas.addMesa(new Models.Mesa
                        //{

                        //    numeroMesa = numerMesa,
                        //    idMesa = cod

                        //});


                        //MOSTRAR LOS DATOS EN LA TABLA
                        idTabla.DataSource = accesoReservas.filtrarReservas();
                        idTabla.DataBind();

                        limpiarTodo(3);

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                        uModalReserva.Update();
                        uContenedorReservas.Update();

                        alerta.Visible = true;
                        alerta.CssClass = "alert alert-primary animated zoomInUp";
                        mensaje3.Text = "RESERVA AGREGADA CON EXITO.";
                    }
                }

            
            catch (Exception)
            {
                alerta.Visible = true;
                alerta.CssClass = "alert alert-danger animated zoomInUp";
                mensaje3.Text = "RESERVA NO AGREGADA.";

            }
        }

        protected void idTabla_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            alerta.Visible = false;
            ideditarReservaBoton.Visible = true;
            idregistrarReservas.Visible = false;
            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("ideditar"))
            {

                c_orginal.Text = idTabla.Rows[fila].Cells[0].Text;
                tnMesa.Text = idTabla.Rows[fila].Cells[1].Text;
                tnombre.Text = idTabla.Rows[fila].Cells[2].Text.Replace("&#241;", "ñ").Replace("&#233;", "é").Replace("&#250;", "ú").Replace("&#237;", "í").Replace("&#243;", "ó").Replace("&#225;", "á"); ;
                tfecha.Text = idTabla.Rows[fila].Cells[3].Text;

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('show');", true);
                uModalReserva.Update();
                uContenedorReservas.Update();

            }
            else if (e.CommandName.Equals("ideliminar"))
            {

                // ELIMINAR UN PRODUCTO DE LA LISTA
                string codigo = idTabla.Rows[fila].Cells[0].Text;
                int id = Convert.ToInt32(codigo);
                accesoReservas.eliminarReserva(id);
                idTabla.DataSource = accesoReservas.filtrarReservas();
                idTabla.DataBind();

                alerta.Visible = true;
                alerta.CssClass = "alert alert-primary animated zoomInUp";
                mensaje3.Text = "RESERVA ELIMINADA CON EXITO.";

            }
        }

        private void limpiarTodo(int op)
        {

            if (op == 1)
            {
                tnMesa.Text = "";
                tnombre.Text = "";
                tfecha.Text = "";
            }
            else
            {
                tnMesa.Text = "";
                tnombre.Text = "";
                tfecha.Text = "";
            }
        }

        protected void ideditarReservaBoton_Click(object sender, EventArgs e)
        {
            alerta.Visible = false;
            try
            {

                if (validaCampos() == false)
                {

                }
                else
                {

                    alerta.Visible = false;

                    //LEER LOS DATOS INGRESADOS
                    int nuMesa = Convert.ToInt32(tnMesa.Text);
                    string nombre_R = tnombre.Text;
                    string fecha = tfecha.Text;

                    string codigo_ori = c_orginal.Text;
                    DateTime date = Convert.ToDateTime(tfecha.Text);

                    accesoReservas.editarReservas(new Models.Reserva
                    {
                        idMesa = nuMesa,
                        nombre_reserva = nombre_R,
                        fecha_reser = date,
                    }, codigo_ori);

                    idTabla.DataSource = accesoReservas.filtrarReservas();
                    idTabla.DataBind();

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                    uModalReserva.Update();
                    uContenedorReservas.Update();

                    limpiarTodo(2);

                    alerta.Visible = true;
                    alerta.CssClass = "alert alert-primary animated zoomInUp";
                    mensaje3.Text = "RESERVA MODIFICADA CON EXITO.";

                }
            }
            catch (Exception)
            {
                alerta.Visible = true;
                alerta.CssClass = "alert alert-danger animated zoomInUp";
                mensaje3.Text = "RESERVA NO MODIFICADA.";

            }
        }

        protected void idBuscarMesa_Click(object sender, EventArgs e)
        {
            try
            {
                alerta.Visible = false;
                int filtro = Convert.ToInt32(idOpciones.SelectedValue);

                int cant = accesoReservas.BuscarReservas(tdatoBuscarReservas.Text, filtro).Count;

                idTabla.DataSource = accesoReservas.BuscarReservas(tdatoBuscarReservas.Text, filtro);
                idTabla.DataBind();

                uModalReserva.Update();
                uContenedorReservas.Update();

                alerta.Visible = true;
                alerta.CssClass = "alert alert-primary animated zoomInUp";
                mensaje3.Text = "RESERVA ECONTRADO.";

                if (cant == 0)
                {
                    alerta.Visible = true;
                    alerta.CssClass = "alert alert-danger animated zoomInUp";
                    mensaje3.Text = "RESERVA NO ECONTRADO.";
                }

            }
            catch (Exception)
            {

            }
        }

        protected void idTabla_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                alerta.Visible = false;
                int filtro = Convert.ToInt32(idOpciones.SelectedValue);
                idTabla.PageIndex = e.NewPageIndex;
                idTabla.DataSource = accesoReservas.filtrarReservas();
                idTabla.DataBind();

            }
            catch (Exception)
            {

            }
        }
        protected void btnVolverR_Click(object sender, EventArgs e)
        {
            alerta.Visible = false;
            idTabla.DataSource = accesoReservas.filtrarReservas();
            idTabla.DataBind();
        }
    }
}


