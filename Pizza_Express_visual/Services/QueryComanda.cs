using Pizza_Express_visual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Pizza_Express_visual.Services
{
    public class carro
    {
        public int codigo_M { get; set; }
        public int cantidad { get; set; }
        public string nombre_M { get; set; }
        public int precio_M { get; set; }
        public string ingre_M { get; set; }
    }

    public class QueryComanda
    {

        public List<object> consultaReporteProducto(DateTime fechaInicial, DateTime fechaFinal)
        {

            try
            {
                using (Pizza_BD1 c = new Pizza_BD1())
                {
                    var r = from p in c.Producto_Proveedor
                            where p.fecha_ingreso_producto <= fechaFinal && p.fecha_ingreso_producto >= fechaInicial
                            select p;

                    return r.ToList<object>();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<object> filtrarCategoriaMenu(int idcategoria, int idtamano)
        {
            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    var categoriasMenu = from u in contexto.Menu
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

                    return categoriasMenu.ToList<object>();

                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        public bool addcomanda(List<carro> listaCarro, int numeroMesa, int idUser)
        {
            int cod_comanda = 0;

            using (Pizza_BD1 c = new Pizza_BD1())
            {
                ComandaMesa comanda = new ComandaMesa { codigo_usuario = idUser, idMesa = numeroMesa, fecha = DateTime.Now };
                c.ComandaMesa.Add(comanda);
                c.SaveChanges();
                cod_comanda = comanda.codigo_comanda;
            }

            using (Pizza_BD1 c = new Pizza_BD1())
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

        //CARGA TABLA DETALLE PAGO

        public List<object> filtrarTipoPago()
        {
            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    var formaPago = from tp in contexto.TipoPago
                                    select new
                                    {
                                        tp.codigo_tipoPago,
                                        tp.nombre
                                    };

                    return formaPago.ToList<object>();

                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        public bool addPago(Detalle_Pago pago)
        {

            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    contexto.Detalle_Pago.Add(pago);
                    contexto.SaveChanges();

                    int respuestas = contexto.SaveChanges(); //INSERTA EN LA TABLA DE BASE DE DATOS

                    return respuestas == 1; //VALIDA SI LO ANGREGA O NO, SI ES UN 1 ES TRUE SI NO AGREGAR NADA ES FALSE
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}