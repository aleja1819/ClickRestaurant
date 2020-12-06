using Pizza_Express_visual.Services;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Pizza_Express_visual.Components
{
    public partial class components_CartaMenu : System.Web.UI.UserControl
    {

        private QueryMenu accesoMenu = new QueryMenu();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                idTabla.DataSource = accesoMenu.filtrarMenu();
                idTabla.DataBind();

                uModalMenu.Update();
                uContenedorMenu.Update();

                ftamano.DataSource = accesoMenu.filtrarTamanoP();
                ftamano.DataBind();

                uModalMenu.Update();
                uContenedorMenu.Update();

                fcategoria.DataSource = accesoMenu.filtrarCategoria();
                fcategoria.DataBind();

                uModalMenu.Update();
                uContenedorMenu.Update();

            }
        }

        protected void bRegistrarMenu_Click(object sender, EventArgs e)
        {
            alerta.Visible = false;
            ideditarMenuBoton.Visible = false;
            idregistrarMenu.Visible = true;

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
            uModalMenu.Update();
            uContenedorMenu.Update();
        }

        private void limpiarTodo(int opcion)
        {

            if (opcion == 1)
            {
                tnombre.Text = "";
                tprecio.Text = "";
                tingredientes.Text = "";
                ftamano.SelectedIndex = 0;
                fcategoria.SelectedIndex = 0;
            }
            else
            {
                //AL GUARDAR UN PRODUCTO
                tnombre.Text = "";
                tprecio.Text = "";
                tingredientes.Text = "";
                ftamano.SelectedIndex = 0;
                fcategoria.SelectedIndex = 0;

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

            if (tnombre.Text.Equals(""))
            {
                MostrarError(tnombre, valida_tnombre, 0);
                correcto = false;
            }
            else
            {
                MostrarError(tnombre, valida_tnombre, 1);
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

            if (tprecio.Text.Equals(""))
            {
                MostrarError(tprecio, valida_tprecio, 0);
                correcto = false;
            }
            else
            {
                try
                {
                    Convert.ToInt32(tprecio.Text);
                    MostrarError(tprecio, valida_tprecio, 1);
                }
                catch (Exception)
                {
                    MostrarError(tprecio, valida_tprecio, 0);
                    correcto = false;
                }
            }

            if (tingredientes.Text.Equals(""))
            {
                MostrarError(tingredientes, valida_tingrediente, 0);
                correcto = false;
            }
            else
            {
                MostrarError(tingredientes, valida_tingrediente, 1);
            }
            return correcto;
        }

        protected void idregistrarMenu_Click(object sender, EventArgs e)
        {
            try
            {

                if (validaCampos() == false)
                {

                }
                else
                {

                    //LEER LOS DATOS INGRESADOS
                    string nombre_P = tnombre.Text;
                    string precio_p = tprecio.Text;
                    string ingredientes_p = tingredientes.Text;

                    int idTa = Convert.ToInt32(ftamano.SelectedItem.Value);
                    int idCat = Convert.ToInt32(fcategoria.SelectedItem.Value);
                    int prec = Convert.ToInt32(precio_p);

                    //GUARDAR LOS DATOS EN LA LISTA
                    accesoMenu.addMenu(new Models.Menu
                    {

                        nombre_menu = nombre_P,
                        precio_menu = prec,
                        ingredientes_menu = ingredientes_p,
                        codigo_tamanoP = idTa,
                        codigo_categoria = idCat

                    });

                    //MOSTRAR LOS DATOS EN LA TABLA
                    idTabla.DataSource = accesoMenu.filtrarMenu();
                    idTabla.DataBind();

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                    uModalMenu.Update();
                    uContenedorMenu.Update();

                    limpiarTodo(2);

                    alerta.Visible = true;
                    alerta.CssClass = "alert alert-primary animated zoomInUp";
                    mensaje3.Text = "CARTA MENÚ CREADA CON EXITO.";

                }
            }
            catch (Exception)
            {
                alerta.Visible = true;
                alerta.CssClass = "alert alert-danger animated zoomInUp";
                mensaje3.Text = "CARTA MENÚ NO AGREGADA.";
            }
        }

        protected void ideditarMenuBoton_Click(object sender, EventArgs e)
        {
            try
            {
                if (validaCampos() == false)
                {

                }
                else
                {
                

                //LEER LOS DATOS INGRESADOS
                string nombre_P = tnombre.Text;
                string precio_p = tprecio.Text;
                string ingredientes_p = tingredientes.Text;

                string codi_original = cod_orginal.Text;
                int idTa = Convert.ToInt32(ftamano.SelectedItem.Value);
                int idCat = Convert.ToInt32(fcategoria.SelectedItem.Value);
                int prec = Convert.ToInt32(precio_p);

                accesoMenu.editarMenu(new Models.Menu
                {

                    nombre_menu = nombre_P,
                    precio_menu = prec,
                    ingredientes_menu = ingredientes_p,
                    codigo_tamanoP = idTa,
                    codigo_categoria = idCat

                }, codi_original);

                //MOSTRAR LOS DATOS EN LA TABLA
                idTabla.DataSource = accesoMenu.filtrarMenu();
                idTabla.DataBind();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                uModalMenu.Update();
                uContenedorMenu.Update();


                limpiarTodo(2);

                alerta.Visible = true;
                alerta.CssClass = "alert alert-primary animated zoomInUp";
                mensaje3.Text = "MENÚ MODIFICADO CON EXITO.";

                }
            }
            catch (Exception)
            {
                alerta.Visible = true;
                alerta.CssClass = "alert alert-danger animated zoomInUp";
                mensaje3.Text = "MENÚ NO MODIFICADO.";

            }

        }

        protected void idTabla_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            alerta.Visible = false;
            ideditarMenuBoton.Visible = true;
            idregistrarMenu.Visible = false;


            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("ideditar"))
            {

                cod_orginal.Text = idTabla.Rows[fila].Cells[0].Text;
                tnombre.Text = idTabla.Rows[fila].Cells[1].Text.Replace("&#241;", "ñ").Replace("&#233;", "é").Replace("&#250;", "ú").Replace("&#237;", "í").Replace("&#243;", "ó").Replace("&#225;", "á");
                tprecio.Text = idTabla.Rows[fila].Cells[2].Text.Replace(".", "").Replace("$", "");
                tingredientes.Text = idTabla.Rows[fila].Cells[3].Text.Replace("&#241;", "ñ").Replace("&#233;", "é").Replace("&#250;", "ú").Replace("&#237;", "í").Replace("&#243;", "ó").Replace("&#225;", "á");

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('show');", true);
                uModalMenu.Update();
                uContenedorMenu.Update();

            }
            else if (e.CommandName.Equals("ideliminar"))
            {

                // ELIMINAR UN PRODUCTO DE LA LISTA
                string codigo = idTabla.Rows[fila].Cells[0].Text;
                int id = Convert.ToInt32(codigo);
                accesoMenu.eliminarMenu(id);
                idTabla.DataSource = accesoMenu.filtrarMenu();
                idTabla.DataBind();

                alerta.Visible = true;
                alerta.CssClass = "alert alert-primary animated zoomInUp";
                mensaje3.Text = "CARTA MENÚ ELIMINADO CON EXITO.";

            }
        }

        protected void idBuscarMenu_Click(object sender, EventArgs e)
        {
            try
            {
                alerta.Visible = false;
                int filtro = Convert.ToInt32(idOpciones.SelectedValue);

                int cant = accesoMenu.BuscarMenu(tdatoBuscar.Text, filtro).Count;

                idTabla.DataSource = accesoMenu.BuscarMenu(tdatoBuscar.Text, filtro);
                idTabla.DataBind();

                uModalMenu.Update();
                uContenedorMenu.Update();

                alerta.Visible = true;
                alerta.CssClass = "alert alert-primary animated zoomInUp";
                mensaje3.Text = "CARTA MENÚ ECONTRADA.";
                if (cant == 0)
                {
                    alerta.Visible = true;
                    alerta.CssClass = "alert alert-danger animated zoomInUp";
                    mensaje3.Text = "CARTA MENÚ NO ECONTRADA.";
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
                int filtro = Convert.ToInt32(idOpciones.SelectedValue);
                idTabla.PageIndex = e.NewPageIndex;
                idTabla.DataSource = accesoMenu.filtrarMenu();
                idTabla.DataBind();

            }
            catch (Exception)
            {
                
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            alerta.Visible = false;
            idTabla.DataSource = accesoMenu.filtrarMenu();
            idTabla.DataBind();
        }
    }
}