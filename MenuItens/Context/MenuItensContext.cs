using Microsoft.EntityFrameworkCore;
using MenuItens.Models;

namespace MenuItens.Context
{
    public class MenuItensContext : DbContext // Building contex for Api
    {
        public MenuItensContext(DbContextOptions<MenuItensContext> options) : base(options)
        {
        }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<PrdComponents> PrdComponents { get; set; }
        public virtual DbSet<PrdActive> PrdActive { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

            //Building the Many-to-many relationship with Product and and its Components
            modelBuilder.Entity<PrdComponents>().HasKey(xy => new { xy.PrdId, xy.ChildPrdId });
            modelBuilder.Entity<PrdComponents>().HasOne(xy => xy.Products).WithMany(y => y.Components)
                .HasForeignKey(xy => xy.PrdId);
            modelBuilder.Entity<PrdComponents>().HasOne(xy => xy.ProductChild).WithMany()
                .HasForeignKey(xy => xy.ChildPrdId);

            //Building the One-to-One relationship with Product and and its Status
            modelBuilder.Entity<Product>().HasOne(x => x.PrdActive)
                .WithOne(x => x.Product).HasForeignKey<PrdActive>(x => x.PrdId);

            modelBuilder.Entity<PrdComponents>().ToTable("PrdComponents");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<PrdActive>().ToTable("PrdActive");


        }

    }
}
