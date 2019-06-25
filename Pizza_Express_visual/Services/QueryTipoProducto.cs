using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pizza_Express_visual.Models;
namespace Pizza_Express_visual.Services
{
    public class QueryTipoProducto
    {
        static List<QueryTipoProducto> queryTipoProductos = new List<QueryTipoProducto>();

        public List<object> FiltroTipoProducto()
        {

            try
            {
                using (bd5 contexto = new bd5())
                {

                    var pro = from p in contexto.TipoProducto
                             select new { p.nombre_tipoProducto, p.codigo_tipoProducto};

                    return pro.ToList<object>();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        //AGREGAR TIPO USUARIO
        public bool addTipoProducto(TipoProducto tipoP)
        {
            try
            {
                using (bd5 contexto = new bd5())
                {
                    contexto.TipoProducto.Add(tipoP);
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

        //LIMPIAR TIPOS DE PRODUCTOS
        public void limpiarTipoProducto()
        {
            queryTipoProductos.Clear();
        }
    }
}