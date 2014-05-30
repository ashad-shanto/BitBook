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
        public bool CreateTextPost(UserBasic author, string postBody)
        {
            if(string.IsNullOrWhiteSpace(author.Username) || string.IsNullOrWhiteSpace(postBody))
            {
                return false;
            }
            else
            {
                Post aPost = new Post();
                aPost._id = new ObjectId();
                aPost.LikeCount = 0;
                aPost.PostBody = postBody;
                aPost.PostDate = DateTime.Now;
                aPost.PostedBy._id = author._id;
                aPost.PostedBy.ProfilePic = author.ProfilePic;
                aPost.PostedBy.Username = author.Username;
                return repo.Add(aPost);
            }
        }
        public bool CreatePhotoPost(UserBasic author, string photoName, string caption)
        {
            if (string.IsNullOrWhiteSpace(author.Username) || string.IsNullOrWhiteSpace(photoName))
            {
                return false;
            }
            else
            {
                Post aPost = new Post();
                aPost._id = new ObjectId();
                aPost.LikeCount = 0;
                aPost.Caption = caption;
                aPost.PostDate = DateTime.Now;
                aPost.PostedBy._id = author._id;
                aPost.PostedBy.ProfilePic = author.ProfilePic;
                aPost.PostedBy.Username = author.Username;
                aPost.PhotoName = photoName;
                return repo.Add(aPost);
            }
        }
    }
}
