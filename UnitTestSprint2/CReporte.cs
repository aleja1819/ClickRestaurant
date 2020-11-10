using Pizza_Express_visual.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Pizza_Express_visual.Components
{
    public partial class components_Reportes
    {

        static List<Services.reporte> ListaReporte = new List<reporte>();
        static List<Services.ventas> ListaVentas = new List<ventas>();
        private QueryReportes accesoReportes = new QueryReportes();


        protected void bBuscarNombre_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tfechaini = DateTime.Now;
                DateTime tfechafin = DateTime.Now;

                DateTime FechaInicial = Convert.ToDateTime(tfechaini);
                DateTime FechaFinal = Convert.ToDateTime(tfechafin);

                int cant = accesoReportes.filtrarPorNombre(FechaInicial, FechaFinal).Count;

            }
            catch (Exception)
            {


            }

        }

        protected void buscarVentas_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime tfechaini = DateTime.Now;
                DateTime tfechafin = DateTime.Now;

                DateTime FechaInicial = Convert.ToDateTime(tfechaini);
                DateTime FechaFinal = Convert.ToDateTime(tfechafin);

                int cant = accesoReportes.reporteVenta(FechaInicial, FechaFinal).Count;


            }
            catch (Exception)
            {


            }
        }

    }
   
}
