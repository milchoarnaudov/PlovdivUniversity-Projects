namespace AutoParts4Sale.Data
{
    using AutoParts4Sale.ContentManagement;
    using AutoParts4Sale.Core;
    using Microsoft.EntityFrameworkCore;

    public class AutoParts4SaleDbContext : DbContext
    {
        public AutoParts4SaleDbContext()
        {

        }

        public AutoParts4SaleDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Autopart> Autoparts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CarMake> CarMakes { get; set; }

        public DbSet<CarModel> CarModels { get; set; }

        public DbSet<Article> Articles { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeder = new Seed();

            // seed CarMakes
            var carMakes = seeder.GetInitialCarMakesValues();

            foreach (var item in carMakes)
            {
                modelBuilder.Entity<CarMake>().HasData(item);
            }

            // seed CarModels
            var carModels = seeder.GetInitialCarModelsValues();

            foreach (var item in carModels)
            {
                modelBuilder.Entity<CarModel>().HasData(item);
            }

            // seed Categories
            var categories = seeder.GetInitialCategoriesValues();

            foreach (var item in categories)
            {
                modelBuilder.Entity<Category>().HasData(item);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
