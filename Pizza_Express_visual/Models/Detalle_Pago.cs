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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Detalle_Pago()
        {
            this.BoletaComanda = new HashSet<BoletaComanda>();
        }
    
        public int codigo_pago { get; set; }
        public int codigo_tipoPago { get; set; }
        public int numeroTransaccion { get; set; }
        public int propina { get; set; }
        public int descuento { get; set; }
        public Nullable<int> codigo_comanda { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoletaComanda> BoletaComanda { get; set; }
        public virtual ComandaMesa ComandaMesa { get; set; }
        public virtual TipoPago TipoPago { get; set; }
    }
}
