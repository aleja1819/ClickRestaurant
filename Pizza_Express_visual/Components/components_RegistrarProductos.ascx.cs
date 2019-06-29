using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Pizza_Express_visual.Services;
namespace Pizza_Express_visual.Components
{
    public partial class components_RegistrarProductos : System.Web.UI.UserControl
    {
        private QueryProductos accesoProductos = new QueryProductos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //PARA MOSTRAR LOS PRODUCTOS DE LA BASE DE DATOS
                idTabla.DataSource = accesoProductos.filtrarProductos();
                idTabla.DataBind();

            }
        }

        private void limpiarTodo(int op)
        {

            if (op == 1)
            {
                trut.Text = "";
                tnombre.Text = "";
                tfecha.Text = "";
                tcantidad.Text = "";

            }
            else
            {
                //AL GUARDAR UN PRODUCTO
                trut.Text = "";
                tnombre.Text = "";
                tfecha.Text = "";
                tcantidad.Text = "";
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

            if (tfecha.Text.Equals(""))
            {
                MostrarError(tfecha, valida_tfecha, 0);
                correcto = false;
            }
            else
            {
                MostrarError(tfecha, valida_tfecha, 1);
            }
            if (tcantidad.Text.Equals(""))
            {
                MostrarError(tcantidad, valida_tcantidad, 0);
                correcto = false;
            }
            else
            {
                try
                {
                    Convert.ToInt32(tcantidad.Text);
                    MostrarError(tcantidad, valida_tcantidad, 1);
                }
                catch (Exception)
                {
                    MostrarError(tcantidad, valida_tcantidad, 0);
                    correcto = false;
                }
            }
            return correcto;
        }



        protected void bRegistrarProductoModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
            uModalProducto.Update();
            uContenedorProducto.Update();
        }

        protected void bregistrarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (validaCampos() == false)
                {

                }
                else { 


                    //LEER LOS DATOS INGRESADOS
                    string nombre_Produc = tnombre.Text;
                    string rut_Prove = trut.Text;
                    string fecha = tfecha.Text;
                    string cantidad = tcantidad.Text;
                    int cod = accesoProductos.codigoProvee(rut_Prove);
                    int idProd = 0;
                    if (cod == -1)
                    {

                    }
                    else
                    {

                        //GUARDAR LOS DATOS EN LA LISTA
                        accesoProductos.addProducto(new Models.Producto
                        {

                            nombre_producto = nombre_Produc,
                            codigo_usuario = 2

                        }, ref idProd);

                        DateTime t = DateTime.Now;

                        int cant = Convert.ToInt32(tcantidad.Text);

                        accesoProductos.addProd_Prove(new Models.Producto_Proveedor
                        {

                            fecha_ingreso_producto = t,
                            codigo_producto = idProd,
                            cantidad_producto = cant,
                            codigo_proveedor = cod
                        }); ;

                        //MOSTRAR LOS DATOS EN LA TABLA
                        idTabla.DataSource = accesoProductos.filtrarProductos();
                        idTabla.DataBind();

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                        uModalProducto.Update();
                        uContenedorProducto.Update();

                        limpiarTodo(2);

                        alerta.Visible = true;
                        alerta.CssClass = "alert alert-warning animated zoomInUp";
                        mensaje3.Text = "PRODUCTO AGREGADO CON EXITO.";

                    }
                }
            }
            catch (Exception)
            {
                alerta.Visible = true;
                alerta.CssClass = "alert alert-danger animated zoomInUp";
                mensaje3.Text = "PRODUCTO NO AGREGADO.";

            }
        }

        protected void idTabla_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            alerta.Visible = false;
            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("ideditar"))
            {
                cod_orginal.Text = idTabla.Rows[fila].Cells[0].Text;
                tnombre.Text = idTabla.Rows[fila].Cells[1].Text;
                trut.Text = idTabla.Rows[fila].Cells[2].Text;
                tfecha.Text = idTabla.Rows[fila].Cells[3].Text;
                tcantidad.Text = idTabla.Rows[fila].Cells[4].Text;

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
                uModalProducto.Update();
                uContenedorProducto.Update();


            }
            else if (e.CommandName.Equals("ideliminar"))
            {
                // ELIMINAR UN PROVEEDOR
                string codigo = idTabla.Rows[fila].Cells[0].Text;
                int id = Convert.ToInt32(codigo);
                accesoProductos.eliminarProducto(id);

                idTabla.DataSource = accesoProductos.filtrarProductos();
                idTabla.DataBind();

                alerta.Visible = true;
                alerta.CssClass = "alert alert-danger animated zoomInUp";
                mensaje3.Text = "PRODUCTO ELIMANDO CON EXITO.";

            }
            else {
                alerta.Visible = true;
                alerta.CssClass = "alert alert-danger animated zoomInUp";
                mensaje3.Text = "PRODUCTO NO ELIMINADO.";
            }
        }

        protected void bBuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                alerta.Visible = false;
                int filtro = Convert.ToInt32(idOpciones.SelectedValue);

                int cant = accesoProductos.BuscarProductos(tdatoBuscarProducto.Text, filtro).Count;

                idTabla.DataSource = accesoProductos.BuscarProductos(tdatoBuscarProducto.Text, filtro);
                idTabla.DataBind();

                uContenedorProducto.Update();
                uModalProducto.Update();


                if (cant == 0)
                {
                    alerta.Visible = true;
                    alerta.CssClass = "alert alert-danger animated zoomInUp";
                    mensaje3.Text = "PRODUCTO NO ENCONTRADO.";
                }

            }
            catch (Exception)
            {

            }
        }

        protected void beditarProveedorBoton_Click(object sender, EventArgs e)
        {


            try
            {
                //LEER LOS DATOS INGRESADOS
                string nombre_Produc = tnombre.Text;
                string rut_Prove = trut.Text;
                string fecha = tfecha.Text;
                string cantidad = tcantidad.Text;
                int cod = accesoProductos.codigoProvee(rut_Prove);
                int idProd = 0;
                if (cod == -1)
                {

                }
                else
                {
                    string codigo_original = cod_orginal.Text;

                    //EDITAR LOS DATOS
                    accesoProductos.editarProducto(new Models.Producto
                    {

                        nombre_producto = nombre_Produc,
                        codigo_usuario = 2

                    }, codigo_original);

                    DateTime t = DateTime.Now;
                    int cant = Convert.ToInt32(tcantidad.Text);
                    int rut_P = Convert.ToInt32(trut.Text);

                    accesoProductos.editarProductoProveedor(new Models.Producto_Proveedor
                    {

                        fecha_ingreso_producto = t,
                        codigo_producto = idProd,
                        cantidad_producto = cant,
                        codigo_proveedor = cod

                    }, codigo_original);

                    //MOSTRAR LOS DATOS EN LA TABLA
                    idTabla.DataSource = accesoProductos.filtrarProductos();
                    idTabla.DataBind();

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                    uModalProducto.Update();
                    uContenedorProducto.Update();

                    limpiarTodo(2);

                }
            }
            catch (Exception)
            {

            }
        }
    }
    
}
