using AutoParts4Sale.ContentManagement;
using AutoParts4Sale.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoParts4Sale.Data
{
    public class AutoParts4SaleDbContext : IdentityDbContext<IdentityUser>
    {
        public InitialContentSetup initialContentSetup; 
        public AutoParts4SaleDbContext(DbContextOptions<AutoParts4SaleDbContext> options)
            : base(options)
        {
            initialContentSetup = new InitialContentSetup();
        }

        public DbSet<Autopart> Autoparts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed CarMakes
            var carMakes = initialContentSetup.GetInitialCarMakesValues();

            foreach (var item in carMakes)
            {
                modelBuilder.Entity<CarMake>().HasData(item);
            }

            // seed CarModels
            var carModels = initialContentSetup.GetInitialCarModelsValues();

            foreach (var item in carModels)
            {
                modelBuilder.Entity<CarModel>().HasData(item);
            }

            // seed Categories
            var categories = initialContentSetup.GetInitialCategoriesValues();

            foreach (var item in categories)
            {
                modelBuilder.Entity<Category>().HasData(item);
            }
        }
    }
}
