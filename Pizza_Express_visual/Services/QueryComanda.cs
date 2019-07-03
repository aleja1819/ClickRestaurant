using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pizza_Express_visual.Models;
namespace Pizza_Express_visual.Services
{ 
  public  class carro
{
    public int codigo_M { get; set; }

        public int cantidad { get; set; }
        public string nombre_M { get; set; }
        public int precio_M { get; set; }
        public string ingre_M { get; set; }


    }
public class QueryComanda
    {
     

        public List<object> filtrarCategoriaMenu( int idcategoria, int idtamano)
        {
            try
            {
                using (bd8 contexto = new bd8())
                {

                            var Grande = from u in contexto.Menu
                                         join c in contexto.Categoria
                                         on u.codigo_categoria equals c.codigo_categoria
                                         join t in contexto.TamanoP
                                               on u.codigo_tamanoP equals t.codigo_tamanoP                                               
                                         where u.codigo_categoria == idcategoria && u.codigo_tamanoP ==idtamano                                   
                                         select new
                                         {
                                             u.codigo_menu,
                                             u.nombre_menu,
                                             u.precio_menu,
                                             u.ingredientes_menu,                                                                                
                                         };

                    return Grande.ToList<object>();
                     
                }
            }
            catch (Exception)
            {
                return null;

            }
        }
    }
}