using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pizza_Express_visual.Models;

namespace Pizza_Express_visual.Services
{
    public class QueryUsuario
    {

        //LINQ TO ENTITY
        public List<object> filtrarUsuarios()
        {
            try
            {
                using (bd5 contexto = new bd5())
                {

                    var r = from u in contexto.Usuario
                            join t in contexto.TipoUsuario
                            on u.codigo_tipoUsuario equals t.codigo_tipoUsuario
                            select new { u.codigo_usuario, u.rut_usuario, u.nombre_usuario, u.email_usuario, u.contraseña_usuario, t.nombre_tipoUsuario, t.codigo_tipoUsuario};

                    return r.ToList<object>();
                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        public List<object> filtrarTipoUsuarios()
        {
            try
            {
                using (bd5 contexto = new bd5())
                {

                    var r = from t in contexto.TipoUsuario
                            select new { t.nombre_tipoUsuario, t.codigo_tipoUsuario };

                    return r.ToList<object>();
                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        //AGREGAR USUARIO
        public bool addUsuario(Usuario user)
        {

            try
            {
                using (bd5 contexto = new bd5())
                {

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
        public bool eliminarUsuario(int codigo_user)
        {

            try
            {
                using (bd5 contexto = new bd5())
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

        public bool editarUsuario(Usuario usuario)
        {

            try
            {
                using (bd5 contexto = new bd5())
                {

                    //BUSCAR EL PRODUCTO EN LA BD
                    var user = contexto.Usuario.Find(usuario.codigo_usuario);

                    //MODIFICAR LOS CAMPOS QUE NECESITO

                    user.rut_usuario = usuario.rut_usuario;
                    user.nombre_usuario = usuario.nombre_usuario;
                    user.email_usuario = usuario.email_usuario;
                    user.contraseña_usuario = usuario.contraseña_usuario;
                    user.codigo_tipoUsuario = usuario.codigo_tipoUsuario;

                    //GUARDAR LOS CAMBIOS EN LA TABLA BD
                    int respuesta = contexto.SaveChanges();
                    return respuesta == 1;

                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<object> BuscarrUsuarios(string dato, int filtro)
        {
            using (bd5 contexto = new bd5())
            {
                switch (filtro){
                        case 0: //BUSCAR POR RUT
                            var rRut = from u in contexto.Usuario
                                       where u.rut_usuario.ToLower().StartsWith(dato.ToLower())
                                       join t in contexto.TipoUsuario
                                       on u.codigo_tipoUsuario equals t.codigo_tipoUsuario
                                       select u;

                            return rRut.ToList<object>();
                        case 1: //BUSCAR POR nombre
                        var rNombre = from u in contexto.Usuario
                                      where u.nombre_usuario.ToLower().StartsWith(dato.ToLower())
                                      join t in contexto.TipoUsuario
                                      on u.codigo_tipoUsuario equals t.codigo_tipoUsuario
                                      select u;

                        return rNombre.ToList<object>();
                        default:
                            var rTodo = from u in contexto.Usuario
                                        join t in contexto.TipoUsuario
                                        on u.codigo_tipoUsuario equals t.codigo_tipoUsuario
                                        select u;

                            return rTodo.ToList<object>();
                    }


                }
            }
        }
    }
