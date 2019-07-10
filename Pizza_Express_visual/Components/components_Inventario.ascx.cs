using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Pizza_Express_visual.Services;
namespace Pizza_Express_visual.Components
{
    public partial class components_Inventario : System.Web.UI.UserControl
    {
        private QueryProductos accesoProductos = new QueryProductos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //PARA MOSTRAR LOS PRODUCTOS DE LA BASE DE DATOS
                idTablaInven.DataSource = accesoProductos.filtrarProductos();
                idTablaInven.DataBind();

            }
        }

        private void limpiarTodo(int op)
        {

            if (op == 1)
            {

                tcantidad.Text = "";

            }
            else
            {
                //AL GUARDAR UN PRODUCTO
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

        protected void idTabla_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            alerta.Visible = false;
            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("ideditar"))
            {
                cod_OriProve.Text = idTablaInven.Rows[fila].Cells[0].Text;
                cod_orginal.Text = idTablaInven.Rows[fila].Cells[0].Text;
                tnombre.Text = idTablaInven.Rows[fila].Cells[1].Text.Replace("&#241;", "ñ").Replace("&#233;", "é").Replace("&#250;", "ú").Replace("&#237;", "í").Replace("&#243;", "ó").Replace("&#225;", "á"); ;
                trut.Text = idTablaInven.Rows[fila].Cells[2].Text;
                tfecha.Text = idTablaInven.Rows[fila].Cells[3].Text;
                tcantidad.Text = idTablaInven.Rows[fila].Cells[4].Text;

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
                uModalProducto.Update();
                uContenedorProducto.Update();
            }
        }

        protected void bBuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                alerta.Visible = false;
                int filtro = Convert.ToInt32(idOpciones.SelectedValue);

                int cant = accesoProductos.BuscarProductos(tdatoBuscarProducto.Text, filtro).Count;

                idTablaInven.DataSource = accesoProductos.BuscarProductos(tdatoBuscarProducto.Text, filtro);
                idTablaInven.DataBind();

                uContenedorProducto.Update();
                uModalProducto.Update();
              

                if (cant == 0)
                {
                    alerta.Visible = true;
                    alerta.CssClass = "alert alert-danger animated zoomInUp";
                    mensaje3.Text = "PRODUCTO NO ENCONTRADO.";
                    alerta.Visible = false;
                }

            }
            catch (Exception)
            {
                alerta.Visible = false;
            }
        }

        protected void beditarProductorBoton_Click(object sender, EventArgs e)
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
                        string cod_prove = cod_OriProve.Text;
                        string codigo_original = cod_orginal.Text;
                        int cod_O = Convert.ToInt32(codigo_original);
                        int cod_prov = Convert.ToInt32(cod_prove);

                        //EDITAR LOS DATOS
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

                        //MOSTRAR LOS DATOS EN LA TABLA
                        idTablaInven.DataSource = accesoProductos.filtrarProductos();
                        idTablaInven.DataBind();

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                        uModalProducto.Update();
                        uContenedorProducto.Update();

                        limpiarTodo(2);

                        alerta.Visible = true;
                        alerta.CssClass = "alert alert-primary animated zoomInUp";
                        mensaje3.Text = "PRODUCTO INVENTARIO MODIFICADO CON EXITO.";
                    }
                }

            }
            catch (Exception)
            {
                alerta.Visible = true;
                alerta.CssClass = "alert alert-danger animated zoomInUp";
                mensaje3.Text = "PRODUCTO INVENTARIO NO MODIFICADO.";
            }
        }

        protected void idTablaInven_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                int filtro = Convert.ToInt32(idOpciones.SelectedValue);
                idTablaInven.PageIndex = e.NewPageIndex;
                idTablaInven.DataSource = accesoProductos.filtrarProductos();
                idTablaInven.DataBind();

            }
            catch (Exception)
            {

            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            alerta.Visible = false;
            idTablaInven.DataSource = accesoProductos.filtrarProductos();
            idTablaInven.DataBind();
            alerta.Visible = false;
        }
    }
}
    