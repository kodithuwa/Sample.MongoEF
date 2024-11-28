using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.MongoEF.Console
{
    internal class StorageContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        public StorageContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(x =>
            {
                x.ToCollection("products");
                x.Property(x => x.Name).HasElementName("name");
                x.Property(x => x.Description).HasElementName("description");
                x.Property(x => x.Quantity).HasElementName("qulity");
                x.Property(x => x.Id).HasElementName("_id");
                x.HasKey(x => x.Id);
            });
        }
    }
}
