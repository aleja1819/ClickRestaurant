using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInicioSesion
{
    class Susuario
    {
        public List<object> filtrarUsuarios()
        {
            try
            {
                using (Pizza_BD contexto = new Pizza_BD())
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
            public bool addUsuario(Usuario user)
            {

                try
                {
                    using (Pizza_BD contexto = new Pizza_BD())
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

        public bool editarUsuario(Usuario usuario, string idOriginal)
        {

            try
            {
                int idOri = Convert.ToInt32(idOriginal);
                using (Pizza_BD contexto = new Pizza_BD())
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

        public bool eliminarUsuario(int idUsuario)
        {

            try
            {
                using (Pizza_BD contexto = new Pizza_BD())
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
    }
    }

