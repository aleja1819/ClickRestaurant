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
    
    public partial class Detalle_Pago
    {
        public int codigo_pago { get; set; }
        public int codigo_tipoPago { get; set; }
        public Nullable<int> numeroTransaccion { get; set; }
        public int propina { get; set; }
        public int descuento { get; set; }
        public int codigo_comanda { get; set; }
    
        public virtual ComandaMesa ComandaMesa { get; set; }
        public virtual TipoPago TipoPago { get; set; }
    }
}
