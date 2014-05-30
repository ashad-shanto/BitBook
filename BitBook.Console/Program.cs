using BitBook.Model;
using BitBook.Repository.DataAccess;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBook.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            UserRepository repo = new UserRepository();
            //User aUser = repo.GetById(new ObjectId());
            List<User> all = new List<User>();
            all = repo.SearchUserByMatchingName("www");

        }
    }
}
