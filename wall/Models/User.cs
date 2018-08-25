using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace wall.Models
{
    public class User
    {

        public int UserId { get; set; }
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

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public List<Message> messages { get; set; }
        public List<Comment> comments { get; set; }

     public User()
    {
        messages = new List<Message>();
        comments = new List<Comment>();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
    
    }
}
