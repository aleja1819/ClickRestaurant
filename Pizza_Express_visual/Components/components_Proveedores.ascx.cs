using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Pizza_Express_visual.Services;
namespace Pizza_Express_visual.Components
{
    public partial class components_Proveedores : System.Web.UI.UserControl
    {
        private QueryProveedor accesoProveedor = new QueryProveedor();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //PARA MOSTRAR LOS PROVEEDORES DE LA BASE DE DATOS
                idTabla.DataSource = accesoProveedor.filtrarProveedor();
                idTabla.DataBind();

                //MOSTRAR LA LISTA DE LOS TIPOS DE USUARIOS DE LA BASE DE DATOS
                fTipoProducto.DataSource = accesoProveedor.filtrartipoProducto();
                fTipoProducto.DataBind();

                uContenedorProveedor.Update();
                uModalProveedor.Update();

            }
        }
        private void limpiarTodo(int op)
        {

            if (op == 1)
            {
                trut.Text = "";
                tnombre.Text = "";
                tapellidoP.Text = "";
                tapellidoM.Text = "";
                tdireccion.Text = "";
                fTipoProducto.SelectedIndex = 0;
            }
            else
            {

                //AL GUARDAR UN PRODUCTO

                trut.Text = "";
                tnombre.Text = "";
                tapellidoP.Text = "";
                tapellidoM.Text = "";
                tdireccion.Text = "";
                fTipoProducto.SelectedIndex = 0;

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
                MostrarError(tnombre, validar_tnombre, 0);
                correcto = false;
            }
            else
            {
                MostrarError(tnombre, validar_tnombre, 1);
            };

            if (tapellidoP.Text.Equals(""))
            {
                MostrarError(tapellidoP, validar_tapellidoP, 0);
                correcto = false;
            }
            else
            {
                MostrarError(tapellidoP, validar_tapellidoP, 1);
            }
            if (tapellidoM.Text.Equals(""))
            {
                MostrarError(tapellidoM, validar_tapellidoM, 0);
                correcto = false;
            }
            else {
                MostrarError(tapellidoM, validar_tapellidoM, 1);
            }

            if (tdireccion.Text.Equals(""))
            {
                MostrarError(tdireccion, validar_tdireccion, 0);
                correcto = false;
            }
            else {
                MostrarError(tdireccion, validar_tdireccion, 1);
            }
            return correcto;
        }

        protected void bRegistrarProveedorModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
            uModalProveedor.Update();
            uContenedorProveedor.Update();
        }

        protected void idregistrarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                alerta.Visible = false;

                if (validaCampos() == false)
                {

                }
                else
                {

                    //LEER LOS DATOS INGRESADOS
                    string rut_u = trut.Text;
                    string nombre_u = tnombre.Text;
                    string apellP = tapellidoP.Text;
                    string apellM = tapellidoM.Text;
                    string direccion = tdireccion.Text;

                    int id = Convert.ToInt32(fTipoProducto.SelectedItem.Value);

                    //GUARDAR LOS DATOS EN LA LISTA
                    accesoProveedor.addProveedor(new Models.Proveedor
                    {

                        rut_proveedor = rut_u,
                        nombre_proveedor = nombre_u,
                        apellido_paterno_proveedor = apellP,
                        apellido_materno_proveedor = apellM,
                        direccion_proveedor = direccion,
                        codigo_tipoProducto = id

                    });

                    //MOSTRAR LOS DATOS EN LA TABLA
                    idTabla.DataSource = accesoProveedor.filtrarProveedor();
                    idTabla.DataBind();

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                    uModalProveedor.Update();
                    uContenedorProveedor.Update();

                    limpiarTodo(2);

                    alerta.Visible = true;
                    alerta.CssClass = "alert alert-warning animated zoomInUp";
                    mensaje3.Text = "PROVEEDOR AGREGADO CON EXITO.";
                }
            }
            catch (Exception)
            {
                alerta.Visible = true;
                alerta.CssClass = "alert alert-danger animated zoomInUp";
                mensaje3.Text = "PROVEEDOR NO AGREGADO.";

            }
        }

        protected void idTabla_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            alerta.Visible = false;

            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("ideditar"))
            {
                codigo_orginal.Text = idTabla.Rows[fila].Cells[0].Text;
                trut.Text = idTabla.Rows[fila].Cells[1].Text;
                tnombre.Text = idTabla.Rows[fila].Cells[2].Text.Replace("&#241;", "ñ");
                tapellidoP.Text = idTabla.Rows[fila].Cells[3].Text.Replace("&#241;", "ñ");
                tapellidoM.Text = idTabla.Rows[fila].Cells[4].Text.Replace("&#241;", "ñ");
                tdireccion.Text = idTabla.Rows[fila].Cells[5].Text.Replace("&#241;", "ñ");

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
                uModalProveedor.Update();
                uContenedorProveedor.Update();


            }
            else if (e.CommandName.Equals("ideliminar"))
            {
                // ELIMINAR UN PROVEEDOR
                string codigo = idTabla.Rows[fila].Cells[0].Text;
                int id = Convert.ToInt32(codigo);
                accesoProveedor.eliminarProveedor(id);

                idTabla.DataSource = accesoProveedor.filtrarProveedor();
                idTabla.DataBind();


            }
        }

        protected void ideditarProveedorBoton_Click(object sender, EventArgs e)
        {
            try
            {
                alerta.Visible = false;
                if (validaCampos() == false)
                {

                }
                else
                {
                }

                //LEER LOS DATOS INGRESADOS
                string rut_p = trut.Text;
                string nombre_p = tnombre.Text;
                string apellidoP_p = tapellidoP.Text;
                string apellidoM_p = tapellidoM.Text;
                string direccion_p = tdireccion.Text;

                int id_tipop = Convert.ToInt32(fTipoProducto.SelectedItem.Value);
                string codigo_original = codigo_orginal.Text;

                accesoProveedor.editarProveedor(new Models.Proveedor
                {

                    rut_proveedor = rut_p,
                    nombre_proveedor = nombre_p,
                    apellido_paterno_proveedor = apellidoP_p,
                    apellido_materno_proveedor = apellidoM_p,
                    direccion_proveedor = direccion_p,
                    codigo_tipoProducto = id_tipop,

                }, codigo_original);

                //MOSTRAR LOS DATOS EN LA TABLA
                idTabla.DataSource = accesoProveedor.filtrarProveedor();
                idTabla.DataBind();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                uModalProveedor.Update();
                uContenedorProveedor.Update();


                limpiarTodo(2);

                alerta.Visible = true;
                alerta.CssClass = "alert alert-warning animated zoomInUp";
                mensaje3.Text = "USUARIO MODIFICADO CON EXITO.";

            }
            catch (Exception)
            {
                alerta.Visible = true;
                alerta.CssClass = "alert alert-danger animated zoomInUp";
                mensaje3.Text = "USUARIO NO MODIFICADO.";

            }

        }

        protected void idBuscarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                alerta.Visible = false;
                int filtro = Convert.ToInt32(idOpciones.SelectedValue);

                int cant = accesoProveedor.BuscarProveedor(tdatoBuscarProveedor.Text, filtro).Count;

                idTabla.DataSource = accesoProveedor.BuscarProveedor(tdatoBuscarProveedor.Text, filtro);
                idTabla.DataBind();

                uContenedorProveedor.Update();
                uModalProveedor.Update();
                if (cant == 0)
                {
                    alerta.Visible = true;
                    alerta.CssClass = "alert alert-danger animated zoomInUp";
                    mensaje3.Text = "PROVEEDOR NO ENCONTRADO.";
                }

            }
            catch (Exception)
            {

            }
        }
    }

    }
    
