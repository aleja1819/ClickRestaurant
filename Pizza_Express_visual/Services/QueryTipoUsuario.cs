using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pizza_Express_visual.Models;
namespace Pizza_Express_visual.Services
{
    public class QueryTipoUsuario
    {
        static List<QueryTipoUsuario> queryUsuarios = new List<QueryTipoUsuario>();

        public List<object> FiltroListaTipoUsuario() {

            try
            {
                using (bd3 contexto = new bd3()) {

                    var tu = from t in contexto.TipoUsuario
                             select new { t.nombre_tipoUsuario,t.codigo_tipoUsuario};

                    return tu.ToList<object>();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        //LISTAR TODOS LOS TIPOS DE USUARIOS
        public List<QueryTipoUsuario> ListarTodosLosTipoUsuarios() {
            return queryUsuarios.ToList();
        }

        //AGREGAR TIPO USUARIO
        public bool addTipoUsuario(TipoUsuario tipoU)
        {
            try
            {
                using (bd3 contexto = new bd3())
                {
                    contexto.TipoUsuario.Add(tipoU);
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

        //LIMPIAR TIPOS DE USUARIOS
        public void limpiarTipoUsuarios() {
            queryUsuarios.Clear();
        }
    }
}