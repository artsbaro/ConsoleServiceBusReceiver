using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ConsoleServiceBus
{
    public class BlogPost
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int PostId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Link
        {
            get
            {
                return $"";
            }
            set { }
        }
        public string Image { get; set; }
        public string Ingredients { get; set; }
        public string PreparationMode { get; set; }
        public bool SendNotification { get; set; }
    }
}
