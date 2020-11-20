using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pizza_Express_visual.Models;
namespace Pizza_Express_visual.Services
{


    public class QueryMesas
    {

        // Consulta el numero de la mesa
        public int numeroMesa(int idMesa)
        {
            try
            {
                using(Pizza_BD1 bd = new Pizza_BD1())
                {
                    var valEstado = (from m in bd.Mesa
                                      where m.idMesa.Equals(idMesa)
                                      select new { Estado = m.codigo_estado }).First().Estado;

                    return valEstado;
                }
            }
            catch
            {
                return -1;
            }
        }
        
        // Consulta el estado de pago de la mesa, si 1 == Cancelado, si es 2 == No Cancelado
        public List<Object> estadoPago(int idMesa)
        {
            try
            {
                using(Pizza_BD1 db = new Pizza_BD1())
                {
                    var estPago = from p in db.ComandaMesa
                                  where p.idMesa == idMesa && p.idEstadoPago == 2
                                  select new { p.idEstadoPago };

                    return estPago.ToList<Object>();
                }
            }
            catch
            {
                return null;
            }
        }
        
    }
}