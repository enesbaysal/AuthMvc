﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ogrenciNotMvc.Models.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MvcOkulEntities : DbContext
    {
        public MvcOkulEntities()
            : base("name=MvcOkulEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TableDersler> TableDersler { get; set; }
        public virtual DbSet<TableKulupler> TableKulupler { get; set; }
        public virtual DbSet<TableNotlar> TableNotlar { get; set; }
        public virtual DbSet<TableOgrenciler> TableOgrenciler { get; set; }
        public virtual DbSet<TableAdmin> TableAdmin { get; set; }
    }
}
