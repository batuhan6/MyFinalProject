using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic constraint
    //class: referans tip olabilir demek int falan olamaz yani
    //T ya IEntity olabilir yada IEntity den implemente edilen birşey olabilir - Category,Customer,Product
    //new()  newlwnwbilir olmalı IEntity abstract class onu elemek için yaptık sadece implemente class larını çağırmak istiyoruz onu değil 
    public interface IEntityRepository<T> where T:class,IEntity,new()  //Generic repository design pattern
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);   
        //Expression filtre liye bilmemizi sağlıyor. Bütün herşeyi değilde seçtiklerimizi çağırıyoruz. Delege deniyor buna.
        //filter=null   filtre vermiyede bilirsin demek.
        T Get(Expression<Func<T, bool>> filter); //Bize T döndüren get operasyonu, filtre vermek zorunlu
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
  
    }
}
