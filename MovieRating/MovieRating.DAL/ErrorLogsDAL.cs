using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using MovieRating.DTO;

namespace MovieRating.DAL
{
    public sealed class ErrorLogsDAL
    {

        IDBManager dbManager = new DBManager();

        internal ErrorLogsDAL() { }

        /// <summary>
        ///  Insert ErrorLogs
        /// </summary>
        /// <param name="objErrorLogs">ErrorLogs</param>
        /// <returns>ErrorLogs</returns>
        public ErrorLogsDTO InsertErrorLogs(Exception objException)
        {
            ErrorLogsDTO objErrorLogsDTO = new ErrorLogsDTO();
            if (objException != null)
            {
                System.Net.IPHostEntry ipHostInfo = Dns.GetHostEntry(System.Net.Dns.GetHostName());
                if (ipHostInfo != null)
                {
                    if (ipHostInfo.AddressList != null && ipHostInfo.AddressList.Length > 0)
                    {
                        IPAddress ipAddress = ipHostInfo.AddressList[0];
                        if (ipAddress != null)
                            objErrorLogsDTO.ServerID = Convert.ToString(ipAddress.AddressFamily);
                    }
                }

                objErrorLogsDTO.TimeStamp = DateTime.Now;
                objErrorLogsDTO.ApplicationCode = "MovieRating";
                objErrorLogsDTO.Host = System.Net.Dns.GetHostName();
                objErrorLogsDTO.ErrorType = string.Empty;
                objErrorLogsDTO.ErrorMessage = objException.Message;
                objErrorLogsDTO.StackTrace = objException.StackTrace;
                objErrorLogsDTO.ErrorAdditionalInformation = string.Empty;
                objErrorLogsDTO.ErrorInnerException = objException.InnerException != null
                            ? objException.InnerException.Message : string.Empty;

            }
            try
            {
                dbManager.Open();
                dbManager.DeleteAllParameters();
                dbManager.CreateParameters(5);

                if (objErrorLogsDTO.TimeStamp > System.DateTime.MinValue)
                    dbManager.AddParameters(0, "@Time_Stamp", objErrorLogsDTO.TimeStamp);
                else
                    dbManager.AddParameters(0, "@Time_Stamp", null);

                dbManager.AddParameters(1, "@Application_Code", !string.IsNullOrWhiteSpace(objErrorLogsDTO.ApplicationCode) ? objErrorLogsDTO.ApplicationCode.Trim() : null);
                dbManager.AddParameters(2, "@Host", !string.IsNullOrWhiteSpace(objErrorLogsDTO.Host) ? objErrorLogsDTO.Host.Trim() : null);
                dbManager.AddParameters(3, "@Error_Type", !string.IsNullOrWhiteSpace(objErrorLogsDTO.ErrorType) ? objErrorLogsDTO.ErrorType.Trim() : null);
                dbManager.AddParameters(4, "@Error_Message", !string.IsNullOrWhiteSpace(objErrorLogsDTO.ErrorMessage) ? objErrorLogsDTO.ErrorMessage.Trim() : null);
                dbManager.AddParameters(5, "@Stack_Trace", !string.IsNullOrWhiteSpace(objErrorLogsDTO.StackTrace) ? objErrorLogsDTO.StackTrace.Trim() : null);
                dbManager.AddParameters(6, "@Server_ID", !string.IsNullOrWhiteSpace(objErrorLogsDTO.ServerID) ? objErrorLogsDTO.ServerID.Trim() : null);
                dbManager.AddParameters(7, "@Error_Additional_Information", !string.IsNullOrWhiteSpace(objErrorLogsDTO.ErrorAdditionalInformation) ? objErrorLogsDTO.ErrorAdditionalInformation.Trim() : null);
                dbManager.AddParameters(8, "@Error_Inner_Exception", !string.IsNullOrWhiteSpace(objErrorLogsDTO.ErrorInnerException) ? objErrorLogsDTO.ErrorInnerException.Trim() : null);
                dbManager.ExecuteReader(CommandType.StoredProcedure, "usp_InsertErrorLogs");
                while (dbManager.DataReader.Read())
                {
                }
            }
            catch (Exception exception)
            {
                exception = null;
            }
            finally
            {
                dbManager.CloseReader();
                dbManager.Dispose();
            }
            return objErrorLogsDTO;
        }

    }
}

