using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BitBook.Model
{
    public class Notification
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public ObjectId NotificationFor { get; set; }
        public int Status { get; set; }
        public UserBasic Friend { get; set; }
    }
}
