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
                using (bd1 contexto = new bd1())
                {

                    var po = from p in contexto.Proveedor
                            join t in contexto.TipoProducto
                            on p.codigo_proveedor equals t.codigo_tipoProducto
                            select new { p.rut_proveedor, p.nombre_proveedor,p.apellido_paterno_proveedor,p.apellido_materno_proveedor,p.direccion_proveedor, t.nombre_tipoProducto };

                    return po.ToList<object>();

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
                using (bd1 contexto = new bd1())
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

    }
}