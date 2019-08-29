using System;
using Microsoft.AspNetCore.Identity;
using static Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal.ExternalLoginModel;

namespace NepConfess.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Bio { get; set; }
        public string DisplayName { get; set; }
        public string UserId { get; set; } 
        public string UserName { get; set; }
        public string ImageUrl { get; set; }

        //Extra
        public string Phone { get; set; }
        public string  Email { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }

       public string DateOfBirth { get; set; }
      public string Skill { get; set; }

       public DateTime Date { get; set; } = DateTime.Now;
       
    }
}