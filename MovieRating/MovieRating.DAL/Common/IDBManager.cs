//=============================================
//Author:           Mahendra Singh Rajpoot
//Created Date:	    18-Jan-2021
//Description:      Data base manager interface
//Modified By:      
//Modified Date:    
//Modified Reason: 
//=============================================
using System;
using System.Data;
using System.Data.SqlClient;

namespace MovieRating.DAL
{
    public interface IDBManager
    {
        /// <summary>
        /// Connection String
        /// </summary>
        string ConnectionString
        {
            get;
            set;
        }
        /// <summary>
        /// Connection
        /// </summary>
        IDbConnection Connection
        {
            get;
        }
        /// <summary>
        /// Transaction
        /// </summary>
        IDbTransaction Transaction
        {
            get;
        }
        /// <summary>
        /// Data Reader
        /// </summary>
        IDataReader DataReader
        {
            get;
        }
        /// <summary>
        /// Command
        /// </summary>
        IDbCommand Command
        {
            get;
        }
        /// <summary>
        /// Parameters
        /// </summary> 
        IDbDataParameter[] Parameters
        {
            get;
        }
        /// <summary>
        /// Open Connection
        /// </summary>
        void Open();
        /// <summary>
        /// Begin Transaction
        /// </summary>
        void BeginTransaction();
        /// <summary>
        /// Commit Transaction
        /// </summary>
        void CommitTransaction();
        /// <summary>
        /// Create parameters
        /// </summary>
        /// <param name="paramsCount">Number of parameters to be created</param>
        void CreateParameters(int paramsCount);
        /// <summary>
        /// Add Parameters
        /// </summary>
        /// <param name="index">Index of parameter</param>
        /// <param name="paramName">Parameter name</param>
        /// <param name="objValue">Parameter value></param>
        void AddParameters(int index, string paramName, object objValue);

        /// <summary>
        /// Execute data reader
        /// </summary>
        /// <param name="commandType">Command type</param>
        /// <param name="commandText">Command text</param>
        /// <returns>Data reader</returns>
        IDataReader ExecuteReader(CommandType commandType, string commandText);

  
        /// <summary>
        /// Execute data set
        /// </summary>
        /// <param name="commandType">Command type</param>
        /// <param name="commandText">Command text</param>
        /// <returns>Data set</returns>
        DataSet ExecuteDataSet(CommandType commandType, string commandText);
        /// <summary>
        /// Execute scalar
        /// </summary>
        /// <param name="commandType">Command type</param>
        /// <param name="commandText">Command text</param>
        /// <returns>Number of affected rows</returns>
        object ExecuteScalar(CommandType commandType, string commandText);
        /// <summary>
        /// Execute Non Query
        /// </summary>
        /// <param name="commandType">Command type</param>
        /// <param name="commandText">Command text</param>
        /// <returns>Number of affected rows</returns>
        int ExecuteNonQuery(CommandType commandType, string commandText);
        /// <summary>
        /// Close data reader
        /// </summary>
        void CloseReader();
        /// <summary>
        /// Close connection
        /// </summary>
        void Close();
        /// <summary>
        /// Dispose
        /// </summary>
        void Dispose();
        /// <summary>
        /// Delete all previous parameters
        /// </summary>
        void DeleteAllParameters();
       
    }
}

