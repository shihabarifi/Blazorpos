
using pos.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using POS.Models;

namespace pos.Data
{
   public class posDbContext : DbContext
    {
        public posDbContext(DbContextOptions<posDbContext> options ) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<VwUser>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("VwUsers");
            });

        }
        
        public DbSet<VwUser> VwUsers { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Sales> Sales { get; set; }

        public DbSet<Person> People => Set<Person>();
        public DbSet<Address> Addresses => Set<Address>();

    }
}
