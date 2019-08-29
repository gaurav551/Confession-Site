using System;
using System.Collections.Generic;

namespace NepConfess.Models
{
    public class Post
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }

        public string Author { get; set; }
        public string Category { get; set; }
        public bool IsChecked { get; set; } = false;
        public DateTime Date { get; set; } = DateTime.Now ;
        
        public List<Comment> Comments { get; set; }
        public int CommentsId { get; set; }
    }
}