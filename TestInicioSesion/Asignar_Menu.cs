//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestInicioSesion
{
    using System;
    using System.Collections.Generic;
    
    public partial class Asignar_Menu
    {
        public int idAsignarMenu { get; set; }
        public int codigo_tipoUsuario { get; set; }
        public int idMenu { get; set; }
    
        public virtual Menu_Link Menu_Link { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
    }
}
