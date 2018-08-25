using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using newlogin.Models;

namespace newlogin
{
    public class User 
    {
        [Key]
        public int UserId {get; set;}


        [Required(ErrorMessage   = "Must have name")]
        [MinLength(2)]
        public string FirstName {get; set;}
        
        
        [Required(ErrorMessage = "Must have Alias")]
        [MinLength(2)]
        public string LastName {get; set;}


        [MinLength(2)]
        [Required(ErrorMessage = "Must have email")]
        [RegularExpression("^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+.[a-zA-Z]+$")]
        public string Email {get; set;}


        [Required(ErrorMessage = "Must have 8 characters password")]
        [MinLength(8)]
        public string Password {get; set;}

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public List<Idea> userpostidealist { get; set; }

        public List<Like> userlikeidealist { get; set; }


        public User() {
            userpostidealist = new List<Idea>();
            userlikeidealist = new List<Like>();
        }
    }
}