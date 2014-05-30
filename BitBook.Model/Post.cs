using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBook.Model
{
    public class Post
    {
        public ObjectId _id { get; set; }
        public UserBasic PostedBy { get; set; }
        public DateTime PostDate { get; set; }
        public List<UserBasic> Likers { get; set; }
        public int LikeCount { get; set; }
        public Post()
        {
            this.Likers = new List<UserBasic>();
            this.PostedBy = new UserBasic();
        }
    }
}
