using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBook.Repository
{
    public class DbContext
    {
        public DbContext()
        {
            try
            {

                var con = new MongoConnectionStringBuilder("server=192.168.0.101:40000,192.168.0.103:40000,192.168.0.100:40000;database=bitbook");
                //var con = new MongoConnectionStringBuilder("server=127.0.0.1;database=bitbook");
                //var con = new MongoConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SeekerDB"].ConnectionString);
                var server = MongoServer.Create(con);
                db = server.GetDatabase(con.DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Db connection error" + ex);
            }
        }

        public MongoDatabase db { get; private set; }
    }
}
