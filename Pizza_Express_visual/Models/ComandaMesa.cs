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
    
    public partial class ComandaMesa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ComandaMesa()
        {
            this.Detalle_Mesa = new HashSet<Detalle_Mesa>();
            this.Detalle_Pago = new HashSet<Detalle_Pago>();
        }
    
        public int codigo_comanda { get; set; }
        public int codigo_usuario { get; set; }
        public int idMesa { get; set; }
        public System.DateTime fecha { get; set; }
        public Nullable<int> idEstadoPago { get; set; }
        public Nullable<int> id_DetalleCaja { get; set; }
    
        public virtual detalleCaja detalleCaja { get; set; }
        public virtual Estado_Pago Estado_Pago { get; set; }
        public virtual Mesa Mesa { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Mesa> Detalle_Mesa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Pago> Detalle_Pago { get; set; }
    }
}