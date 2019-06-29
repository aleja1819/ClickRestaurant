using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pizza_Express_visual.Models;
namespace Pizza_Express_visual.Services
{
    public class QueryProductos
    {

        //LINQ TO ENTITY
        public List<object> filtrarProductos()
        {
            try
            {
                using (bd8 contexto = new bd8())
                {

                    var pro = from p in contexto.Producto
                              join pp in contexto.Producto_Proveedor
                              on p.codigo_producto equals pp.codigo_producto
                              join prov in contexto.Proveedor
                              on pp.codigo_proveedor equals prov.codigo_proveedor
                              select new { p.codigo_producto,p.nombre_producto, prov.rut_proveedor, pp.fecha_ingreso_producto, pp.cantidad_producto};

                    return pro.ToList<object>();

                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        //AGREGAR PROVEEDOR
        public bool addProducto(Producto prod, ref int idprod)
       { 

            try
            {
                using (bd8 contexto = new bd8())
                {

                    contexto.Producto.Add(prod);
                    contexto.SaveChanges();

                    int respuestas = contexto.SaveChanges(); 
                    idprod = prod.codigo_producto;
                    return respuestas == 1; 
                }
            }
            catch (Exception e)
            {

                return false;
            }
        }

        //AGREGAR FORANEA PRODUCTO-PROVEEDOR
        public bool addProd_Prove(Producto_Proveedor prod_prove)
        {

            try
            {
                using (bd8 contexto = new bd8())
                {

                    contexto.Producto_Proveedor.Add(prod_prove);
                    contexto.SaveChanges();

                    int respuestas = contexto.SaveChanges(); 

                    return respuestas == 1; 
                }
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public int codigoProvee(string rut)
        {
            try
            {
                using (bd8 contexto = new bd8())
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

        //ELIMINAR
        public bool eliminarProducto(int id_prod)
        {

            try
            {
                int idP = Convert.ToInt32(id_prod);
                using (bd8 contexto = new bd8())
                {
                    var user = contexto.Producto.First(p => p.codigo_producto == idP);

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

        public List<object> BuscarProductos(string dato, int filtro)
        {
            using (bd8 contexto = new bd8())
            {

                int cod_prod = 0; //TIENE QUE VER CON EL CONBOBOX
                int.TryParse(dato, out cod_prod); //PARA CONVERTIR EL RUTBUSCAR

                switch (filtro)
                {
                    case 0: //BUSCAR POR NOMBRE
                        var pNombre = from p in contexto.Producto
                                  where p.nombre_producto.ToLower().StartsWith(dato.ToLower())
                                  join pp in contexto.Producto_Proveedor
                                  on p.codigo_producto equals pp.codigo_producto
                                  join prov in contexto.Proveedor
                                  on pp.codigo_proveedor equals prov.codigo_proveedor
                                  select new { p.codigo_producto, p.nombre_producto, prov.rut_proveedor, pp.fecha_ingreso_producto, pp.cantidad_producto};
                

                        return pNombre.ToList<object>();
                    case 1: //BUSCAR POR CODIGO
                        var pCodigo = from p in contexto.Producto
                                      where p.codigo_producto == cod_prod
                                      join pp in contexto.Producto_Proveedor
                                      on p.codigo_producto equals pp.codigo_producto
                                      join prov in contexto.Proveedor
                                      on pp.codigo_proveedor equals prov.codigo_proveedor
                                      select new { p.codigo_producto, p.nombre_producto, prov.rut_proveedor, pp.fecha_ingreso_producto, pp.cantidad_producto };

                        return pCodigo.ToList<object>();
                    default:
                        var rTodo = from p in contexto.Producto
                                    join pp in contexto.Producto_Proveedor
                                    on p.codigo_producto equals pp.codigo_producto
                                    join prov in contexto.Proveedor
                                    on pp.codigo_proveedor equals prov.codigo_proveedor
                                    select new { p.codigo_producto, p.nombre_producto, prov.rut_proveedor, pp.fecha_ingreso_producto, pp.cantidad_producto };

                        return rTodo.ToList<object>();
                }


            }
        }

        public bool editarProducto(Producto producto, string cod_ori)
        {

            try
            {
                int idOri = Convert.ToInt32(cod_ori);
                using (bd8  contexto = new bd8())
                {

                    //BUSCAR EL PRODUCTO EN LA BD
                    var user = contexto.Producto.First(prod => prod.codigo_producto == idOri);
                  
                    //MODIFICAR LOS CAMPOS QUE NECESITO

                    user.nombre_producto = producto.nombre_producto;
                    

                    //GUARDAR LOS CAMBIOS EN LA TABLA B
                    int respuesta = contexto.SaveChanges();
                    return respuesta == 1;

                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool editarProductoProveedor(Producto_Proveedor prove, string cod_ori)
            {

            try
            {
                int idOri = Convert.ToInt32(cod_ori);
                using (bd8 contexto = new bd8())
                {

                    //BUSCAR EL PRODUCTO EN LA BD
                    var user = contexto.Producto_Proveedor.First(prod => prod.codigo_producto == idOri);

                    //MODIFICAR LOS CAMPOS QUE NECESITO

                    user.codigo_proveedor = prove.codigo_proveedor;
                   
                    user.fecha_ingreso_producto = prove.fecha_ingreso_producto;
                    user.cantidad_producto = prove.cantidad_producto;

                    //GUARDAR LOS CAMBIOS EN LA TABLA B
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
