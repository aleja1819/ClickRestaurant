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

                //LEER LOS DATOS INGRESADOS
                string nombre_Produc = tnombre.Text;
                string rut_Prove = trut.Text;
                string fecha = tfecha.Text;
                string cantidad = tcantidad.Text;
                int cod = accesoProductos.codigoProvee(rut_Prove);
                int idProd = 0;
                if (cod == -1)
                {
                    mensaje.Text = "-------------";
                }
                else
                {

                
                //GUARDAR LOS DATOS EN LA LISTA
                accesoProductos.addProducto(new Models.Producto
                {
            
                   nombre_producto = nombre_Produc, 
                   codigo_usuario=2

                },ref idProd);

                DateTime t = DateTime.Now;
                
                int cant = Convert.ToInt32(tcantidad.Text);
             
                accesoProductos.addProd_Prove(new Models.Producto_Proveedor
                {
                    
                    fecha_ingreso_producto = t,
                    codigo_producto= idProd,
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

                }
            }
            catch (Exception)
            {


            }
        }

        protected void idTabla_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("ideditar"))
            {

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

                mensaje.Visible = true;
                mensaje.Text = "proveedor eliminado";

            }
        }

        protected void bBuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                int filtro = Convert.ToInt32(idOpciones.SelectedValue);

                int cant = accesoProductos.BuscarProductos(tdatoBuscarProducto.Text, filtro).Count;

                idTabla.DataSource = accesoProductos.BuscarProductos(tdatoBuscarProducto.Text, filtro);
                idTabla.DataBind();

                uContenedorProducto.Update();
                uModalProducto.Update();

                mensaje.Text = "Usuario encontrado";
                if (cant == 0)
                {
                    mensaje.Visible = true;
                    mensaje.Text = "Usuario no encontrado";
                }

            }
            catch (Exception)
            {

            }
        }

    }
  }
