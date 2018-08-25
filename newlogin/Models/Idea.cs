using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using newlogin.Models;

namespace newlogin
{
    public class Idea
    {
        [Key]
        public int IdeaId {get; set;}

        public string Post {get; set;}
        
        [ForeignKey("User")]
        public int UserId {get; set;}
        
        public User User {get; set;}
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public List<Like> peopleslike {get; set;}

        public Idea()
        {
            peopleslike = new List<Like>();
        }


       

            
      

    }
}