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
    
    public partial class Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu()
        {
            this.Detalle_Mesa = new HashSet<Detalle_Mesa>();
        }
    
        public int codigo_menu { get; set; }
        public int codigo_categoria { get; set; }
        public string nombre_menu { get; set; }
        public int precio_menu { get; set; }
        public string ingredientes_menu { get; set; }
        public int codigo_tamanoP { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Mesa> Detalle_Mesa { get; set; }
        public virtual TamanoP TamanoP { get; set; }
    }
}