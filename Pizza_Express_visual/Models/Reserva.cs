//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pizza_Express_visual.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reserva
    {
        public int codigo_reserva { get; set; }
        public int idMesa { get; set; }
        public string nombre_reserva { get; set; }
        public System.DateTime fecha_reser { get; set; }
        public System.TimeSpan hora_reser { get; set; }
    
        public virtual Mesa Mesa { get; set; }
    }
}
