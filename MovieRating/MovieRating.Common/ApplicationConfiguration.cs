using System;
namespace MovieRating.Common
{
    public class ApplicationConfiguration
    { 
        public string ConnectionString { get; set; }
        public string GetDontaionUniqueID { get { return Guid.NewGuid().ToString(); } }
    }
}
