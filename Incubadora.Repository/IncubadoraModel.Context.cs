﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Incubadora.Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IncubadoraDataBaseEntities : DbContext
    {
        public IncubadoraDataBaseEntities()
            : base("name=IncubadoraDataBaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<CatCarreras> CatCarreras { get; set; }
        public virtual DbSet<CatCuatrimestres> CatCuatrimestres { get; set; }
        public virtual DbSet<CatPaises> CatPaises { get; set; }
        public virtual DbSet<CatUnidadesAcademicas> CatUnidadesAcademicas { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Telefonos> Telefonos { get; set; }
        public virtual DbSet<DatosLaborales> DatosLaborales { get; set; }
        public virtual DbSet<CatFases> CatFases { get; set; }
        public virtual DbSet<CatGiros> CatGiros { get; set; }
        public virtual DbSet<CatModalidades> CatModalidades { get; set; }
        public virtual DbSet<CatServicios> CatServicios { get; set; }
        public virtual DbSet<ServiciosUniversitarios> ServiciosUniversitarios { get; set; }
        public virtual DbSet<Colaboradores> Colaboradores { get; set; }
        public virtual DbSet<Calendarizacion> Calendarizacion { get; set; }
        public virtual DbSet<Modulos> Modulos { get; set; }
        public virtual DbSet<Sesiones> Sesiones { get; set; }
        public virtual DbSet<SubModulos> SubModulos { get; set; }
        public virtual DbSet<Proyectos> Proyectos { get; set; }
        public virtual DbSet<CatColonias> CatColonias { get; set; }
        public virtual DbSet<CatEstados> CatEstados { get; set; }
        public virtual DbSet<CatMunicipios> CatMunicipios { get; set; }
        public virtual DbSet<Direcciones> Direcciones { get; set; }
        public virtual DbSet<CatSexos> CatSexos { get; set; }
        public virtual DbSet<Docentes> Docentes { get; set; }
        public virtual DbSet<Emprendedores> Emprendedores { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CatAvatars> CatAvatars { get; set; }
        public virtual DbSet<Recursos> Recursos { get; set; }
        public virtual DbSet<RecursosProyectos> RecursosProyectos { get; set; }
        public virtual DbSet<CatGrupos> CatGrupos { get; set; }
        public virtual DbSet<CatPeriodoEstadia> CatPeriodoEstadia { get; set; }
        public virtual DbSet<EmprendimientoEstadia> EmprendimientoEstadia { get; set; }
        public virtual DbSet<Estudiantes> Estudiantes { get; set; }
        public virtual DbSet<SubModuloSesionesProyecto> SubModuloSesionesProyecto { get; set; }
    }
}
