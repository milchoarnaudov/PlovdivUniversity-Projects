using AutoParts4Sale.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts4Sale.Data
{
    public class AutoParts4SaleDbContexts : IdentityDbContext<IdentityUser>
    {
        public AutoParts4SaleDbContexts(DbContextOptions<AutoParts4SaleDbContexts> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<Autopart> Autoparts { get; set; }
    }
}
