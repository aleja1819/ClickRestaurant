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
     
        public List<object> consulta(DateTime fini,DateTime ffin) {

            try
            {
                using (bd11 c = new bd11())
                {
                    var r = from p in c.Producto_Proveedor
                            where p.fecha_ingreso_producto <= ffin && p.fecha_ingreso_producto >= fini
                            select p;

                    return r.ToList<object>();

                }                
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<object> filtrarCategoriaMenu( int idcategoria, int idtamano)
        {
            try
            {
                using (bd11 contexto = new bd11())
                {

                            var Grande = from u in contexto.Menu
                                         join c in contexto.Categoria
                                         on u.codigo_categoria equals c.codigo_categoria
                                         join t in contexto.TamanoP
                                               on u.codigo_tamanoP equals t.codigo_tamanoP                                               
                                         where u.codigo_categoria == idcategoria && u.codigo_tamanoP == idtamano                                   
                                         select new
                                         {
                                             u.codigo_menu,
                                             u.nombre_menu,
                                             u.precio_menu,
                                             u.ingredientes_menu, 
                                             t.nombre_tamanoP
                                         };

                    return Grande.ToList<object>();
                     
                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        public bool addcomanda(List<carro> listaCarro, string num_mesa, int idUser)
        {
            int cod_comanda = 0;
            using (bd11 c = new bd11())
            {
                ComandaMesa comanda = new ComandaMesa { codigo_usuario = idUser, numero_mesa = num_mesa, fecha = DateTime.Now };
                c.ComandaMesa.Add(comanda);
                c.SaveChanges();
                cod_comanda = comanda.codigo_comanda;
            }
            using (bd11 c = new bd11())
            {
                foreach (var item in listaCarro)
                {
                    c.Detalle_Mesa.Add(new Detalle_Mesa
                    {
                        codigo_comanda = cod_comanda,
                        codigo_menu = item.codigo_M,
                        precio_total = item.precio_M,
                        cant_Menu = item.cantidad
                    });
                    c.SaveChanges();
                }

            }
            return true;
        }
    }
}