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
                             select new {r.codigo_reserva, m.numero_mesa, r.nombre_reserva, r.fecha_reserva, r.hora_reserva};

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