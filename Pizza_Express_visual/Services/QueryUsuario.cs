using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pizza_Express_visual.Models;

namespace Pizza_Express_visual.Services
{
    public class QueryUsuario
    {

        static List<QueryUsuario> queryUsuarios = new List<QueryUsuario>();

        //LINQ TO ENTITY
        public List<object> filtrarUsuarios() {
            try
            {
                using (bd1 contexto = new bd1())
                {
                    //var r = from u in contexto.Usuario
                    //        select u;

                    var r = from u in contexto.Usuario
                            join t in contexto.TipoUsuario
                            on u.codigo_tipoUsuario equals t.codigo_tipoUsuario
                            select new { u.codigo_usuario, u.rut_usuario, u.nombre_usuario, u.email_usuario, u.contraseña_usuario, t.nombre_tipoUsuario };

                    return r.ToList<object>();

                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        //AGREGAR USUARIO
        public bool addUsuario(Usuario user) {

            try
            {
                using (bd1 contexto = new bd1()) {

                    contexto.Usuario.Add(user);
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

        //ELIMINAR USUARIO
        public bool eliminarUsuario(Usuario codigo_user)
        {

            try
            {
                using (bd1 contexto = new bd1())
                {
                    var user = contexto.Usuario.Find(codigo_user);

                    contexto.Usuario.Remove(user);
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

        public bool editarUsuario(Usuario codigo_user) {

            try
            {
                using (bd1 contexto = new bd1()) {


                    var user = contexto.Usuario.Find(codigo_user);
                    contexto.Usuario.First(u => u.codigo_usuario.Equals(user));
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

    }
}