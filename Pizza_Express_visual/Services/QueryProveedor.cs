using Pizza_Express_visual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Pizza_Express_visual.Services
{
    public class QueryProveedor
    {
        static List<QueryProveedor> queryProveedor = new List<QueryProveedor>();

        //LINQ TO ENTITY
        public List<object> filtrarProveedor()
        {
            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    var pro = from p in contexto.Proveedor
                              join t in contexto.TipoProducto
                              on p.codigo_tipoProducto equals t.codigo_tipoProducto

                              select new { p.codigo_proveedor, p.rut_proveedor, p.nombre_proveedor, p.apellido_paterno_proveedor, p.apellido_materno_proveedor, p.direccion_proveedor, t.nombre_tipoProducto, t.codigo_tipoProducto };

                    return pro.ToList<object>();

                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        public List<object> filtrartipoProducto()
        {
            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    var pro = from t in contexto.TipoProducto
                              select new { t.nombre_tipoProducto, t.codigo_tipoProducto };

                    return pro.ToList<object>();

                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        public bool addProveedor(Proveedor prove)
        {

            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    contexto.Proveedor.Add(prove);
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

        public bool eliminarProveedor(int idProveedor)
        {
            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {
                    var user = contexto.Proveedor.Find(idProveedor);

                    contexto.Proveedor.Remove(user);
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

        public List<object> BuscarProveedor(string dato, int filtro)
        {
            using (Pizza_BD1 contexto = new Pizza_BD1())
            {
                switch (filtro)
                {
                    case 0: 
                        var RetornarRut = from p in contexto.Proveedor
                                   where p.rut_proveedor.ToLower().StartsWith(dato.ToLower())
                                   join t in contexto.TipoProducto
                                   on p.codigo_tipoProducto equals t.codigo_tipoProducto
                                   select new
                                   {
                                       p.codigo_proveedor,
                                       p.rut_proveedor,
                                       p.nombre_proveedor,
                                       p.apellido_paterno_proveedor,
                                       p.apellido_materno_proveedor,
                                       p.direccion_proveedor,
                                       t.codigo_tipoProducto,
                                       t.nombre_tipoProducto
                                   };

                        return RetornarRut.ToList<object>();

                    case 1: 
                        var RetornarNombre = from p in contexto.Proveedor
                                      where p.nombre_proveedor.ToLower().StartsWith(dato.ToLower())
                                      join t in contexto.TipoProducto
                                      on p.codigo_tipoProducto equals t.codigo_tipoProducto
                                      select new
                                      {
                                          p.codigo_proveedor,
                                          p.rut_proveedor,
                                          p.nombre_proveedor,
                                          p.apellido_paterno_proveedor,
                                          p.apellido_materno_proveedor,
                                          p.direccion_proveedor,
                                          t.codigo_tipoProducto,
                                          t.nombre_tipoProducto
                                      };

                        return RetornarNombre.ToList<object>();
                    default:
                        var pTodo = from p in contexto.Proveedor
                                    join t in contexto.TipoProducto
                                    on p.codigo_tipoProducto equals t.codigo_tipoProducto
                                    select new
                                    {
                                        p.codigo_proveedor,
                                        p.rut_proveedor,
                                        p.nombre_proveedor,
                                        p.apellido_paterno_proveedor,
                                        p.apellido_materno_proveedor,
                                        p.direccion_proveedor,
                                        t.codigo_tipoProducto,
                                        t.nombre_tipoProducto
                                    };

                        return pTodo.ToList<object>();
                }
            }
        }

        public bool editarProveedor(Proveedor proveedor, string idOriginal)
        {

            try
            {
                int codigoOriginal = Convert.ToInt32(idOriginal);
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    var user = contexto.Proveedor.First(pro => pro.codigo_proveedor == codigoOriginal);

                    user.rut_proveedor = proveedor.rut_proveedor;
                    user.nombre_proveedor = proveedor.nombre_proveedor;
                    user.apellido_paterno_proveedor = proveedor.apellido_paterno_proveedor;
                    user.apellido_materno_proveedor = proveedor.apellido_materno_proveedor;
                    user.direccion_proveedor = proveedor.direccion_proveedor;
                    user.codigo_tipoProducto = proveedor.codigo_tipoProducto;

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
