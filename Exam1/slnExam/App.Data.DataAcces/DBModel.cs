namespace App.Data.DataAcces
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using App.Entities.Base;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=cnxDBModel")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Grado> Grado { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Notas> Notas { get; set; }
        public virtual DbSet<Seccion> Seccion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>()
                .Property(e => e.Sexo)
                .IsFixedLength();

            modelBuilder.Entity<Alumno>()
                .HasMany(e => e.Matricula)
                .WithRequired(e => e.Alumno)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Alumno>()
                .HasMany(e => e.Notas)
                .WithRequired(e => e.Alumno)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.Notas)
                .WithRequired(e => e.Curso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grado>()
                .HasMany(e => e.Curso)
                .WithRequired(e => e.Grado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grado>()
                .HasMany(e => e.Matricula)
                .WithRequired(e => e.Grado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grado>()
                .HasMany(e => e.Seccion)
                .WithRequired(e => e.Grado)
                .WillCascadeOnDelete(false);
        }
    }
}
