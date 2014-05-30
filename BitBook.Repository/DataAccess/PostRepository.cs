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
    public class PostRepository : DataRepository<Post>, IPost
    {
        public List<Post> GetAllByUserId(ObjectId userId)
        {
            List<Post> allPost = new List<Post>();
            try
            {
                var query = Query<Post>.EQ(e => e.PostedBy._id, userId);
                allPost = Collection.FindAs<Post>(query).ToList();
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error fetching post" + ex);
            }
            return allPost;
        }
    }
}
