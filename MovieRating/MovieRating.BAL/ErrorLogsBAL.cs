using System;
using System.Collections.Generic;
using MovieRating.DAL;
using MovieRating.DTO;

namespace MovieRating.BAL
{
    public sealed class ErrorLogsBAL
    {

        internal ErrorLogsBAL() { }

        /// <summary>
        ///  Insert ErrorLogs
        /// </summary>
        /// <param name="objErrorLogsDTO">ErrorLogs</param>
        /// <returns>ErrorLogs</returns>
        public ErrorLogsDTO InsertErrorLogs(Exception objException)
        {
            return DALFactory.Instance.ErrorLogsDAL.InsertErrorLogs(objException);
        } 
    }
}

