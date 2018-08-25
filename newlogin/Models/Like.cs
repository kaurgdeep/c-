using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace newlogin.Models
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        // [ForeignKey("User")]
         public int UserId {get; set;}
        public User User {get; set;}

        // [ForeignKey("Idea")]
        public int IdeaId { get; set;}
        public Idea Idea {get; set;}
        
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


    }
}