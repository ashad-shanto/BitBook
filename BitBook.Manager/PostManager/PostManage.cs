using BitBook.Model;
using BitBook.Repository.DataAccess;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBook.Manager.PostManager
{
    public class PostManage
    {
        private readonly PostRepository repo;
        public PostManage()
        {
            repo = new PostRepository();
        }
        public bool CreateTextPost(Post aPost)
        {
            if(string.IsNullOrWhiteSpace(aPost.PostedBy.Username) || string.IsNullOrWhiteSpace(aPost.PostBody))
            {
                return false;
            }
            else
            {
                return repo.Add(aPost);
            }
        }
        public List<Post> GetAllByUserId(ObjectId userId)
        {
            List<Post> allPost = new List<Post>();
            try
            {
                allPost = repo.GetAllByUserId(userId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching post" + ex);
            }
            return allPost;
        }
        public bool LikePost(ObjectId postId, ObjectId likerId)
        {
            try
            {
                return repo.LikePost(postId, likerId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in like post" + ex);
            }
            return false;
        }
        public bool RemovePost(ObjectId postId)
        {
            try
            {
                return repo.RemovePost(postId);
            }
            catch(Exception ex)
            {
                throw new Exception("Error removing post" + ex);
            }
        }
    }
}
