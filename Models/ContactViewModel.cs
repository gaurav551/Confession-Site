using System.ComponentModel.DataAnnotations;

namespace NepConfess.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage="How the fuck you are suppose to send without your shitty name")]
        [MinLength(2,ErrorMessage="Name cannot be less than Two Letter  asshole?"  )]
        public string Name { get; set; }
        [Required(ErrorMessage="Enter Your Email You shitty asshole")]
        [EmailAddress(ErrorMessage="Is This an Email? Specify a real email you shithead")]
        public string Email { get; set; }
        [Required(ErrorMessage="No Message asshole?")]
       
        public string Message { get; set; }
        [Required (ErrorMessage="Why The Fuck Is This")]
        public string  Subject { get; set; }
    }
}