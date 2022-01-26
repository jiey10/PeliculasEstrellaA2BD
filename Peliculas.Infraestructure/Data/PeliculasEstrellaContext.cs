using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Peliculas.Domain.Entities;
using Peliculas.Infraestructure.Repositories;

#nullable disable

namespace Peliculas.Infraestructure.Data
{
    public partial class PeliculasEstrellaContext : DbContext
    {
        public PeliculasEstrellaContext()
        {
        }

        public PeliculasEstrellaContext(DbContextOptions<PeliculasEstrellaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pelicula> Peliculas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=PeliculasEstrella.mssql.somee.com;Initial Catalog=PeliculasEstrella;Persist Security Info=False;User ID=Jiey17_SQLLogin_1;Password=llhjt9yjbq");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(e => e.IdPelicula);

                entity.ToTable("Pelicula");

                entity.Property(e => e.IdPelicula).HasColumnName("idPelicula");

                entity.Property(e => e.AnoPelicula)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("anoPelicula");

                entity.Property(e => e.CalfPelicula).HasColumnName("calfPelicula");

                entity.Property(e => e.DirectorPelicula)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("directorPelicula");

                entity.Property(e => e.GeneroPelicula)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("generoPelicula");

                entity.Property(e => e.NombrePelicula)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombrePelicula");

                entity.Property(e => e.PuntPelicula).HasColumnName("puntPelicula");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
