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
                mensaje.Visible = true;
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

                
                //GUARDAR LOS DATOS EN LA LISTA
                accesoProveedor.addProveedor(new Models.Proveedor
                {
                    
                    rut_proveedor = rut_u,
                    nombre_proveedor = nombre_u,
                    apellido_paterno_proveedor = apellP,
                    apellido_materno_proveedor = apellM,
                    direccion_proveedor = direccion,
                    TipoProducto = tipo_P


                });

                //MOSTRAR LOS DATOS EN LA TABLA
                idTabla.DataSource = accesoProveedor.filtrarProveedor();
                idTabla.DataBind();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                uModalProveedor.Update();
                uContenedorProveedor.Update();


                limpiarTodo(2);

            }
            catch (Exception)
            {
                mensaje.Text = "NO AGREGADO";

            }
        }

        protected void idTabla_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("ideditar"))
            {

                //trut.Text = idTabla.Rows[fila].Cells[0].Text;
                //tnombre.Text = idTabla.Rows[fila].Cells[1].Text;
                //tapellidoP.Text = idTabla.Rows[fila].Cells[2].Text;
                //tapellidoM.Text = idTabla.Rows[fila].Cells[3].Text;
                //tdireccion.Text = idTabla.Rows[fila].Cells[4].Text;
                //fTipoProducto.Text = idTabla.Rows[fila].Cells[5].Text;

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

                mensaje.Visible = true;
                mensaje.Text = "proveedor eliminado";

            }
        }

        protected void ideditarProveedorBoton_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
            uModalProveedor.Update();
            uContenedorProveedor.Update();
        }

        protected void idBuscarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                int filtro = Convert.ToInt32(idOpciones.SelectedValue);

                int cant = accesoProveedor.BuscarProveedor(tdatoBuscarProveedor.Text, filtro).Count;

                idTabla.DataSource = accesoProveedor.BuscarProveedor(tdatoBuscarProveedor.Text, filtro);
                idTabla.DataBind();

                uContenedorProveedor.Update();
                uModalProveedor.Update();

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
    
