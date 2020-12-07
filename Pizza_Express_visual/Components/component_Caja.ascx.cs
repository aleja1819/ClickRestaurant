using Pizza_Express_visual.Services;
using Pizza_Express_visual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace Pizza_Express_visual.Components
{
    public partial class component_Caja : System.Web.UI.UserControl
    {

        private QueryCaja accesoCaja = new QueryCaja();
        private detalleCaja dcaja = new detalleCaja();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                
                idTabla.DataSource = accesoCaja.filtrarCajas();
                idTabla.DataBind();
                


                fcaja.DataSource = accesoCaja.filtrarNcaja();
                fcaja.DataBind();

                uContenedorCajaA.Update();

            }


        }

        private void limpiarTodo(int op)
        {

            if (op == 1)
            {
                tmonto.Text = "";
                fcaja.SelectedIndex = 0;
            }
            else
            {

                tmonto.Text = "";
                fcaja.SelectedIndex = 0;

            }
        }



        protected void bregistrarmonto_Click(object sender, EventArgs e)
        {


            try 
            {
                CultureInfo myCIintl = new CultureInfo("es-ES", false);
                int monto = Convert.ToInt32(tmonto.Text);
                String hora = DateTime.Now.ToString("HH:mm:ss");
                accesoCaja.addMonto(new Models.detalleCaja
                {
                    monto_apertura = monto,
                    fecha = DateTime.Today,
                    hora = Convert.ToDateTime(hora, myCIintl).TimeOfDay,
                    numero_caja = Convert.ToInt32(fcaja.SelectedItem.Value),
                    codigo_usuario = Convert.ToInt32(Session["idUser"].ToString())

                });

                idTabla.DataSource = accesoCaja.filtrarCajas();
                idTabla.DataBind();

                tmonto.Text = "";
                alerta.Visible = true;
                alerta.CssClass = "alert alert-primary animated zoomInUp";
                mensaje3.Text = "Monto ingresado con exito";


            }
            catch 
            {
                alerta.Visible = true;
                alerta.CssClass = "alert alert-danger animated zoomInUp";
                mensaje3.Text = "DATOS INCORRECTOS, MONTO NO INGRESADO";

            }

            

        }


        private void cargarCaja()
        {

            int numeroCaja = Convert.ToInt32(fcaja.SelectedItem.Value);




        }

            protected void idTabla_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {

                try
                {

                    idTabla.PageIndex = e.NewPageIndex;
                    idTabla.DataSource = accesoCaja.filtrarCajas();
                    idTabla.DataBind();

                }
                catch (Exception)
                {

                }

            }

        protected void ideditarCajaBoton_Click(object sender, EventArgs e)
        {

            try
            {
                CultureInfo myCIintl = new CultureInfo("es-ES", false);
                int monto = Convert.ToInt32(tmonto.Text);
                String hora = DateTime.Now.ToString("HH:mm:ss");
                string codigo_original = cod_orginal.Text;


                accesoCaja.editarCaja(new Models.detalleCaja
                {
                    monto_apertura = monto,
                    fecha = DateTime.Today,
                    hora = Convert.ToDateTime(hora, myCIintl).TimeOfDay,
                    numero_caja = Convert.ToInt32(fcaja.SelectedItem.Value),
                    codigo_usuario = Convert.ToInt32(Session["idUser"].ToString())

                }, codigo_original);

                idTabla.DataSource = accesoCaja.filtrarCajas();
                idTabla.DataBind();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalCaja", "$('#myModalCaja').modal('show');", true);
                uModalCaja.Update();
                uContenedorCajaA.Update();

                emonto.Text = "";
                tmonto.Text = "";

                alerta.Visible = true;
                alerta.CssClass = "alert alert-primary animated zoomInUp";
                mensaje3.Text = "MONTO MODIFICADO CON EXITO";


            }
            catch
            {
                alerta.Visible = true;
                alerta.CssClass = "alert alert-danger animated zoomInUp";
                mensaje3.Text = "DATOS INCORRECTOS, MONTO NO MODIFICADO";

            }

        }

        protected void idTabla_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            alerta.Visible = false;
            ideditarCajaBoton.Visible = true;

            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("ideditar"))
            {

                cod_orginal.Text = idTabla.Rows[fila].Cells[0].Text;
                emonto.Text = idTabla.Rows[fila].Cells[1].Text;

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalCaja", "$('#myModalCaja').modal('show');", true);
                uModalCaja.Update();
                uContenedorCajaA.Update();

            }
            else if (e.CommandName.Equals("ideliminar"))
            {

                // ELIMINAR UN PRODUCTO DE LA LISTA
                string codigo = idTabla.Rows[fila].Cells[0].Text;
                int id = Convert.ToInt32(codigo);

                accesoCaja.eliminarCaja(id);
                idTabla.DataSource = accesoCaja.filtrarCajas();
                idTabla.DataBind();

                alerta.Visible = true;
                alerta.CssClass = "alert alert-primary animated zoomInUp";
                mensaje3.Text = "CAJA ELIMINADA CON EXITO.";

            }



        }
    }
}