using System;

namespace RESTauranter.Models
{
    public class review
    {
        public int reviewId { get; set; }
        public string reviewername { get; set; }
        public string restaurantname { get; set; }
        public string reviews { get; set; }
        public int star { get; set; }
        public DateTime date{ get; set; }


    public review()
    {
        date = DateTime.Now;
        // ToString("mm/dd/yyyy");
    }

    }
}
