using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pizza_Express_visual.Models;
namespace Pizza_Express_visual.Services
{


    public class QueryMesas
    {

        /* Recibe el numero de la mesa que ha sido seleccionada, devolviendo entonces el estado de esa mesa
         * 
            1 = disponible
            2 = ocupado
         */
        public int estadoMesa(int idMesa)
        {
            try
            {
                using(Pizza_BD1 bd = new Pizza_BD1())
                {
                    var estadoMesa = (from m in bd.Mesa
                                      where m.idMesa.Equals(idMesa)
                                      select new { Estado = m.codigo_estado }).First().Estado;

                    return estadoMesa;
                }
            }
            catch
            {
                return -1;
            }
        }

        public List<int> estadoPagoMesas()
        {

            /* Consulta el estado de pago de todos los pedidos
             * 
             * 1 == Cancelado 
             * 2 == No Cancelado 
             *
             * Devolviendo una lista con los numeros de mesa que están pendientes de pago, y asignarle color rojo           
             * 
             */
            try
            {
                using(Pizza_BD1 db = new Pizza_BD1())
                {
                    var mesasNoCanceladas = from p in db.ComandaMesa
                        where p.idEstadoPago == 2
                        select new { p.codigo_comanda, p.idMesa };

                    var listaMesas = new List<int>();                    

                    foreach (var mesa in mesasNoCanceladas)
                    {
                        listaMesas.Add(mesa.idMesa);
                    }

                    return listaMesas.ToList<int>();
                }
            }
            catch
            {
                return null;
            }
        }
        
    }
}