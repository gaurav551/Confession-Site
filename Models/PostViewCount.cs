namespace NepConfess.Models
{
    public class PostViewCount
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}