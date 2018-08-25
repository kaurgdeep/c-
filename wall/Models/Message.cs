using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace wall.Models
{
    public class Message
    {

        public int MessageId { get; set; }
        public string createmessage { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        
        public List<Comment> comments {get; set;}
        public User user {get; set;}
        public int UserId {get; set;}

     public Message()
    {
        comments = new List<Comment>();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
    
    }
}
