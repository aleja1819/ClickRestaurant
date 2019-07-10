using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pizza_Express_visual.Models;

namespace Pizza_Express_visual.Services
{

    public class reporte
    {
        public int codigo_P { get; set; }
        public string nombre_P { get; set; }
        public string rut_P { get; set; }
        public DateTime fecha_I { get; set; }
        public int cantidad_P { get; set; }
    }


    public class QueryReportes
    {
        private bd9 contexto = new bd9();

        public List<object> filtrarPorNombre(DateTime date1, DateTime date2)
        {
            try
            {
            
                using (bd9 contexto = new bd9())
                {

                    var re = from p in contexto.Producto
                             join pp in contexto.Producto_Proveedor
                             on p.codigo_producto equals pp.codigo_producto
                             where (pp.fecha_ingreso_producto.Day <=date2.Day && pp.fecha_ingreso_producto.Month <=date2.Month && pp.fecha_ingreso_producto.Year<=date2.Year)                             
                             && 
                             (pp.fecha_ingreso_producto.Day >=date1.Day && pp.fecha_ingreso_producto.Month >= date1.Month && pp.fecha_ingreso_producto.Year >= date1.Year)                             
                             select new { p.codigo_producto, p.nombre_producto, pp.Proveedor.rut_proveedor, pp.fecha_ingreso_producto, pp.cantidad_producto };

                    int c = re.Count();
                    return re.ToList<object>();

                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        public List<object> listartodo()
        {
            try
            {
                using (bd9 contexto = new bd9())
                {

                    var re = from p in contexto.Producto join pp in contexto.Producto_Proveedor on p.codigo_producto equals pp.codigo_proveedor select new { p.codigo_producto, p.nombre_producto, pp.Proveedor.rut_proveedor, pp.fecha_ingreso_producto, pp.cantidad_producto };


                    return re.ToList<object>();
                }
            }
            catch (Exception)
            {
                return null;

            }
        }


        public List<Producto_Proveedor> productosPDF()
        {
            try
            {
                var result = from pr in contexto.Producto_Proveedor
                             orderby pr.fecha_ingreso_producto descending
                             select pr;

                return result.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}