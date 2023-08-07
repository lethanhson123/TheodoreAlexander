using System;
namespace TA.Data2021.Models
{
    public class Instagram
    {
        public string ID { get; set; }
        public string Code { get; set; }
        public string URL { get; set; }
        public string Title { get; set; }
        public string URLTitle { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string DatePostString { get; set; }
        public string DatePostSub { get; set; }
        public DateTime? DatePost { get; set; }
        public string URLImage { get; set; }
        public string URLImageAPI { get; set; }
        public string LikeCount { get; set; }
        public string CommentCount { get; set; }        
    }
}

