using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace wall.Models
{
    public class Comment
    {

        public int CommentId { get; set; }
        public string createcomment { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public User user {get; set;}
        public int UserId {get; set;}
        public Message message {get; set;}
        public int MessageId { get; set;}

     public Comment()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
    
    }
}
