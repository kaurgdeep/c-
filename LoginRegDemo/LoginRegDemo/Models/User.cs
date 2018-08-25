using System.ComponentModel.DataAnnotations;

namespace LoginRegDemo.Models
{
    public class User
    {

        [Key]
        public int UserId {get; set;}


        [Required(ErrorMessage   = "Must have first name")]
        [MinLength(2)]
        public string FirstName {get; set;}
        
        
        [Required(ErrorMessage = "Must have last name")]
        [MinLength(2)]
        public string LastName {get; set;}


        [MinLength(2)]
        [Required(ErrorMessage = "Must have email")]
        [RegularExpression("^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+.[a-zA-Z]+$")]
        public string Email {get; set;}


        [Required(ErrorMessage = "Must have must have password")]
        [MinLength(8)]
        public string Password {get; set;}

        // This will throw an error when you guys try to access it, because in the actual MySQL Database, this input doesnt exists.
        // public int AccountId {get; set;}

       // public Account account {get; set;}
        
    }
}

