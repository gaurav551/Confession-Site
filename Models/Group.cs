using System.Collections.Generic;

namespace NepConfess.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
       public string GroupType { get; set; }
       public string GroupDescription { get; set; }
       public string UserId { get; set; }
       public string ImageUrl { get; set; }
       public List<GroupPost> GroupPosts { get; set; }
       public int GroupPostsId { get; set; }
    }
}