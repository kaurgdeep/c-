using System.ComponentModel.DataAnnotations;

namespace LoginRegDemo
{
    public class User
    {
        [Key]
        public int UserId {get; set;}

        [RegularExpression("^[a-zA-Z]+$")]
        [Required(ErrorMessage   = "Must have first name")]
        [MinLength(2)]
        public string FirstName {get; set;}
        

        [RegularExpression("^[a-zA-Z]+$")]
        [Required(ErrorMessage = "Must have last name")]
        [MinLength(2)]
        public string LastName {get; set;}


        [MinLength(2)]
        [Required(ErrorMessage = "Must have email")]
        [RegularExpression("^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+.[a-zA-Z]+$")]
        public string Email {get; set;}


        [Required(ErrorMessage = "You don't leave your front door unlocked do you? Or maybe you just don't own one.")]
        [MinLength(8)]
        public string Password {get; set;}

    }
}

