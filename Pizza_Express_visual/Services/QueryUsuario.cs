using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pizza_Express_visual.Models;

namespace Pizza_Express_visual.Services
{
    public class QueryUsuario
    {
 

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
                            select new { u.rut_usuario, u.nombre_usuario, u.email_usuario, u.contraseña_usuario, t.nombre_tipoUsuario};

                    return r.ToList<object>();

                }
            }
            catch (Exception)
            {
                return null;
                
            }
        }

    }
}