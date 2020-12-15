using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza_Express_visual.Services;
using System.Collections.Generic;
using System.Linq;

namespace Pizza_Express_visual.Services
{
    [TestClass]
    public partial class  Reportes
    {
       


        //static List<Services.reporte> ListaReporte = new List<reporte>();
        static List<Services.ventas> ListaVentas = new List<ventas>();
        private QueryReportes accesoReportes = new QueryReportes();


        [TestMethod]
        public void TestMethod1()
        {

         void buscarVentas_Click()
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

        private void bBuscarNombre_Click()
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
    }
    }
