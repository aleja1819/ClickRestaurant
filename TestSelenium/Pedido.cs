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
    
    public partial class Pedido
    {
        public int numero_caja { get; set; }
        public int codigo_reparto { get; set; }
        public System.DateTime fecha_reparto { get; set; }
        public System.TimeSpan hora_reparto { get; set; }
        public int total { get; set; }
    
        public virtual Caja Caja { get; set; }
        public virtual Comanda_reparto Comanda_reparto { get; set; }
    }
}
