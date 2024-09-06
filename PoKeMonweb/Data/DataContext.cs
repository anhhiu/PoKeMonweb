using Microsoft.EntityFrameworkCore;
using PoKeMonweb.Models;
using System.Data;
using System.Reflection.PortableExecutable;

namespace PoKeMonweb.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
         
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public  DbSet<PoKemonOwner> PoKemonOwners { get; set; }
        public DbSet<PoKemonCategory> PoKemonCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PoKemonCategory>()
                .HasKey(pc => new { pc.PoKemonId, pc.CategoryId });
            modelBuilder.Entity<PoKemonCategory>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PoKemonCategories)
                .HasForeignKey(pc => pc.PoKemonId);
            modelBuilder.Entity<PoKemonCategory>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.PoKemonCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<PoKemonOwner>()
                .HasKey(po => new { po.PoKemonId, po.OwnerId });
            modelBuilder.Entity<PoKemonOwner>()
                .HasOne(p => p.Owner)
                .WithMany(po => po.PoKemonOwners)
                .HasForeignKey(o => o.OwnerId);
            modelBuilder.Entity<PoKemonOwner>()
                .HasOne(p => p.Pokemon)
                .WithMany(po => po.PoKemonOwners)
                .HasForeignKey(p => p.PoKemonId);


        }
    }
}
