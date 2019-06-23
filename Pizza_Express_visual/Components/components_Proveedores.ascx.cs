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
        private QueryTipoProducto accesoTipoProducto = new QueryTipoProducto();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //PARA MOSTRAR LOS PROVEEDORES DE LA BASE DE DATOS
                idTabla.DataSource = accesoProveedor.filtrarProveedor();
                idTabla.DataBind();

                //MOSTRAR LA LISTA DE LOS TIPOS DE USUARIOS DE LA BASE DE DATOS
                fTipoProducto.DataSource = accesoTipoProducto.FiltroTipoProducto();
                fTipoProducto.DataBind();
                uContenedorProveedor.Update();
                uModalUsuario.Update();

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

        protected void bRegistrarProveedorModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
            uModalUsuario.Update();
            uContenedorProveedor.Update();
        }

        protected void idregistrarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                
                //LEER LOS DATOS INGRESADOS
                string rut_u = trut.Text;
                string nombre_u = tnombre.Text;
                string apellP = tapellidoP.Text;
                string apellM = tapellidoM.Text;
                string direccion = tdireccion.Text;

                int id = Convert.ToInt32(fTipoProducto.SelectedItem.Value);
                Models.TipoProducto tipo_P = new Models.TipoProducto
                {
                    codigo_tipoProducto = id,
                    nombre_tipoProducto = fTipoProducto.SelectedItem.Text
                };

                int dire = Convert.ToInt32(tdireccion.Text);
                //GUARDAR LOS DATOS EN LA LISTA
                accesoProveedor.addProveedor(new Models.Proveedor
                {
                    
                    rut_proveedor = rut_u,
                    nombre_proveedor = nombre_u,
                    apellido_paterno_proveedor = apellP,
                    apellido_materno_proveedor = apellM,
                    direccion_proveedor = dire,
                    TipoProducto = tipo_P


                });

                //MOSTRAR LOS DATOS EN LA TABLA
                idTabla.DataSource = accesoProveedor.filtrarProveedor();
                idTabla.DataBind();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                uModalUsuario.Update();
                uContenedorProveedor.Update();


                limpiarTodo(2);

            }
            catch (Exception)
            {
                

            }
        }
    }



    }
    
