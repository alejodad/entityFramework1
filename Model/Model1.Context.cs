﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MaestrosEntities : DbContext
    {
        public MaestrosEntities()
            : base("name=MaestrosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_detalle_profesor_materia> tbl_detalle_profesor_materia { get; set; }
        public virtual DbSet<tbl_materia> tbl_materia { get; set; }
        public virtual DbSet<tbl_profesor> tbl_profesor { get; set; }
    }
}
