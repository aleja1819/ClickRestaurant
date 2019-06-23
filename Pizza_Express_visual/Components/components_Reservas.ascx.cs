using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Pizza_Express_visual.Services;
namespace Pizza_Express_visual.Components
{
    public partial class components_Reservas : System.Web.UI.UserControl
    {

        private QueryReservas accesoReservas = new QueryReservas();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //PARA MOSTRAR LOS PROVEEDORES DE LA BASE DE DATOS
                idTabla.DataSource = accesoReservas.filtrarReservas();
                idTabla.DataBind();

            }
        }

        protected void bRegistrarReservarModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal();", true);
            uModalReserva.Update();
            uContenedorReservas.Update();
        }

        protected void idregistrarReservas_Click(object sender, EventArgs e)
        {
            try
            {

                //LEER LOS DATOS INGRESADOS
                string nuMesa = tnMesa.Text;
                string nombre_R = tnombre.Text;
                //string fecha = tfecha.SelectedDates;
                //string hora = tapellidoM.Text;



                //GUARDAR LOS DATOS EN LA LISTA
                accesoReservas.addReserva(new Models.Reserva
                {

                    //numero_mesa = nuMesa,
                    //nombre_reserva = nombre_R,
                    //fecha_reserva = 
                    //hora_reserva = 
                });

                //MOSTRAR LOS DATOS EN LA TABLA
                idTabla.DataSource = accesoReservas.filtrarReservas();
                idTabla.DataBind();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalUsuario", "$('#myModalUsuario').modal('hide');", true);
                uModalReserva.Update();
                uContenedorReservas.Update();
            }

            catch (Exception)
            {


            }
        }
    }
}