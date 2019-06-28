using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pizza_Express_visual.Models;
namespace Pizza_Express_visual.Services
{
    public class QueryMenu
    {
        //LINQ TO ENTITY
        public List<object> filtrarMenu()
        {
            try
            {
                using (bd7 contexto = new bd7())
                {

                    var r = from m in contexto.Menu
                            join c in contexto.Categoria
                            on m.codigo_categoria equals c.codigo_categoria
                            join t in contexto.TamanoP
                            on m.codigo_tamanoP equals t.codigo_tamanoP
                            select new {m.codigo_menu, m.nombre_menu, m.precio_menu, m.ingredientes_menu, c.codigo_categoria, c.nombre_categoria, t.codigo_tamanoP, t.nombre_tamanoP
                            };

                    return r.ToList<object>();
                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        public List<object> filtrarTamañoP()
        {
            try
            {
                using (bd7 contexto = new bd7())
                {

                    var r = from t in contexto.TamanoP
                            select new { t.codigo_tamanoP, t.nombre_tamanoP };

                    return r.ToList<object>();
                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        public List<object> filtrarCategoria()
        {
            try
            {
                using (bd7 contexto = new bd7())
                {

                    var r = from c in contexto.Categoria
                            select new { c.codigo_categoria, c.nombre_categoria };

                    return r.ToList<object>();
                }
            }
            catch (Exception)
            {
                return null;

            }
        }

            public bool addMenu(Menu menu)
        {

            try
            {
                using (bd7 contexto = new bd7())
                {

                    contexto.Menu.Add(menu);
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

    }
}