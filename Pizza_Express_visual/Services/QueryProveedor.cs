using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pizza_Express_visual.Models;
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
                using (bd7 contexto = new bd7())
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
                using (bd7 contexto = new bd7())
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

        //AGREGAR PROVEEDOR
        public bool addProveedor(Proveedor prove)
        {

            try
            {
                using (bd7 contexto = new bd7())
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

        //ELIMNAR 
        public bool eliminarProveedor(int id_prov)
        {
            try
            {
                using (bd7 contexto = new bd7())
                {
                    var user = contexto.Proveedor.Find(id_prov);

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

        //BUSCAR
        public List<object> BuscarProveedor(string dato, int filtro)
        {
            using (bd7 contexto = new bd7())
            {
                switch (filtro)
                {
                    case 0: //BUSCAR POR RUT
                        var pRut = from p in contexto.Proveedor
                                   where p.rut_proveedor.ToLower().StartsWith(dato.ToLower())
                                   join t in contexto.TipoProducto
                                   on p.codigo_tipoProducto equals t.codigo_tipoProducto
                                   select p;

                        return pRut.ToList<object>();

                    case 1: //BUSCAR POR nombre
                        var pNombre = from p in contexto.Proveedor
                                      where p.nombre_proveedor.ToLower().StartsWith(dato.ToLower())
                                      join t in contexto.TipoProducto
                                      on p.codigo_tipoProducto equals t.codigo_tipoProducto
                                      select p;

                        return pNombre.ToList<object>();
                    default:
                        var pTodo = from p in contexto.Proveedor
                                    join t in contexto.TipoProducto
                                    on p.codigo_tipoProducto equals t.codigo_tipoProducto
                                    select p;

                        return pTodo.ToList<object>();
                }


            }
        }

    }
}