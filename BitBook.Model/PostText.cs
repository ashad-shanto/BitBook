﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBook.Model
{
    public class PostText : Post
    {
        [BsonId]
        public string PostBody { get; set; }
    }
        
}
