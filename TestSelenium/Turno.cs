//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestSelenium
{
    using System;
    using System.Collections.Generic;
    
    public partial class Turno
    {
        public int codigo_usuario { get; set; }
        public int numero_caja { get; set; }
        public System.DateTime fecha { get; set; }
        public System.TimeSpan hora { get; set; }
    
        public virtual Caja Caja { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
