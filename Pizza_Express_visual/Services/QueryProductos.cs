using Pizza_Express_visual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Pizza_Express_visual.Services
{
    public class QueryProductos
    {

        //LINQ TO ENTITY
        public List<object> filtrarProductos()
        {
            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    var pro = from p in contexto.Producto
                              join pp in contexto.Producto_Proveedor
                              on p.codigo_producto equals pp.codigo_producto
                              join prov in contexto.Proveedor
                              on pp.codigo_proveedor equals prov.codigo_proveedor
                              select new { p.codigo_producto, p.nombre_producto, prov.rut_proveedor, pp.fecha_ingreso_producto, pp.cantidad_producto };

                    return pro.ToList<object>();

                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        public bool addProducto(Producto producto, ref int idproducto)
        {

            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    contexto.Producto.Add(producto);
                    contexto.SaveChanges();

                    int respuestas = contexto.SaveChanges();
                    idproducto = producto.codigo_producto;
                    return respuestas == 1;
                }
            }
            catch (Exception e)
            {

                return e.Equals("");
            }
        }
        public bool addProd_Prove(Producto_Proveedor producto_proveedor)
        {

            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    contexto.Producto_Proveedor.Add(producto_proveedor);
                    contexto.SaveChanges();

                    int respuestas = contexto.SaveChanges();

                    return respuestas == 1;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public int codigoProveedor(string rut)
        {
            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {
                    int cod = contexto.Proveedor.First(x => x.rut_proveedor.Equals(rut)).codigo_proveedor;
                    return cod;
                }
            }
            catch (Exception)
            {
                return -1;
            }

        }

        public bool eliminarProducto(int idProducto)
        {

            try
            {
                int idProduct = Convert.ToInt32(idProducto);
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {
                    var user = contexto.Producto.First(p => p.codigo_producto == idProduct);

                    contexto.Producto.Remove(user);
                    contexto.SaveChanges();

                    int respuesta = contexto.SaveChanges();
                    return respuesta == 1;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool eliminarProductoProvee(int idProducto, int idProveedor)
        {

            try
            {

                using (Pizza_BD1 contexto = new Pizza_BD1())
                {
                    var user = contexto.Producto_Proveedor.First(prod => prod.codigo_proveedor == idProveedor && prod.codigo_producto == idProducto);

                    contexto.Producto_Proveedor.Remove(user);
                    contexto.SaveChanges();

                    int respuesta = contexto.SaveChanges();
                    return respuesta == 1;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }


        public List<object> BuscarProductos(string dato, int filtro)
        {
            using (Pizza_BD1 contexto = new Pizza_BD1())
            {

                int cod_prod = 0; 
                int.TryParse(dato, out cod_prod); 

                switch (filtro)
                {
                    case 0: 
                        var retornoNombre = from p in contexto.Producto
                                      where p.nombre_producto.ToLower().StartsWith(dato.ToLower())
                                      join pp in contexto.Producto_Proveedor
                                      on p.codigo_producto equals pp.codigo_producto
                                      join prov in contexto.Proveedor
                                      on pp.codigo_proveedor equals prov.codigo_proveedor
                                      select new { p.codigo_producto, p.nombre_producto, prov.rut_proveedor, pp.fecha_ingreso_producto, pp.cantidad_producto };


                        return retornoNombre.ToList<object>();
                    case 1: 
                        var retornoCodigo = from p in contexto.Producto
                                      where p.codigo_producto == cod_prod
                                      join pp in contexto.Producto_Proveedor
                                      on p.codigo_producto equals pp.codigo_producto
                                      join prov in contexto.Proveedor
                                      on pp.codigo_proveedor equals prov.codigo_proveedor
                                      select new { p.codigo_producto, p.nombre_producto, prov.rut_proveedor, pp.fecha_ingreso_producto, pp.cantidad_producto };

                        return retornoCodigo.ToList<object>();
                    default:
                        var retornoTodo = from p in contexto.Producto
                                    join pp in contexto.Producto_Proveedor
                                    on p.codigo_producto equals pp.codigo_producto
                                    join prov in contexto.Proveedor
                                    on pp.codigo_proveedor equals prov.codigo_proveedor
                                    select new { p.codigo_producto, p.nombre_producto, prov.rut_proveedor, pp.fecha_ingreso_producto, pp.cantidad_producto };

                        return retornoTodo.ToList<object>();
                }
            }
        }

        public bool editarProducto(Producto producto, int idOriginal)
        {

            try
            {
                int idProducto = Convert.ToInt32(idOriginal);
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    var user = contexto.Producto.First(prod => prod.codigo_producto == idProducto);

                    //MODIFICAR LOS CAMPOS QUE NECESITO
                    user.nombre_producto = producto.nombre_producto;

                    int respuesta = contexto.SaveChanges();
                    return respuesta == 1;

                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool editarProductoProveedor(Producto_Proveedor prove, int idOriginal)
        {

            try
            {
                int idProveedor = Convert.ToInt32(idOriginal);
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    var user = contexto.Producto_Proveedor.First(prod => prod.codigo_proveedor == prove.codigo_proveedor && prod.codigo_producto == idProveedor);

                    user.fecha_ingreso_producto = prove.fecha_ingreso_producto;
                    user.cantidad_producto = prove.cantidad_producto;

                    int respuesta = contexto.SaveChanges();
                    return respuesta == 1;

                }
            }
            catch (Exception)
            {
             return false;
            }
        }

    }

}
