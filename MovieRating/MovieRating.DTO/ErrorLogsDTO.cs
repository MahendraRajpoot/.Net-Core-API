using System;

namespace MovieRating.DTO
{
    public class ErrorLogsDTO  : BaseDTO
    {
        public decimal ErrorID { get; set; }
 
        public DateTime? TimeStamp { get; set; }
 
        public string ApplicationCode { get; set; }
 
        public string Host { get; set; }
 
        public string ErrorType { get; set; }
 
        public string ErrorMessage { get; set; }
 
        public string StackTrace { get; set; }
 
        public string ServerID { get; set; }
 
        public string ErrorAdditionalInformation { get; set; }
 
        public string ErrorInnerException { get; set; }
 
    }
}

