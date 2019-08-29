using System;
using System.ComponentModel.DataAnnotations;

namespace NepConfess.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime DaTe { get; set; } = DateTime.Now;
       
        public string CommentText { get; set; }
        public string CommentBy { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        
        public string ProfileDisplayName { get; set; }

    }
}