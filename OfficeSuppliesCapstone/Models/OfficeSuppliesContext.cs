using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OfficeSuppliesCapstone
{
    public partial class OfficeSuppliesContext : DbContext
    {
        public OfficeSuppliesContext()
        {
        }

        public OfficeSuppliesContext(DbContextOptions<OfficeSuppliesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<RequestLine> RequestLine { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            //    modelBuilder.Entity<Product>(entity =>
            //    {
            //        entity.HasIndex(e => e.Id)
            //            .HasName("IX_Product")
            //            .IsUnique();

            //        entity.HasIndex(e => e.PartNbr)
            //            .HasName("IX_Product_1")
            //            .IsUnique();

            //        entity.Property(e => e.Id);

            //        entity.Property(e => e.Name)
            //            .IsRequired()
            //            .HasMaxLength(30);

            //        entity.Property(e => e.PartNbr)
            //            .IsRequired()
            //            .HasMaxLength(30);

            //        entity.Property(e => e.PhotoPath).HasMaxLength(255);

            //        entity.Property(e => e.Price).HasColumnType("decimal(11, 2)");

            //        entity.Property(e => e.Unit)
            //            .IsRequired()
            //            .HasMaxLength(30);

            //        //entity.HasOne(d => d.Vendor)
            //        //    //.WithMany(p => p.Product)
            //        //    //.HasForeignKey(d => d.VendorId)
            //        //    .OnDelete(DeleteBehavior.ClientSetNull)
            //        //    .HasConstraintName("FK_VendorId");
            //    });

            //    modelBuilder.Entity<Request>(entity =>
            //    {
            //        entity.Property(e => e.Id);

            //        entity.Property(e => e.DeliveryMode)
            //            .IsRequired()
            //            .HasMaxLength(20)
            //            .HasDefaultValueSql("(N'Pick Up')");

            //        entity.Property(e => e.Description)
            //            .IsRequired()
            //            .HasMaxLength(80);

            //        entity.Property(e => e.Justification)
            //            .IsRequired()
            //            .HasMaxLength(80);

            //        entity.Property(e => e.RejectionReason).HasMaxLength(80);

            //        entity.Property(e => e.Status)
            //            .IsRequired()
            //            .HasMaxLength(10)
            //            .HasDefaultValueSql("(N'NEW')");

            //        entity.Property(e => e.Total).HasColumnType("decimal(11, 2)");

            //        entity.HasOne(d => d.User)
            //            .WithMany(p => p.Request)
            //            .HasForeignKey(d => d.UserId)
            //            .OnDelete(DeleteBehavior.ClientSetNull)
            //            .HasConstraintName("FK_UserId");
            //    });

            //    modelBuilder.Entity<RequestLine>(entity =>
            //    {
            //        entity.Property(e => e.Id);

            //        entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

            //        //entity.HasOne(d => d.Product)
            //            //.WithMany(p => p.RequestLine)
            //            //.HasForeignKey(d => d.ProductId)
            //            //.OnDelete(DeleteBehavior.ClientSetNull)
            //            //.HasConstraintName("FK_ProductId");

            //        entity.HasOne(d => d.Request)
            //            .WithMany(p => p.RequestLine)
            //            .HasForeignKey(d => d.RequestId)
            //            .OnDelete(DeleteBehavior.ClientSetNull)
            //            .HasConstraintName("FK__RequestId");
            //    });

            //    modelBuilder.Entity<Users>(entity =>
            //    {
            //        entity.HasIndex(e => e.Id)
            //            .HasName("IX_User")
            //            .IsUnique();

            //        entity.HasIndex(e => e.Username)
            //            .HasName("IX_Users")
            //            .IsUnique();

            //        entity.Property(e => e.Id).HasColumnName("ID");

            //        entity.Property(e => e.Email).HasMaxLength(255);

            //        entity.Property(e => e.Firstname)
            //            .IsRequired()
            //            .HasMaxLength(30);

            //        entity.Property(e => e.Lastname)
            //            .IsRequired()
            //            .HasMaxLength(30);

            //        entity.Property(e => e.Password)
            //            .IsRequired()
            //            .HasMaxLength(30);

            //        entity.Property(e => e.Phone).HasMaxLength(12);

            //        entity.Property(e => e.Username)
            //            .IsRequired()
            //            .HasMaxLength(30);
            //    });

            //    modelBuilder.Entity<Vendor>(entity =>
            //    {
            //        entity.HasIndex(e => e.Code)
            //            .HasName("IX_Vendor_1")
            //            .IsUnique();

            //        entity.HasIndex(e => e.Id)
            //            .HasName("IX_Vendor")
            //            .IsUnique();

            //        entity.Property(e => e.Address)
            //            .IsRequired()
            //            .HasMaxLength(30);

            //        entity.Property(e => e.City)
            //            .IsRequired()
            //            .HasMaxLength(30);

            //        entity.Property(e => e.Code)
            //            .IsRequired()
            //            .HasMaxLength(30);

            //        entity.Property(e => e.Email).HasMaxLength(255);

            //        entity.Property(e => e.Name)
            //            .IsRequired()
            //            .HasMaxLength(30);

            //        entity.Property(e => e.Phone).HasMaxLength(12);

            //        entity.Property(e => e.State)
            //            .IsRequired()
            //            .HasMaxLength(2);

            //        entity.Property(e => e.Zip)
            //            .IsRequired()
            //            .HasMaxLength(12);
            //    });
        }
    }
}
