using Pizza_Express_visual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizza_Express_visual.Services
{
    public class QueryCaja
    {


        public List<object> filtrarCajas() {

            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1()) {

                    var r = from dc in contexto.detalleCaja
                            join c in contexto.Caja
                            on dc.numero_caja equals c.numero_caja
                            join u in contexto.Usuario
                            on dc.codigo_usuario equals  u.codigo_usuario
                            join e in contexto.Estado_caja
                            on c.codigo_estado equals e.codigo_estado
                            orderby dc.id_DetalleCaja descending
                            select new
                            {
                                dc.id_DetalleCaja,
                                dc.monto_apertura,
                                dc.fecha,
                                dc.hora,
                                c.numero_caja,
                                e.nombre_estado,
                                u.nombre_usuario
                            };

                    return r.ToList<object>();

                }

            }
            catch (Exception e) 
            {
                return null;
            }
        
        }




        public List<object> filtrarNcaja()
        {
            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {
                    var r = from t in contexto.Caja
                            select new { t.numero_caja, t.codigo_estado };
                    return r.ToList<object>();
                }
            }
            catch (Exception)
            {
                return null;

            }
        }


        public bool addMonto(detalleCaja DetalleCaja)
        {

            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    contexto.detalleCaja.Add(DetalleCaja);
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

        public bool eliminarCaja(int id)
        {

            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {
                    var cajae = contexto.detalleCaja.Find(id);

                    cajae.Caja.codigo_estado = 1;
                    contexto.detalleCaja.Remove(cajae);
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

        public bool cerrarCaja(int id) {

            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1()) 
                {
                    var c = contexto.detalleCaja.Find(id);
                    c.Caja.codigo_estado = 2;

                    int respuesta = contexto.SaveChanges();
                    return respuesta == 1;
                }

            }      
            catch (Exception)
            {
                return false;
            
            }
        
        
        }

        public bool abrirCaja(int id)
        {

            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {
                    var c = contexto.detalleCaja.Find(id);
                    c.Caja.codigo_estado = 1;

                    int respuesta = contexto.SaveChanges();
                    return respuesta == 1;
                }

            }
            catch (Exception)
            {
                return false;

            }


        }



        public bool editarCaja(detalleCaja caja, string idOriginal)
        {

            try
            {
                int idOri = Convert.ToInt32(idOriginal);
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    var cajae = contexto.detalleCaja.First(caj => caj.id_DetalleCaja == idOri);

                    //MODIFICAR LOS CAMPOS QUE NECESITO

                    cajae.monto_apertura = caja.monto_apertura;
                    cajae.fecha = caja.fecha;
                    cajae.hora = caja.hora;
                    cajae.numero_caja = caja.numero_caja;
                    cajae.codigo_usuario = caja.codigo_usuario;

                    int respuesta = contexto.SaveChanges();
                    return respuesta == 1;

                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public int BuscarCaja(int dato)
        {
            using (Pizza_BD1 contexto = new Pizza_BD1())
            {

                var r = from dc in contexto.detalleCaja
                                where dc.numero_caja == dato
                                join c in contexto.Caja on dc.numero_caja equals c.numero_caja
                                join u in contexto.Usuario on dc.codigo_usuario equals u.codigo_usuario
                                orderby dc.id_DetalleCaja descending
                                
                                select new
                                {
                                    dc.id_DetalleCaja,
                                    dc.monto_apertura,
                                    dc.fecha,
                                    dc.hora,
                                    c.numero_caja,
                                    u.nombre_usuario
                                };
                

               
                return r.FirstOrDefault().monto_apertura;

            }







        }





    }





    }
