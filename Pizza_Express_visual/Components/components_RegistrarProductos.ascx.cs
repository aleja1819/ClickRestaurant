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

                int cant = Convert.ToInt32(tcantidad.Text);
                Models.Producto_Proveedor p_pro = new Models.Producto_Proveedor
                {
                    rut_proveedor = rut_Prove,
                    //fecha_ingreso_producto = fecha,
                    cantidad_producto = cant
                };

                //GUARDAR LOS DATOS EN LA LISTA
                accesoProductos.addProducto(new Models.Producto
                {

                   nombre_producto = nombre_Produc,
                   //Producto_Proveedor = p_pro

                });

                //MOSTRAR LOS DATOS EN LA TABLA
                idTabla.DataSource = accesoProductos.filtrarProductos();
                idTabla.DataBind();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                uModalProducto.Update();
                uModalProducto.Update();
            }

            catch (Exception)
            {


            }
        }
    }
}