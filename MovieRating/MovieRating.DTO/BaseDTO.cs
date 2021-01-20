using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRating.DTO
{
    public class BaseDTO
    {
        public int? Status { get; set; }
        public decimal? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
 
    }
}

