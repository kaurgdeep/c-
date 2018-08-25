using System;
using System.ComponentModel.DataAnnotations;

namespace dojo_survey_valid.Models
{
    public class Ninja
    { 
        [Required]
        [MinLength(3)]
        public string name {get;set;}

        [Required]
        public string location {get;set;}
        [Required]
        public string language {get;set;}

        [Required]
        [StringLength(30, MinimumLength = 2,ErrorMessage = "field must be atleast 8 and less than 30 characters.")]
        public string comment {get;set;}
    }
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}