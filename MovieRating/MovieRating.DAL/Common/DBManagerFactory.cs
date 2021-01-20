//=============================================
//Author:           Mahendra Singh Rajpoot
//Created Date:	    18-Jan-2021
//Description:      Data base manager factory for SQL data base
//Modified By:      
//Modified Date:    
//Modified Reason: 
//=============================================
using System;
using System.Data;
using System.Data.SqlClient;

namespace MovieRating.DAL
{
    internal sealed class DbManagerFactory
    {
        private DbManagerFactory()
        {
        }
        /// <summary>
        /// Get connection
        /// </summary>
        /// <returns>SQL Connection</returns>
        public static IDbConnection GetConnection()
        {
            IDbConnection iDbConnection = null;
            iDbConnection = new SqlConnection();
            return iDbConnection;
        }
        /// <summary>
        /// Get command
        /// </summary>
        /// <returns>SQL Command</returns>
        public static IDbCommand GetCommand()
        {
            return new SqlCommand();
        }
        /// <summary>
        /// Get adapter
        /// </summary>
        /// <returns>SQL data adapter</returns>
        public static IDbDataAdapter GetDataAdapter()
        {
            return new SqlDataAdapter();
        }
        /// <summary>
        /// Get transaction
        /// </summary>
        /// <returns>SQL transaction</returns>
        public static IDbTransaction GetTransaction()
        {
            var iDbConnection = GetConnection();
            var iDbTransaction = iDbConnection.BeginTransaction();
            return iDbTransaction;
        }
        /// <summary>
        /// Get parameter
        /// </summary>
        /// <returns>SQL parameter</returns>
        public static IDataParameter GetParameter()
        {
            IDataParameter iDataParameter = null;
            iDataParameter = new SqlParameter();
            return iDataParameter;
        }
        /// <summary>
        /// Get parameters
        /// </summary>
        /// <param name="paramsCount">Index of parameter</param>
        /// <returns>SQL parameters</returns>
        public static IDbDataParameter[] GetParameters(int paramsCount)
        {
            var idbParams = new IDbDataParameter[paramsCount];
            for (var i = 0; i < paramsCount; ++i)
            {
                idbParams[i] = new SqlParameter();
            }
            return idbParams;
        }
    }
}
