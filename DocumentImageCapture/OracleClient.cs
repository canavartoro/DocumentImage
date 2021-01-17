using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentImageCapture
{
    public class OracleClient : IDisposable
    {
        OracleConnection connection = null;
        OracleCommand command = null;
        string connectionString = null;
        string sqlString = string.Empty;
        string errDescription = string.Empty;

        public OracleClient() { }

        public OracleClient(string connstr)
        {
            this.connectionString = connstr;
            Connect();
        }

        public void Connect()
        {
            connection = new OracleConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            command = connection.CreateCommand();
        }

        public bool Execute(string commandText, OracleParameter[] parameters)
        {
            if (!IsConnected) Connect();

            command.Parameters.Clear();
            command.CommandText = commandText;
            if (parameters != null)
                command.Parameters.AddRange(parameters);
            SqlStringLog();
            return command.ExecuteNonQuery() > 0;
        }

        public object ExecuteScalar(string commandText, OracleParameter[] parameters)
        {
            if (!IsConnected) Connect();

            command.Parameters.Clear();
            command.CommandText = commandText;
            if (parameters != null)
                command.Parameters.AddRange(parameters);
            SqlStringLog();
            return command.ExecuteScalar();
        }


        public static implicit operator bool(OracleClient ora)
        {
            return ora != null && ora.connection != null && ora.connection.State == System.Data.ConnectionState.Open;
        }

        public bool IsConnected
        {
            get
            {
                return (connection != null && connection.State == ConnectionState.Open);
            }
        }

        public string SqlString
        {
            get { return sqlString; }
            set { sqlString = value; }
        }

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        private void SqlStringLog()
        {
            if (command != null)
            {
                if (command.Parameters.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (IDataParameter prm in command.Parameters) sb.AppendFormat("\tName:{0},Value:{1}\t", prm.ParameterName, prm.Value);
                    Logger.I(string.Concat("Command:", command.CommandText, "\tParameters:", sb.ToString()));
                }
                else
                {
                    Logger.I(string.Concat("Command:", command.CommandText));

                }
            }

        }

        #region IDisposable
        ~OracleClient()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (command != null)
                {
                    command.Dispose();
                }
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open) connection.Close();
                    connection.Dispose();
                }
                connection = null;
                command = null;
            }

            disposed = true;
        }
        #endregion
    }
}
