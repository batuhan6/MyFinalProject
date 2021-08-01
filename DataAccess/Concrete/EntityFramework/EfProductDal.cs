using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Nuget - farklı kodların paylaşıldığı ortam
    //biz artık dataAccess in içinde EntityFrameWorkCore Code u yazabiliraz nudgetdan entityframeworkcore.sql yükledik
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposible pattern implementation of C#
            using (NorthwindContext context = new NorthwindContext()) // NorthwindContext işi bitince atılacak. Using bittiği zaman garbage collecter a topla bunları
            {
                var addedEntity = context.Entry(entity);  //referansı yakala
                addedEntity.State = EntityState.Added;    // O aslında eklenecek bir nesne
                context.SaveChanges();  //ve şimdi ekle
            };
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) 
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;   
                context.SaveChanges();  
            };
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            };
        }
    }
}
