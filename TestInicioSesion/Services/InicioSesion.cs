using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza_Express_visual.Services;



namespace TestInicioSesion
{
    [TestClass]
    public class InicioSesion
    {
        private QueryUsuario accesoUsuario = new QueryUsuario();

 
        [TestMethod]
        public void TestMethod1()
        {

            void registrarUsuario()
            {

                string rut = Convert.ToString("17.854.755-0");
                string nombre = Convert.ToString("Alejandra");
                string email = Convert.ToString("ale@gmail.cl");
                string clave = Convert.ToString("1234");

                int id = Convert.ToInt32(1);
                int idE = Convert.ToInt32(1);

                accesoUsuario.addUsuario(new Pizza_Express_visual.Models.Usuario
                {


                    rut_usuario = rut,
                    nombre_usuario = nombre,
                    email_usuario = email,
                    contraseña_usuario = clave,
                    codigo_tipoUsuario = id,
                    codigo_estado = idE

                });

            }
        }

        void editarUsuarios()
        {

            string rut = Convert.ToString("17.334.675-0");
            string nombre = Convert.ToString("javier");
            string email = Convert.ToString("javier@gmail.cl");
            string clave = Convert.ToString("1234");

            int id = Convert.ToInt32(1);
            int idE = Convert.ToInt32(1);

            string codigoOriginal = Convert.ToString("");

            accesoUsuario.editarUsuario(new Pizza_Express_visual.Models.Usuario
            {

                rut_usuario = rut,
                nombre_usuario = nombre,
                email_usuario = email,
                contraseña_usuario = clave,
                codigo_tipoUsuario = id,
                codigo_estado = idE


            }, codigoOriginal);

        }

        void EliminarUsuarios()
        {
            int codigo = Convert.ToInt32(1);
            int id = Convert.ToInt32(codigo);
            accesoUsuario.eliminarUsuario(id);
        }

        protected void logins(string tnombres, string tclave)
        {

            Pizza_Express_visual.Services.QueryUsuario user = new Pizza_Express_visual.Services.QueryUsuario();
            int[] respuestas = user.validateUser(tnombres.Trim(), tclave.Trim());
            if (respuestas[0] == 0)
            {

                Console.WriteLine("Clave o Usuario Incorrecto");
            }
            else
            {
                if (respuestas[1] == 0)
                {
                    Console.WriteLine("Clave o Usuario Incorrecto");
                }
                else
                {
                    Console.WriteLine("Inicio de sesión con exito");

                }
            }
        }
    }
}


    
