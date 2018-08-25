using System;

namespace dojo_survey_model.Models
{
//     public class Ninja
// //     {
// //      public string name {get;set;}
// //      public string location {get;set;}
// //      public string language {get;set;}
// //      public string comment {get;set;}
// //     }

    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}