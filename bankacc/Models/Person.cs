using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankacc.Models
{
    public class Person
    {

        public int PersonId { get; set; }
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage =  "Last Name must be atleast 2 characters" )]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\\.[a-zA-Z]+$", ErrorMessage =  "Please Enter Valid Email" )]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage =  "Password must be atleast 8 characters" )]
        public string Password { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage =  "Password must be same" )]
        public string confirmpass { get; set; }

        [ForeignKey("Account")]
        public int AccountId2 { get; set;}
        public Account Account { get; set;}
    }
}
