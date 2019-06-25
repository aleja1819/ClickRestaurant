using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pizza_Express_visual.Models;
namespace Pizza_Express_visual.Services
{
    public class QueryProductos
    {
        static List<QueryProductos> queryProductos = new List<QueryProductos>();

        //LINQ TO ENTITY
        public List<object> filtrarProductos()
        {
            try
            {
                using (bd5 contexto = new bd5())
                {

                    var pro = from p in contexto.Producto
                              join pp in contexto.Producto_Proveedor
                              on p.codigo_producto equals pp.codigo_producto
                              select new { p.nombre_producto, pp.Proveedor.rut_proveedor, pp.fecha_ingreso_producto, pp.cantidad_producto};

                    return pro.ToList<object>();

                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        //AGREGAR PROVEEDOR
        public bool addProducto(Producto prod)
        {

            try
            {
                using (bd5 contexto = new bd5())
                {

                    contexto.Producto.Add(prod);
                    contexto.SaveChanges();

                    int respuestas = contexto.SaveChanges(); //INSERTA EN LA TABLA DE BASE DE DATOS

                    return respuestas == 1; //VALIDA SI LO ANGREGA O NO, SI ES UN 1 ES TRUE SI NO AGREGAR NADA ES FALSE
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
