using BitBook.Model;
using BitBook.Repository.Concrete;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBook.Repository.DataAccess
{
    public class UserRepository : DataRepository<User> , IUserRepository
    {
        public User UserLogin(string userName, string userPass)
        {
            User aUser = new User();
            try
            {
                var query = Query.And(
                      Query<User>.EQ(e => e.UserName, userName),
                      Query<User>.EQ(e => e.Password, userPass)
                  );
                aUser = Collection.FindAs<User>(query).Single();
            }
            catch (Exception ex)
            {

                throw new Exception("Login error" + ex);
            }
            return aUser;
        }


        public User GetById(ObjectId id)
        {
            User aUser = new User();
            try
            {
                var query = Query<User>.EQ(e => e._id, id);
                aUser = Collection.FindOne(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching user data" + ex);
            }
            return aUser;
        }
    }
}
