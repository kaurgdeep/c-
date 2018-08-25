using System;
using System.ComponentModel.DataAnnotations;

namespace LoginRegDemo
{
    public class Event
    {
        [Key]
        public int EventId {get; set;}

        [RegularExpression("^[a-zA-Z]+$")]
        [Required(ErrorMessage   = "Must have a title")]
        // [MinLength(2)]
        public string Title {get; set;}
        
        // [Required(ErrorMessage = "Must have a date")]
        public DateTime Date{get; set;}


        // [Required(ErrorMessage = "Must have time")]
        public TimeSpan Time {get; set;}


        [Required(ErrorMessage = "You don't leave your front door unlocked do you? Or maybe you just don't own one.")]
        // [MinLength(1)]
        public int DurationInt {get; set;}


        [Required(ErrorMessage = "Duration Required")]
        public string DurationStr {get; set;}

        [Required(ErrorMessage = "Duration Required")]
        // [MinLength(10)]
        public string Description {get; set;}

        public int UserId {get; set;}
        
        public User user {get; set;}
        

    }
}

