using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRating.DTO
{
    public class MovieDTO  : BaseDTO
    {
        public decimal MovieID { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int AverageRating { get; set; }
    }
}

