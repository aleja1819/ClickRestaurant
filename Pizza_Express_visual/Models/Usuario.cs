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
    
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.ComandaMesa = new HashSet<ComandaMesa>();
            this.detalleCaja = new HashSet<detalleCaja>();
            this.Producto = new HashSet<Producto>();
        }
    
        public int codigo_usuario { get; set; }
        public int codigo_tipoUsuario { get; set; }
        public int codigo_estado { get; set; }
        public string nombre_usuario { get; set; }
        public string contraseña_usuario { get; set; }
        public string rut_usuario { get; set; }
        public string email_usuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComandaMesa> ComandaMesa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalleCaja> detalleCaja { get; set; }
        public virtual Estado_Usuario Estado_Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
    }
}