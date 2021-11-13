using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Parcialito.Models
{
    public partial class tienditaModelo : DbContext
    {
        public tienditaModelo()
            : base("name=tienditaModelo")
        {
        }

        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<pedidos> pedidos { get; set; }
        public virtual DbSet<producto> producto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cliente>()
                .Property(e => e.nombreCliente)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.DUI)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .HasMany(e => e.pedidos)
                .WithOptional(e => e.cliente)
                .HasForeignKey(e => e.idCliente);

            modelBuilder.Entity<producto>()
                .HasMany(e => e.pedidos)
                .WithOptional(e => e.producto)
                .HasForeignKey(e => e.idProducto);
        }
    }
}
