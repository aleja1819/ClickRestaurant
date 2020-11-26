using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pizza_Express_visual.Models;
namespace Pizza_Express_visual.Services
{


    public class QueryMesas
    {

        public List<int> estadoPagoMesaSeleccionada(int idMesa)
        {
            try
            {
                using (Pizza_BD1 bd = new Pizza_BD1())
                {
                    var estadoPagoMesa = from m in bd.ComandaMesa
                                         where m.idMesa.Equals(idMesa) && m.idEstadoPago == 2
                                         select new { m.codigo_comanda };

                    var listaPedidosMesa = new List<int>();
                    foreach (var pedido in estadoPagoMesa)
                    {
                        listaPedidosMesa.Add(pedido.codigo_comanda);
                    }

                    return listaPedidosMesa.ToList<int>();
                }
            }
            catch { return null; }
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
                using (Pizza_BD1 db = new Pizza_BD1())
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
        public void cambiarEstadoMesa(int idMesa, int idEstadoPago)
        {
            try
            {
                using (Pizza_BD1 db = new Pizza_BD1())
                {
                    var mesa = db.Mesa.First(u => u.idMesa == idMesa);

                    mesa.codigo_estado = idEstadoPago;

                    db.SaveChanges();
                }                
            }
            catch { }
        }
    }
}