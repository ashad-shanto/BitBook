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
        public bool LikePost(ObjectId postId, ObjectId likerId)
        {
            bool done = false;
            UserBasic liker = new UserBasic() {_id = likerId };
            try
            {
                var query = Collection.Update(Query<Post>.EQ(u => u._id, postId), Update<Post>.AddToSet(u => u.Likers, liker)
                                                                                              .Inc(u => u.LikeCount, 1));
                done = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in like process" + ex);
            }
            return done;
        }
        public bool RemovePost(ObjectId postId)
        {
            try
            {
                var result = Collection.Remove(Query<Post>.EQ(p => p._id, postId), MongoDB.Driver.RemoveFlags.Single);
                if ((int)result.DocumentsAffected > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error removing post" + ex);
            }
            return false;
        }


        public bool LikePost(ObjectId likerId)
        {
            throw new NotImplementedException();
        }
    }
}
