﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bd8 : DbContext
    {
        public bd8()
            : base("name=bd8")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Asignar_Menu> Asignar_Menu { get; set; }
        public virtual DbSet<BoletaComanda> BoletaComanda { get; set; }
        public virtual DbSet<Caja> Caja { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Comanda_reparto> Comanda_reparto { get; set; }
        public virtual DbSet<ComandaMesa> ComandaMesa { get; set; }
        public virtual DbSet<Estado_caja> Estado_caja { get; set; }
        public virtual DbSet<Estado_Mesa> Estado_Mesa { get; set; }
        public virtual DbSet<Estado_Usuario> Estado_Usuario { get; set; }
        public virtual DbSet<Menu_Link> Menu_Link { get; set; }
        public virtual DbSet<Mesa> Mesa { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<PagoRepartidor> PagoRepartidor { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Producto_Proveedor> Producto_Proveedor { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<TamanoP> TamanoP { get; set; }
        public virtual DbSet<TipoPago> TipoPago { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Turno> Turno { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Detalle_Mesa> Detalle_Mesa { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
    }
}
