using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pizza_Express_visual.Models;
namespace Pizza_Express_visual.Services
{
    public class QueryReservas
    {
        static List<QueryReservas> queryReservas = new List<QueryReservas>();

        //LINQ TO ENTITY
        public List<object> filtrarReservas()
        {
            try
            {
                using (bd7 contexto = new bd7())
                {

                    var re = from r in contexto.Reserva
                             join m in contexto.Mesa
                             on r.numero_mesa equals m.numero_mesa
                             select new { r.codigo_reserva, m.numero_mesa, r.nombre_reserva, r.fecha_reserva };

                    return re.ToList<object>();

                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        //AGREGAR PROVEEDOR
        public bool addReserva(Reserva reserva)
        {

            try
            {
                using (bd7 contexto = new bd7())
                {

                    contexto.Reserva.Add(reserva);
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

        public bool eliminarReserva(int codigo_reserva)
        {

            try
            {
                using (bd7 contexto = new bd7())
                {
                    var user = contexto.Reserva.Find(codigo_reserva);

                    contexto.Reserva.Remove(user);
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

        public bool editarReservas(Reserva reser, string cod_original)
        {

            try
            {
                int idOri = Convert.ToInt32(cod_original);
                using (bd7 contexto = new bd7())
                {

                    //BUSCAR EL PRODUCTO EN LA BD
                    var user = contexto.Reserva.First(r => r.codigo_reserva == idOri);

                    //MODIFICAR LOS CAMPOS QUE NECESITO

                    user.numero_mesa = reser.numero_mesa;
                    user.nombre_reserva = reser.nombre_reserva;
                    user.fecha_reserva = reser.fecha_reserva;
                    //user.hora_reserva = reser.hora_reserva;

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

        public List<object> BuscarrReservas(string dato, int filtro)
        {
            using (bd7 contexto = new bd7())
            {
                switch (filtro)
                {
                    case 0: //BUSCAR NUMERO MESA
                        var rRut = from r in contexto.Reserva
                                   join m in contexto.Mesa
                                   on r.numero_mesa equals m.numero_mesa
                                   where m.numero_mesa.ToLower().StartsWith(dato.ToLower())
                                   select new { r.codigo_reserva, m.numero_mesa, r.nombre_reserva, r.fecha_reserva };

                        return rRut.ToList<object>();
                    default:
                        var rTodo = from r in contexto.Reserva
                                    join m in contexto.Mesa
                                    on r.numero_mesa equals m.numero_mesa
                                    select m;

                        return rTodo.ToList<object>();
                }


            }
        }
    }
}
