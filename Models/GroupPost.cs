using System;

namespace NepConfess.Models
{
    public class GroupPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string UserName { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }
    }
}