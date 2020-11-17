using Pizza_Express_visual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    var re = from r in contexto.Reserva
                             join m in contexto.Mesa
                             on r.idMesa equals m.idMesa
                             select new { r.codigo_reserva, m.numeroMesa, r.nombre_reserva, r.fecha_reser, r.hora_reser };

                    return re.ToList<object>();

                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        public bool addReserva(Reserva reserva, ref int idreserva)
        {

            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    contexto.Reserva.Add(reserva);
                    contexto.SaveChanges();

                    int respuestas = contexto.SaveChanges();
                    idreserva = reserva.codigo_reserva;

                    return respuestas == 1;
                }
            }
            catch (Exception e)
            {

                return e.Equals("");
            }
        }

        public int codigoMesaRegistrar(string nMesa)
        {
            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {
                    int cod = contexto.Mesa.First(x => x.numeroMesa.Equals(nMesa)).idMesa;
                    return cod;
                }
            }
            catch (Exception)
            {
                return -1;
            }

        }
        public bool eliminarReserva(int codigoReserva)
        {

            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {
                    var user = contexto.Reserva.Find(codigoReserva);

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
        public bool editarReservas(Reserva reser, string idOriginal)
        {

            try
            {
                int idOri = Convert.ToInt32(idOriginal);
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    var user = contexto.Reserva.First(r => r.codigo_reserva == idOri);

                    //MODIFICAR LOS CAMPOS QUE NECESITO
                    user.idMesa = reser.idMesa;
                    user.nombre_reserva = reser.nombre_reserva;
                    user.fecha_reser = reser.fecha_reser;

                    int respuesta = contexto.SaveChanges();
                    return respuesta == 1;

                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<object> BuscarReservas(string dato, int filtro)
        {
            using (Pizza_BD1 contexto = new Pizza_BD1())
            {
                switch (filtro)
                {
                    case 0: 
                        var retornarRut = from r in contexto.Reserva
                                   join m in contexto.Mesa
                                   on r.idMesa equals m.idMesa
                                   where m.numeroMesa.ToLower().StartsWith(dato.ToLower())
                                   select new { r.codigo_reserva, m.numeroMesa, r.nombre_reserva, r.fecha_reser };

                        return retornarRut.ToList<object>();
                    default:
                        var retornarTodo = from r in contexto.Reserva
                                    join m in contexto.Mesa
                                    on r.idMesa equals m.idMesa
                                    select m;

                        return retornarTodo.ToList<object>();
                }
            }
        }
    }
}
