using BitBook.Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBook.Repository.Concrete
{
    public interface IPost
    {
        List<Post> GetAllByUserId(ObjectId userId);
        bool LikePost(ObjectId postId, ObjectId likerId);
        bool RemovePost(ObjectId postId);
    }
}
