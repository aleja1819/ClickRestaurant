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
    
    public partial class BoletaComanda
    {
        public int codigo_boleta { get; set; }
        public System.DateTime fecha { get; set; }
        public int subTotal { get; set; }
        public int total { get; set; }
        public int codigo_menu { get; set; }
        public int codigo_comanda { get; set; }
        public int codigo_pago { get; set; }
        public int numero_caja { get; set; }
    
        public virtual Caja Caja { get; set; }
        public virtual Detalle_Mesa Detalle_Mesa { get; set; }
        public virtual Pago Pago { get; set; }
    }
}
