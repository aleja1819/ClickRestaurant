//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Pizza_Express_visual.Services
//{

//    public class reporte
//    {
//        public int codigo_P { get; set; }
//        public string nombre_P { get; set; }
//        public string rut_P { get; set; }
//        public DateTime fecha_I { get; set; }
//        public int cantidad_P { get; set; }
//    }

//    public class ventas
//    {

//        public int codigo_C { get; set; }
//        public int cantidad_V { get; set; }
//        public string nombre_V { get; set; }
//        public DateTime fecha_V { get; set; }
//        public int precio_V { get; set; }
//    }

//    public class QueryReportes
//    {
//        private Pizza_BD contexto = new Pizza_BD();

//        public List<object> filtrarPorNombre(DateTime FechaInicial, DateTime FechaTermino)
//        {
//            try
//            {

//                using (Pizza_B contexto = new Pizza_B())
//                {

//                    var retornoReporte = from p in contexto.Producto
//                                         join pp in contexto.Producto_Proveedor
//                                         on p.codigo_producto equals pp.codigo_producto
//                                         where (pp.fecha_ingreso_producto.Day <= FechaTermino.Day && pp.fecha_ingreso_producto.Month <= FechaTermino.Month && pp.fecha_ingreso_producto.Year <= FechaTermino.Year)
//                                         &&
//                                         (pp.fecha_ingreso_producto.Day >= FechaInicial.Day && pp.fecha_ingreso_producto.Month >= FechaInicial.Month && pp.fecha_ingreso_producto.Year >= FechaInicial.Year)
//                                         select new { p.codigo_producto, p.nombre_producto, pp.Proveedor.rut_proveedor, pp.fecha_ingreso_producto, pp.cantidad_producto };

//                    int c = retornoReporte.Count();
//                    return retornoReporte.ToList<object>();

//                }
//            }
//            catch (Exception)
//            {
//                return null;

//            }
//        }

//        public List<object> reporteVenta(DateTime FechaInicial, DateTime fechaTermino)
//        {
//            try
//            {

//                using (Pizza_BD contexto = new Pizza_BD())
//                {

//                    var retornoReporte = from cc in contexto.ComandaMesa
//                                         join dm in contexto.Detalle_Mesa
//                                         on cc.codigo_comanda equals dm.codigo_comanda
//                                         join m in contexto.Menu
//                                         on dm.codigo_menu equals m.codigo_menu
//                                         where (cc.fecha.Day <= fechaTermino.Day && cc.fecha.Month <= fechaTermino.Month && cc.fecha.Year <= fechaTermino.Year)
//                                         &&
//                                         (cc.fecha.Day >= FechaInicial.Day && cc.fecha.Month >= FechaInicial.Month && cc.fecha.Year >= FechaInicial.Year)
//                                         select new { dm.codigo_comanda, dm.cant_Menu, dm.precio_total, cc.fecha, m.nombre_menu };

//                    int c = retornoReporte.Count();
//                    return retornoReporte.ToList<object>();

//                }
//            }
//            catch (Exception)
//            {
//                return null;

//            }
//        }


//        public List<object> listartodo()
//        {
//            try
//            {
//                using (Pizza_BD contexto = new Pizza_BD())
//                {

//                    var retornoReporte = from p in contexto.Producto join pp in contexto.Producto_Proveedor on p.codigo_producto equals pp.codigo_proveedor select new { p.codigo_producto, p.nombre_producto, pp.Proveedor.rut_proveedor, pp.fecha_ingreso_producto, pp.cantidad_producto };


//                    return retornoReporte.ToList<object>();
//                }
//            }
//            catch (Exception)
//            {
//                return null;

//            }
//        }


//        public List<Producto_Proveedor> productosPDF()
//        {
//            try
//            {
//                var result = from pr in contexto.Producto_Proveedor
//                             orderby pr.fecha_ingreso_producto descending
//                             select pr;

//                return result.ToList();
//            }
//            catch (Exception)
//            {
//                return null;
//            }
//        }


//    }
//}