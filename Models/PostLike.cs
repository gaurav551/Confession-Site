namespace NepConfess.Models
{
    public class PostLike
    {
        public int Id { get; set; }
       
        public int Like { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}