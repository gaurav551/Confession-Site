namespace NepConfess.Models
{
    public class Follower
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FollowId  { get; set; }
        public string FollowerName { get; set; }
    }
}