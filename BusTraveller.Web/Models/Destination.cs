using System.ComponentModel.DataAnnotations;

namespace BusTraveller.Web.Models
{
    public class Destination
    {
       // [Key]
        public int Id { get; set; }

        
        public string Title { get; set; }

        
        public string Location { get; set; }

    

        public double Rating { get; set; }


        public string ImageUrl { get; set; }


    }
}
