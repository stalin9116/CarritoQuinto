﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarritoQuinto.BackEnd.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDDCARRITO2Entities : DbContext
    {
        public BDDCARRITO2Entities()
            : base("name=BDDCARRITO2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBL_CATEGORIA> TBL_CATEGORIA { get; set; }
        public virtual DbSet<TBL_CLIENTE> TBL_CLIENTE { get; set; }
        public virtual DbSet<TBL_DETALLEIMPUESTOS> TBL_DETALLEIMPUESTOS { get; set; }
        public virtual DbSet<TBL_DETALLEPEDIDO> TBL_DETALLEPEDIDO { get; set; }
        public virtual DbSet<TBL_DIRECCIONES> TBL_DIRECCIONES { get; set; }
        public virtual DbSet<TBL_FORMAPAGO> TBL_FORMAPAGO { get; set; }
        public virtual DbSet<TBL_IMPUESTOS> TBL_IMPUESTOS { get; set; }
        public virtual DbSet<TBL_PAGOS> TBL_PAGOS { get; set; }
        public virtual DbSet<TBL_PEDIDO> TBL_PEDIDO { get; set; }
        public virtual DbSet<TBL_PRODUCTO> TBL_PRODUCTO { get; set; }
        public virtual DbSet<TBL_ROL> TBL_ROL { get; set; }
        public virtual DbSet<TBL_USUARIO> TBL_USUARIO { get; set; }
    }
}