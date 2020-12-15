using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pizza_Express_visual.Models;
namespace Pizza_Express_visual.Services
{
    public class ElementoPagado
    {
        public int cantidad { get; set; }
        public string nombre { get; set; }
        public int precio { get; set; }
        public int total { get; set; }
    }

    public class QueryMesas
    {
        public List<int> pagarPedidos(List<int> pedidosAPagar)
        {
            try
            {
                using (Pizza_BD1 bd = new Pizza_BD1())
                {
                    var pedidosPagados = new List<int>();

                    foreach (var pedidoConDeuda in pedidosAPagar)
                    {
                        
                        var pagarPedidos = bd.PedidosActivos.Find(pedidoConDeuda);


                        bd.PedidosActivos.Remove(pagarPedidos);
                        bd.SaveChanges();

                        int respuesta = bd.SaveChanges();


                        pedidosPagados.Add(pagarPedidos.codigo_comanda);


                    }

                    return pedidosPagados.ToList<int>();
                }
            }
            catch
            {
                return null;
            }
        }

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


        public List<int> pedidosAPagar(int idMesa)
        {
            try
            {
                using (Pizza_BD1 bd = new Pizza_BD1())
                {
                    var estadoPagoMesa = from m in bd.PedidosActivos
                                         where m.idMesa.Equals(idMesa) && m.idEstadoPago == 2
                                         select new { m.idPedidosActivos };

                    var listaPedidosMesa = new List<int>();
                    foreach (var pedido in estadoPagoMesa)
                    {
                        listaPedidosMesa.Add(pedido.idPedidosActivos);
                    }

                    return listaPedidosMesa.ToList<int>();

                }
            }
            catch { return null; }
        }


        public int precioTotal(List<int> listaPedidosMesa)
        {
            try
            {
                using (Pizza_BD1 bd = new Pizza_BD1())
                {
                    int ptotal = 0;

                    foreach (var el in listaPedidosMesa)
                    {
                        var estadoPagoMesa = from m in bd.PedidosActivos
                                             where m.codigo_comanda.Equals(el)
                                             select new { m.subtotal };

                        foreach (var subtotal in estadoPagoMesa)
                        {
                            ptotal += subtotal.subtotal;
                        }

                    }
                        return ptotal;

                }
            }
            catch { return -1; }
        }

        public List<object> pedidosPendientes(int nMesa)
        {
            try
            {
                using (Pizza_BD1 bd = new Pizza_BD1())
                {

                    var pedido = from m in bd.PedidosActivos
                                 where m.idMesa == nMesa && m.idEstadoPago == 2
                                 select new { m.codigo_comanda, m.nombre_menu, m.precio_menu, m.cantidad, m.subtotal };
                        
                        return pedido.ToList<object>();                
                }
            }
            catch { return null; }
        }

        public List<ElementoPagado> detalleBoleta(int nMesa)
        {
            try
            {
                using (Pizza_BD1 bd = new Pizza_BD1())
                {

                    var pedidos = from m in bd.PedidosActivos
                                 where m.idMesa == nMesa && m.idEstadoPago == 2
                                 select new { m.codigo_comanda, m.nombre_menu, m.precio_menu, m.cantidad, m.subtotal };

                    List<ElementoPagado> elementosPagados = new List<ElementoPagado>();

                    //elementosPagados.Clear();

                    foreach (var pedido in pedidos)
                    {
                        elementosPagados.Add(new ElementoPagado
                        {
                            cantidad = pedido.cantidad,
                            nombre = pedido.nombre_menu,
                            precio = pedido.precio_menu,
                            total = pedido.subtotal
                        });
                    }

                    return elementosPagados.ToList<ElementoPagado>();
                }
            }
            catch { return null; }
        }
        public List<String> objetoPedidos(List<int> listaPedidosMesa)
        {
            try
            {
                using (Pizza_BD1 bd = new Pizza_BD1())
                {
                    var listaPedidosMesa2 = new List<String>();
                    
                    foreach (var el in listaPedidosMesa)
                    {
                        var estadoPagoMesa = from m in bd.Detalle_Mesa_Pedido
                                             where m.codigo_comanda.Equals(el) 
                                             select new { 
                                                          m.menu1, m.menu2, m.menu3, m.menu4, m.menu5, m.menu6, m.menu7, m.menu8, m.menu9, m.menu10, 
                                                          m.menu11, m.menu12, m.menu13, m.menu14, m.menu15, m.menu16, m.menu17, m.menu18, m.menu19, m.menu20, 
                                                          m.menu21, m.menu22, m.menu23, m.menu24, m.menu25, m.menu26, m.menu27, m.menu28, m.menu29, m.menu30 
                                                        };

                        foreach (var menu in estadoPagoMesa)
                        {
                            listaPedidosMesa2.Add(menu.menu1); listaPedidosMesa2.Add(menu.menu2); listaPedidosMesa2.Add(menu.menu3); listaPedidosMesa2.Add(menu.menu4); listaPedidosMesa2.Add(menu.menu5); listaPedidosMesa2.Add(menu.menu6); listaPedidosMesa2.Add(menu.menu7); listaPedidosMesa2.Add(menu.menu8); listaPedidosMesa2.Add(menu.menu9); listaPedidosMesa2.Add(menu.menu10);
                            listaPedidosMesa2.Add(menu.menu11); listaPedidosMesa2.Add(menu.menu12); listaPedidosMesa2.Add(menu.menu13); listaPedidosMesa2.Add(menu.menu14); listaPedidosMesa2.Add(menu.menu15); listaPedidosMesa2.Add(menu.menu16); listaPedidosMesa2.Add(menu.menu17); listaPedidosMesa2.Add(menu.menu18); listaPedidosMesa2.Add(menu.menu19); listaPedidosMesa2.Add(menu.menu20); 
                            listaPedidosMesa2.Add(menu.menu21); listaPedidosMesa2.Add(menu.menu22); listaPedidosMesa2.Add(menu.menu23); listaPedidosMesa2.Add(menu.menu24); listaPedidosMesa2.Add(menu.menu25); listaPedidosMesa2.Add(menu.menu26); listaPedidosMesa2.Add(menu.menu27); listaPedidosMesa2.Add(menu.menu28); listaPedidosMesa2.Add(menu.menu29); listaPedidosMesa2.Add(menu.menu30);
                        }

                    }
                        return listaPedidosMesa2.ToList<String>();
                    
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

        public void cambiarEstadoPagoComanda(List<int> comandasImpagas, int idEstadoPago)
        {
            try
            {
                using(Pizza_BD1 db = new Pizza_BD1())
                {
                    foreach( var ComandaMesa in comandasImpagas)
                    {
                        var comanda = db.ComandaMesa.First(c => c.codigo_comanda == ComandaMesa);

                        comanda.idEstadoPago = idEstadoPago;

                        db.SaveChanges();
                    }
                }
            }
            catch
            {

            }
        }
    }
}