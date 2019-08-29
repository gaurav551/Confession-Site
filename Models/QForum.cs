using System;
using System.Collections.Generic;

namespace NepConfess.Models
{
    public class QForum
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string UserName { get; set; }
        
        public string Tags { get; set; }
        
        public int AForumsId { get; set; }
        


    }
}