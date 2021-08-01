using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context nesnesi Database tabloları ile proje classlarını bağladığımız class ın ta kendisi
    public class NorthwindContext: DbContext //Entityframework kurunca onla beraber böyle base bir sınıf geliyor.
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Bu method senin projen hangi veri tabanı ile ilişkili onu belirticeğin yer. 
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }  //Ben veri tabanımın ne olduğunu söyledim ama benim hangi nesnem hangi nesneye karşılık gelecek
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
