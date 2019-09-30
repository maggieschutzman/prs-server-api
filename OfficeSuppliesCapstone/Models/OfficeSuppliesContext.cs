using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OfficeSuppliesCapstone {
    public partial class OfficeSuppliesContext : DbContext {
        public OfficeSuppliesContext() {
        }

        public OfficeSuppliesContext(DbContextOptions<OfficeSuppliesContext> options)
            : base(options) {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<RequestLine> RequestLine { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //    modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Product>(entity => {
                entity.HasIndex(e => e.Id)
                    .HasName("IX_Product")
                    .IsUnique();

                entity.HasIndex(e => e.PartNbr)
                    .HasName("IX_Product_1")
                    .IsUnique();
            });

        }
    }
}
 

