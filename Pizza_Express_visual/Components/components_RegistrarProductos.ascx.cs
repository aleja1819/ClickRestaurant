using Pizza_Express_visual.Services;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Pizza_Express_visual.Components
{
    public partial class components_RegistrarProductos : System.Web.UI.UserControl
    {
        private QueryProductos accesoProductos = new QueryProductos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

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
            alerta.Visible = true;
            beditarProductoBoton.Visible = false;
            bregistrarProducto.Visible = true;

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
            uModalProducto.Update();
            uContenedorProducto.Update();
        }

        protected void bregistrarProveedor_Click(object sender, EventArgs e)
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
                    string nombreProducto = tnombre.Text;
                    string rutProveedor = trut.Text;
                    string fecha = tfecha.Text;
                    string cantidad = tcantidad.Text;
                    int cod = accesoProductos.codigoProveedor(rutProveedor);
                    int idProd = 0;
                    if (cod == -1)
                    {

                    }
                    else
                    {
                        //GUARDAR LOS DATOS EN LA LISTA
                        accesoProductos.addProducto(new Models.Producto
                        {

                            nombre_producto = nombreProducto,
                            codigo_usuario = 4

                        }, ref idProd);


                        DateTime t = DateTime.Now;

                        int cant = Convert.ToInt32(tcantidad.Text);

                        accesoProductos.addProd_Prove(new Models.Producto_Proveedor
                        {

                            fecha_ingreso_producto = t,
                            codigo_producto = idProd,
                            cantidad_producto = cant,
                            codigo_proveedor = cod
                        }); 

                        //MOSTRAR LOS DATOS EN LA TABLA
                        idTabla.DataSource = accesoProductos.filtrarProductos();
                        idTabla.DataBind();

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                        uModalProducto.Update();
                        uContenedorProducto.Update();

                        limpiarTodo(2);

                        alerta.Visible = true;
                        alerta.CssClass = "alert alert-primary animated zoomInUp";
                        mensaje3.Text = "PRODUCTO AGREGADO CON EXITO.";

                        bregistrarProducto.Visible = false;
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
            beditarProductoBoton.Visible = true;

            int fila = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName.Equals("ideditar"))
            {
                cod_OriProve.Text = idTabla.Rows[fila].Cells[0].Text;
                cod_orginal.Text = idTabla.Rows[fila].Cells[0].Text;
                tnombre.Text = idTabla.Rows[fila].Cells[1].Text.Replace("&#241;", "ñ").Replace("&#233;", "é").Replace("&#250;", "ú").Replace("&#237;", "í").Replace("&#243;", "ó").Replace("&#225;", "á"); ;
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
                string codigoProducto = idTabla.Rows[fila].Cells[0].Text;
                string RutProveedor = idTabla.Rows[fila].Cells[2].Text;

                int idProd = Convert.ToInt32(codigoProducto);
                int idProve = accesoProductos.codigoProveedor(RutProveedor);

                accesoProductos.eliminarProductoProvee(idProd, idProve);

                accesoProductos.eliminarProducto(idProd);

                idTabla.DataSource = accesoProductos.filtrarProductos();
                idTabla.DataBind();

                alerta.Visible = true;
                alerta.CssClass = "alert alert-primary animated zoomInUp";
                mensaje3.Text = "PRODUCTO ELIMANDO CON EXITO.";

            }
            else
            {
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

                alerta.Visible = true;
                alerta.CssClass = "alert alert-primary animated zoomInUp";
                mensaje3.Text = "PRODUCTO ENCONTRADO.";

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

        protected void beditarProductoBoton_Click(object sender, EventArgs e)
        {

            try
            {
                alerta.Visible = false;
                if (validaCampos() == false)
                {

                }
                else
                {

                    string nombre_Produc = tnombre.Text;
                    string rut_Prove = trut.Text;
                    string fecha = tfecha.Text;
                    string cantidad = tcantidad.Text;
                    int cod = accesoProductos.codigoProveedor(rut_Prove);
                    int idProd = 0;
                    if (cod == -1)
                    {

                    }
                    else
                    {
                        string cod_prove = cod_OriProve.Text;
                        string codigo_original = cod_orginal.Text;
                        int cod_O = Convert.ToInt32(codigo_original);
                        int cod_prov = Convert.ToInt32(cod_prove);

                        accesoProductos.editarProducto(new Models.Producto
                        {

                            nombre_producto = nombre_Produc,
                            codigo_usuario = 2

                        }, cod_O);

                        DateTime t = DateTime.Now;

                        int cant = Convert.ToInt32(tcantidad.Text);

                        accesoProductos.editarProductoProveedor(new Models.Producto_Proveedor
                        {

                            fecha_ingreso_producto = t,
                            codigo_producto = idProd,
                            cantidad_producto = cant,
                            codigo_proveedor = cod

                        }, cod_prov);

                        idTabla.DataSource = accesoProductos.filtrarProductos();
                        idTabla.DataBind();

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                        uModalProducto.Update();
                        uContenedorProducto.Update();

                        limpiarTodo(2);

                        alerta.Visible = true;
                        alerta.CssClass = "alert alert-primary animated zoomInUp";
                        mensaje3.Text = "PRODUCTO ACTUALIZADO CON EXITO.";


                    }
                }

            }
            catch (Exception)
            {
                alerta.Visible = true;
                alerta.CssClass = "alert alert-danger animated zoomInUp";
                mensaje3.Text = "PRODUCTO NO ACTUALIZADO.";
            }
        }

        protected void btnVolverPr_Click(object sender, EventArgs e)
        {
            alerta.Visible = false;
            idTabla.DataSource = accesoProductos.filtrarProductos();
            idTabla.DataBind();

        }
        protected void idTabla_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                alerta.Visible = false;
                int filtro = Convert.ToInt32(idOpciones.SelectedValue);
                idTabla.PageIndex = e.NewPageIndex;
                idTabla.DataSource = accesoProductos.filtrarProductos();
                idTabla.DataBind();

            }
            catch (Exception)
            {

            }
        }
    }
}


