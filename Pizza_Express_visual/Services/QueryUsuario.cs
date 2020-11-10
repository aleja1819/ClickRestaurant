using Pizza_Express_visual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Pizza_Express_visual.Services
{
    public class QueryUsuario
    {

        //LINQ TO ENTITY
        public List<object> filtrarUsuarios()
        {
            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    var r = from u in contexto.Usuario
                            join t in contexto.TipoUsuario
                            on u.codigo_tipoUsuario equals t.codigo_tipoUsuario
                            join e in contexto.Estado_Usuario
                            on u.codigo_estado equals e.codigo_estado
                            select new
                            {
                                u.codigo_usuario,
                                u.rut_usuario,
                                u.nombre_usuario,
                                u.email_usuario,
                                u.contraseña_usuario,
                                t.nombre_tipoUsuario,
                                t.codigo_tipoUsuario,
                                e.codigo_estado,
                                e.nombre_estado
                            };

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
                using (Pizza_BD1 contexto = new Pizza_BD1())
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

        public List<object> filtrarEstado()
        {
            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    var r = from e in contexto.Estado_Usuario
                            select new { e.codigo_estado, e.nombre_estado };

                    return r.ToList<object>();
                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        public bool addUsuario(Usuario user)
        {

            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
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

        public bool eliminarUsuario(int idUsuario)
        {

            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {
                    var user = contexto.Usuario.Find(idUsuario);

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
        public bool editarUsuario(Usuario usuario, string idOriginal)
        {

            try
            {
                int idOri = Convert.ToInt32(idOriginal);
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    var user = contexto.Usuario.First(usu => usu.codigo_usuario == idOri);

                    //MODIFICAR LOS CAMPOS QUE NECESITO
                    user.rut_usuario = usuario.rut_usuario;
                    user.nombre_usuario = usuario.nombre_usuario;
                    user.email_usuario = usuario.email_usuario;
                    user.contraseña_usuario = usuario.contraseña_usuario;
                    user.codigo_tipoUsuario = usuario.codigo_tipoUsuario;
                    user.codigo_estado = usuario.codigo_estado;

                    int respuesta = contexto.SaveChanges();
                    return respuesta == 1;

                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<object> BuscarUsuarios(string dato, int filtro)
        {
            using (Pizza_BD1 contexto = new Pizza_BD1())
            {
                switch (filtro)
                {
                    case 0: 
                        var retornoRut = from u in contexto.Usuario
                                   where u.rut_usuario.ToLower().StartsWith(dato.ToLower())
                                   join t in contexto.TipoUsuario
                                   on u.codigo_tipoUsuario equals t.codigo_tipoUsuario
                                   join e in contexto.Estado_Usuario
                                   on u.codigo_estado equals e.codigo_estado
                                   select new
                                   {
                                       u.codigo_usuario,
                                       u.rut_usuario,
                                       u.nombre_usuario,
                                       u.email_usuario,
                                       u.contraseña_usuario,
                                       t.nombre_tipoUsuario,
                                       t.codigo_tipoUsuario,
                                       e.codigo_estado,
                                       e.nombre_estado
                                   };

                        return retornoRut.ToList<object>();
                    case 1: 
                        var retornoNombre = from u in contexto.Usuario
                                      where u.nombre_usuario.ToLower().StartsWith(dato.ToLower())
                                      join t in contexto.TipoUsuario
                                      on u.codigo_tipoUsuario equals t.codigo_tipoUsuario
                                      join e in contexto.Estado_Usuario
                                      on u.codigo_estado equals e.codigo_estado
                                      select new
                                      {
                                          u.codigo_usuario,
                                          u.rut_usuario,
                                          u.nombre_usuario,
                                          u.email_usuario,
                                          u.contraseña_usuario,
                                          t.nombre_tipoUsuario,
                                          t.codigo_tipoUsuario,
                                          e.codigo_estado,
                                          e.nombre_estado
                                      };

                        return retornoNombre.ToList<object>();
                    default:
                        var retornarTodo = from u in contexto.Usuario
                                    join t in contexto.TipoUsuario
                                    on u.codigo_tipoUsuario equals t.codigo_tipoUsuario
                                    join e in contexto.Estado_Usuario
                                    on u.codigo_estado equals e.codigo_estado
                                    select new
                                    {
                                        u.codigo_usuario,
                                        u.rut_usuario,
                                        u.nombre_usuario,
                                        u.email_usuario,
                                        u.contraseña_usuario,
                                        t.nombre_tipoUsuario,
                                        t.codigo_tipoUsuario,
                                        e.codigo_estado,
                                        e.nombre_estado
                                    };

                        return retornarTodo.ToList<object>();
                }

            }
        }

        public List<LinkButton> menu(int idRol, List<LinkButton> links)
        {

            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {


                    var result = from a in contexto.Asignar_Menu
                                 join m in contexto.Menu_Link
                                 on a.idMenu equals m.idMenu
                                 where a.codigo_tipoUsuario == idRol
                                 select new { m.linkMenu };

                    foreach (var sis in result.ToList())
                    {
                        foreach (var menu in links)
                        {
                            if (sis.linkMenu.Equals(menu.ID))
                            {
                                menu.Visible = true;
                            }
                        }

                    }

                    return links;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int[] validateUser(string user, string clave)
        {

            int[] respuesta = new int[5];
            try
            {
                using (Pizza_BD1 contexto = new Pizza_BD1())
                {

                    var result = from u in contexto.Usuario
                                 where u.nombre_usuario.Trim().ToUpper().Equals(user.Trim().ToUpper())
                                 && u.contraseña_usuario.Equals(clave)
                                 select u;

                    respuesta[1] = result.Count() == 1 ? 1 : 0; //1 el usuario existe
                    respuesta[2] = result.First().codigo_estado == 1 ? 1 : 0; //1 el usuario tiene estado activo
                    respuesta[3] = result.First().codigo_tipoUsuario; //el rol que tiene asociado el usuario
                    respuesta[0] = 1; //sin errores de conexion al servidor
                    respuesta[4] = result.First().codigo_usuario;
                    return respuesta;

                }
            }
            catch (Exception ex)
            {
                string test = ex.ToString();
                respuesta[0] = 0;
                return respuesta;
            }
        }
    }
}

