using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pizza_Express_visual.Models;
namespace Pizza_Express_visual.Services
{
    public class QueryComanda
    {
        public List<object> filtrarCartaMenu()
        {
            try
            {
                using (bd8 contexto = new bd8())
                {

                    var cartaM = from u in contexto.Menu
                                 join t in contexto.TamanoP
                                 on u.codigo_tamanoP equals t.codigo_tamanoP
                                 join c in contexto.Categoria
                                 on u.codigo_categoria equals c.codigo_categoria
                                select new
                            {   
                                u.codigo_menu,
                                u.nombre_menu,
                                u.precio_menu,
                                u.ingredientes_menu,
                                t.nombre_tamanoP,
                                c.codigo_categoria,
                                c.nombre_categoria
                            };

                    return cartaM.ToList<object>();
                }
            }

            catch (Exception)
            {
                return null;

            }
        }

        public List<object> filtrarCategoriaMenu( string dato, int filtro)
        {
            try
            {
                using (bd8 contexto = new bd8())
                {

                    switch (filtro)
                    {
                        case 0:
                            var Grande = from u in contexto.Menu
                                         join c in contexto.Categoria
                                         on u.codigo_categoria equals c.codigo_categoria
                                         where c.nombre_categoria.ToLower().StartsWith(dato.ToLower())
                                         join t in contexto.TamanoP
                                         on u.codigo_tamanoP equals t.codigo_tamanoP
                                         select c;
                                         //{
                                         //    u.codigo_menu,
                                         //    u.nombre_menu,
                                         //    u.precio_menu,
                                         //    u.ingredientes_menu,
                                         //    t.nombre_tamanoP,
                                         //    c.nombre_categoria
                                         //};

                            return Grande.ToList<object>();

                        default:
                            var Todo= from u in contexto.Menu
                                      join c in contexto.Categoria
                                      on u.codigo_categoria equals c.codigo_categoria
                                      where c.nombre_categoria.ToLower().StartsWith(dato.ToLower())
                                      join t in contexto.TamanoP
                                      on u.codigo_tamanoP equals t.codigo_tamanoP
                                      where t.nombre_tamanoP.ToLower().StartsWith(dato.ToLower())
                                      select new
                                      {
                                          u.codigo_menu,
                                          u.nombre_menu,
                                          u.precio_menu,
                                          u.ingredientes_menu,
                                          t.nombre_tamanoP,
                                          c.codigo_categoria,
                                          c.nombre_categoria
                                      };

                            return Todo.ToList<object>();
                    }                    
                }
            }
            catch (Exception)
            {
                return null;

            }
        }
    }
}