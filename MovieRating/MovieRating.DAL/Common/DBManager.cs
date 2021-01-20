//=============================================
//Author:           Mahendra Singh Rajpoot
//Created Date:	    18-Jan-2021
//Description:      Data base manager implement IDBManager interface
//Modified By:      
//Modified Date:    
//Modified Reason: 
//=============================================
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MovieRating.Common;

namespace MovieRating.DAL
{
    internal sealed class DBManager : IDBManager, IDisposable
    {
        private IDbConnection idbConnection;
        private IDataReader idataReader;
        private IDbCommand idbCommand;
        private IDbTransaction idbTransaction = null;
        private IDbDataParameter[] idbParameters = null;
        private string strConnection;
        //public ApplicationConfiguration Config => AppServicesHelper.ApplicationConfiguration;

        /// <summary>
        /// Constructor 
        /// </summary>
        public DBManager()
        {           
            this.ConnectionString = "Data Source=IMDB_SERVER;Initial Catalog=IMDB;Persist Security Info=False;User ID=chaster;Password=******;";
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        public DBManager(string connectionString)
        {
            this.strConnection = connectionString;
        }
        /// <summary>
        /// Connection
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                return idbConnection;
            }
        }
        /// <summary>
        /// Data reader
        /// </summary>
        public IDataReader DataReader
        {
            get
            {
                return idataReader;
            }
            set
            {
                idataReader = value;
            }
        }
        /// <summary>
        /// Connection string
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return strConnection;
            }
            set
            {
                strConnection = value;
            }
        }
        /// <summary>
        /// Command
        /// </summary>
        public IDbCommand Command
        {
            get
            {
                return idbCommand;
            }
        }
        /// <summary>
        /// Transaction
        /// </summary>
        public IDbTransaction Transaction
        {
            get
            {
                return idbTransaction;
            }
        }
        /// <summary>
        /// Parameters
        /// </summary>
        public IDbDataParameter[] Parameters
        {
            get
            {
                return idbParameters;
            }
        }
        /// <summary>
        /// Open data base connection
        /// </summary>
        public void Open()
        {
            idbConnection =
            DbManagerFactory.GetConnection();
            idbConnection.ConnectionString = this.ConnectionString;
            if (idbConnection.State != ConnectionState.Open)
                idbConnection.Open();
            this.idbCommand = DbManagerFactory.GetCommand();
        }
        /// <summary>
        /// Close data base connection
        /// </summary>
        public void Close()
        {
            if (idbConnection.State != ConnectionState.Closed)
                idbConnection.Close();
        }
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Close();
            this.idbCommand = null;
            this.idbTransaction = null;
            this.idbConnection = null;
        }
        /// <summary>
        /// Create parameters
        /// </summary>
        /// <param name="paramsCount">Number of parameters to be created</param>
        public void CreateParameters(int paramsCount)
        {
            idbParameters = new IDbDataParameter[paramsCount];
            idbParameters = DbManagerFactory.GetParameters(paramsCount);
        }
        /// <summary>
        /// Delete all previous parameters
        /// </summary>
        public void DeleteAllParameters()
        {
            idbParameters = null;
        }
        /// <summary>
        /// Add Parameters
        /// </summary>
        /// <param name="index">Index of parameter</param>
        /// <param name="paramName">Parameter name</param>
        /// <param name="objValue">Parameter value></param>
        public void AddParameters(int index, string paramName, object objValue)
        {
            if (index < idbParameters.Length)
            {
                idbParameters[index].ParameterName = paramName;
                idbParameters[index].Value = objValue;
            }
        }
        /// <summary>
        /// Begin Transaction
        /// </summary>
        public void BeginTransaction()
        {
            if (this.idbTransaction == null)
                idbTransaction =
                DbManagerFactory.GetTransaction();
            this.idbCommand.Transaction = idbTransaction;
        }
        /// <summary>
        /// Commit Transaction
        /// </summary>
        public void CommitTransaction()
        {
            if (this.idbTransaction != null)
                this.idbTransaction.Commit();
            idbTransaction = null;
        }
        /// <summary>
        /// Execute data reader
        /// </summary>
        /// <param name="commandType">Command type</param>
        /// <param name="commandText">Command text</param>
        /// <returns>Data reader</returns>
        public IDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            this.idbCommand = DbManagerFactory.GetCommand();
            idbCommand.Connection = this.Connection;
            PrepareCommand(idbCommand, this.Connection, this.Transaction,
             commandType,
              commandText, this.Parameters);
            this.DataReader = idbCommand.ExecuteReader();
            idbCommand.Parameters.Clear();
            return this.DataReader;
        }

       
        /// <summary>
        /// Close data reader
        /// </summary>
        public void CloseReader()
        {
            if (this.DataReader != null)
                this.DataReader.Close();
        }
        /// <summary>
        /// Attach parameters
        /// </summary>
        /// <param name="command">Command</param>
        /// <param name="commandParameters">Parameters</param>
        private void AttachParameters(IDbCommand command, IDbDataParameter[] commandParameters)
        {
            foreach (IDbDataParameter idbParameter in commandParameters)
            {
                if ((idbParameter.Direction == ParameterDirection.InputOutput)
                &&
                  (idbParameter.Value == null))
                {
                    idbParameter.Value = DBNull.Value;
                }
                command.Parameters.Add(idbParameter);
            }
        }
        /// <summary>
        /// Prepare SQL Command
        /// </summary>
        /// <param name="command">Command</param>
        /// <param name="connection">Connection</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="commandType">Command type</param>
        /// <param name="commandText">Command text</param>
        /// <param name="commandParameters">Parameters</param>
        private void PrepareCommand(IDbCommand command, IDbConnection connection,  IDbTransaction transaction, CommandType commandType, string
     commandText, IDbDataParameter[] commandParameters)
        {
            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (transaction != null)
            {
                command.Transaction = transaction;
            }

            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
        }
        /// <summary>
        /// Execute Non Query
        /// </summary>
        /// <param name="commandType">Command type</param>
        /// <param name="commandText">Command text</param>
        /// <returns>Number of affected rows</returns>
        public int ExecuteNonQuery(CommandType commandType, string  commandText)
        {
            this.idbCommand = DbManagerFactory.GetCommand();
            PrepareCommand(idbCommand, this.Connection, this.Transaction,
            commandType, commandText, this.Parameters);
            int returnValue = idbCommand.ExecuteNonQuery();
            idbCommand.Parameters.Clear();
            return returnValue;
        }
        /// <summary>
        /// Execute scalar
        /// </summary>
        /// <param name="commandType">Command type</param>
        /// <param name="commandText">Command text</param>
        /// <returns>Number of affected rows</returns>
        public object ExecuteScalar(CommandType commandType, string   commandText)
        {
            this.idbCommand = DbManagerFactory.GetCommand();
            PrepareCommand(idbCommand, this.Connection, this.Transaction,
            commandType,
              commandText, this.Parameters);
            object returnValue = idbCommand.ExecuteScalar();
            idbCommand.Parameters.Clear();
            return returnValue;
        }
        /// <summary>
        /// Execute data set
        /// </summary>
        /// <param name="commandType">Command type</param>
        /// <param name="commandText">Command text</param>
        /// <returns>Data set</returns>
        public DataSet ExecuteDataSet(CommandType commandType, string  commandText)
        {
            this.idbCommand = DbManagerFactory.GetCommand();
            PrepareCommand(idbCommand, this.Connection, this.Transaction,
           commandType,
              commandText, this.Parameters);
            IDbDataAdapter dataAdapter = DbManagerFactory.GetDataAdapter();
            dataAdapter.SelectCommand = idbCommand;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            idbCommand.Parameters.Clear();
            return dataSet;
        }

        
    }
}
