using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBook.Repository.Concrete
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
        //T GetById(int id);
        bool Add(T entity);
        void UpdateEntity(T entity);
        void Delete(T entity);
        void Delete(ObjectId id);
        
    }
}
