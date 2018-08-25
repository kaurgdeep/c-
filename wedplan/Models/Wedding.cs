using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using wedplan.Models;

namespace wedplan
{
    public class Wedding : BaseEntity
    {
         [Key]            
            public int WeddingId {get;set;}
            [Required(ErrorMessage = "invalid wedder")]
            [MinLength(2)]
            public string WedderOne {get; set;}

            [Required(ErrorMessage = "invalid wedder")]
            [MinLength(2)]
            public string WedderTwo {get; set;}

            // [Required(ErrorMessage = "invalid Date")]
           
            public DateTime Date {get; set;}

            [Required(ErrorMessage = "invalid Address")]
            [MinLength(8)]
            public string Address {get; set;}

            public int UserId {get; set;}

            public User user {get; set;} 
            
            public List<Guest> Guests {get;set;}

            public Wedding()
            {
               
                Guests = new List<Guest>();
            }
        
       
    }
}