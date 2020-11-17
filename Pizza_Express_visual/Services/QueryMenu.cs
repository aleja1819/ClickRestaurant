using Pizza_Express_visual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Pizza_Express_visual.Services
{
    public class QueryMenu
    {
        //LINQ TO ENTITY
             public List<object> filtrarMenu()
        {
            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    var r = from m in contexto.Menu
                            join c in contexto.Categoria
                            on m.codigo_categoria equals c.codigo_categoria
                            join t in contexto.TamanoP
                            on m.codigo_tamanoP equals t.codigo_tamanoP
                            select new
                            {
                                m.codigo_menu,
                                m.nombre_menu,
                                m.precio_menu,
                                m.ingredientes_menu,
                                c.codigo_categoria,
                                c.nombre_categoria,
                                t.codigo_tamanoP,
                                t.nombre_tamanoP
                            };

                    return r.ToList<object>();
                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        public List<object> filtrarTamanoP()
        {
            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
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
                using (Pizza_BD1 contexto = new Pizza_BD1())
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
                using (Pizza_BD1 contexto = new Pizza_BD1())
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

        public bool eliminarMenu(int codigoMenu)
        {

            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {
                    var user = contexto.Menu.Find(codigoMenu);

                    contexto.Menu.Remove(user);
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

        public bool editarMenu(Menu usuario, string codigoOriginal)
        {

            try
            {
                int idOriginal = Convert.ToInt32(codigoOriginal);
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    var user = contexto.Menu.First(men => men.codigo_menu == idOriginal);

                    user.nombre_menu = usuario.nombre_menu;
                    user.precio_menu = usuario.precio_menu;
                    user.ingredientes_menu = usuario.ingredientes_menu;
                    user.codigo_tamanoP = usuario.codigo_tamanoP;
                    user.codigo_categoria = usuario.codigo_categoria;

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

        public List<object> BuscarMenu(string dato, int filtro)
        {
            using (Pizza_BD1 contexto = new Pizza_BD1())
            {
                switch (filtro)
                {
                    case 0: 
                        var RetornarNombre = from m in contexto.Menu
                                      join c in contexto.Categoria
                                      on m.codigo_categoria equals c.codigo_categoria
                                      where m.nombre_menu.ToLower().StartsWith(dato.ToLower())
                                      join t in contexto.TamanoP
                                      on m.codigo_tamanoP equals t.codigo_tamanoP
                                      select new
                                      {
                                          m.codigo_menu,
                                          m.nombre_menu,
                                          m.precio_menu,
                                          m.ingredientes_menu,
                                          c.codigo_categoria,
                                          c.nombre_categoria,
                                          t.codigo_tamanoP,
                                          t.nombre_tamanoP
                                      };

                        return RetornarNombre.ToList<object>();
                    default:
                        var RetornarTodo = from m in contexto.Menu
                                    join c in contexto.Categoria
                                    on m.codigo_categoria equals c.codigo_categoria
                                    join t in contexto.TamanoP
                                    on m.codigo_tamanoP equals t.codigo_tamanoP
                                    select new
                                    {
                                        m.codigo_menu,
                                        m.nombre_menu,
                                        m.precio_menu,
                                        m.ingredientes_menu,
                                        c.codigo_categoria,
                                        c.nombre_categoria,
                                        t.codigo_tamanoP,
                                        t.nombre_tamanoP
                                    };

                        return RetornarTodo.ToList<object>();
                }


            }

        }
    }
}