using System;

namespace NepConfess.Models
{
    public class AForum
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;
        public int Votes { get; set; }
        public QForum QForum { get; set; }
        public int QForumId { get; set; }
    }
}