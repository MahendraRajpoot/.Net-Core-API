using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRating.DTO
{
    public class MovieRatingDTO  : BaseDTO
    {
        public decimal MovieRatingID { get; set; }
        public decimal? MovieID { get; set; }
        public int? Rating { get; set; }
        public string Comment { get; set; }
    }
}

