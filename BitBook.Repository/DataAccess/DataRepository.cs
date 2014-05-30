using BitBook.Repository.Concrete;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBook.Repository.DataAccess
{
    public class DataRepository<T> : DbContext, IRepository<T> where T : class
    {
        public MongoCollection<T> Collection { get; private set; }
        private DbContext MyProperty { get; set; }
        public DataRepository()
        {
            Collection = db.GetCollection<T>(typeof(T).Name.ToLower());
        }

        public IList<T> GetAll()
        {

            List<T> all = new List<T>();
            try
            {
                all = Collection.FindAll().ToList();
                return all;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public bool Add(T entity)
        {

            try
            {
                Collection.Insert(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public void UpdateEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ObjectId id)
        {
            throw new NotImplementedException();
        }

    }
}
