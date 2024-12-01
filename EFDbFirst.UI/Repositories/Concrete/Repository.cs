using EFDbFirst.UI.Model;
using EFDbFirst.UI.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDbFirst.UI.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly NorthwindContext db;

        public Repository()
        {
            db = new NorthwindContext();
            
        }

        public bool Create(T data)
        {
            //T=> Product => db.Product.Add(data);
            db.Set<T>().Add(data);
            return db.SaveChanges()>0;
        }

        public bool Delete(T data)
        {
            db.Set<T>().Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

 


        public bool Update(T data)
        {
            db.Set<T>().Update(data);
            return db.SaveChanges() > 0;
        }

       
    }
}
