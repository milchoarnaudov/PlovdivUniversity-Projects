using AutoParts4Sale.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts4Sale.Data
{
    public class AutoParts4SaleDbContexts : DbContext
    {
        public AutoParts4SaleDbContexts(DbContextOptions<AutoParts4SaleDbContexts> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        //public DbSet<Car> Cars { get; set; }
        //public DbSet<ModelCar> ModelsCars { get; set; }
        public DbSet<Autopart> Autoparts { get; set; }
    }
}
