using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Chocolates.Models
{
    public partial class DbChocolatesContext : DbContext
    {
        public DbChocolatesContext()
        {
        }

        public DbChocolatesContext(DbContextOptions<DbChocolatesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Chocolate> Chocolates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A2B5777C4A3A3A3D");

                entity.ToTable("Categoria");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Chocolate>(entity =>
            {
                entity.HasKey(e => e.IdChocolate)
                    .HasName("PK__Chocolat__D3B9D1A3A3A3A3D");

                entity.ToTable("Chocolate");

                entity.Property(e => e.IdChocolate).HasColumnName("idChocolate");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasColumnName("Imagen");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Chocolates)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Chocolate__idCat__3A81B327");
            });

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { IdCategoria = 1, Nombre = "Amargo", Descripcion = "Chocolates con sabor amargo" },
                new Categoria { IdCategoria = 2, Nombre = "Semiamargo", Descripcion = "Chocolate sabor semiamargo" },
                new Categoria { IdCategoria = 3, Nombre = "Oscuro", Descripcion = "Chocolate oscuro" },
                new Categoria { IdCategoria = 4, Nombre = "Blanco", Descripcion = "Chocolate blanco" },
                new Categoria { IdCategoria = 5, Nombre = "Relleno", Descripcion = "Chocolate relleno" }
            );
            modelBuilder.Entity<Chocolate>().HasData(
                new Chocolate { IdChocolate = 1, Nombre = "Chocolate Amargo 70%", Descripcion = "Chocolate oscuro con 70% de cacao", Imagen = "chocolate1.jpg", Precio = 50.00m, IdCategoria = 1 },
                new Chocolate { IdChocolate = 2, Nombre = "Chocolate Amargo 85%", Descripcion = "Chocolate oscuro con 85% de cacao", Imagen = "chocolate2.jpg", Precio = 60.00m, IdCategoria = 1 },
                new Chocolate { IdChocolate = 3, Nombre = "Chocolate Semiamargo 50%", Descripcion = "Chocolate semiamargo con 50% de cacao", Imagen = "chocolate3.jpg", Precio = 40.00m, IdCategoria = 2 },
                new Chocolate { IdChocolate = 4, Nombre = "Chocolate Semiamargo 60%", Descripcion = "Chocolate semiamargo con 60% de cacao", Imagen = "chocolate4.jpg", Precio = 45.00m, IdCategoria = 2 },
                new Chocolate { IdChocolate = 5, Nombre = "Chocolate Oscuro 75%", Descripcion = "Chocolate oscuro con 75% de cacao", Imagen = "chocolate5.jpg", Precio = 55.00m, IdCategoria = 3 },
                new Chocolate { IdChocolate = 6, Nombre = "Chocolate Oscuro 90%", Descripcion = "Chocolate oscuro con 90% de cacao", Imagen = "chocolate6.jpg", Precio = 65.00m, IdCategoria = 3 },
                new Chocolate { IdChocolate = 7, Nombre = "Chocolate Blanco", Descripcion = "Chocolate blanco cremoso", Imagen = "chocolate7.jpg", Precio = 50.00m, IdCategoria = 4 },
                new Chocolate { IdChocolate = 8, Nombre = "Chocolate Blanco con Almendras", Descripcion = "Chocolate blanco con trozos de almendras", Imagen = "chocolate8.jpg", Precio = 55.00m, IdCategoria = 4 },
                new Chocolate { IdChocolate = 9, Nombre = "Chocolate Relleno de Fresa", Descripcion = "Chocolate relleno de crema de fresa", Imagen = "chocolate9.jpg", Precio = 60.00m, IdCategoria = 5 },
                new Chocolate { IdChocolate = 10, Nombre = "Chocolate Relleno de Naranja", Descripcion = "Chocolate relleno de crema de naranja", Imagen = "chocolate10.jpg", Precio = 60.00m, IdCategoria = 5 }
            );

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
