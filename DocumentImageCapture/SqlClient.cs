using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DocumentImageCapture
{
    internal class SqlClient : IDisposable
    {
        private SqlCommand command = null;
        private SqlConnection connection = null;
        private string message = "";
        private string sqlString = string.Empty;
        private string connectionString = string.Empty;

        public string Message
        {
            get
            {
                return message;
            }
        }

        public bool IsConnected
        {
            get
            {
                return connection != null && connection.State == System.Data.ConnectionState.Open;
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

        public SqlClient() { }

        public SqlClient(string connstr)
        {
            this.connectionString = connstr;
            Connect();
        }

        public bool Connect()
        {
            try
            {
                if (connection == null)
                {
                    connection = new SqlConnection(connectionString);
                }
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                if (command == null)
                    command = connection.CreateCommand();

                return connection != null && connection.State == System.Data.ConnectionState.Open;
            }
            catch (SqlException sqlexception)
            {
                Logger.E(sqlexception);
                message = sqlexception.Message;
                return false;
            }
            catch (Exception exception)
            {
                Logger.E(exception);
                message = exception.Message;
                return false;
            }
        }

        public void Close()
        {
            try
            {
                if (command != null)
                {
                    if (command.Transaction != null)
                        command.Transaction.Rollback();
                    command.Dispose();
                }

                if (connection != null)
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();

                    connection.Dispose();
                }
            }
            catch (SqlException sqlexception)
            {
                Logger.E(sqlexception);
                message = sqlexception.Message;
            }
            catch (Exception exception)
            {
                Logger.E(exception);
                message = exception.Message;
            }
        }

        public SqlDataReader Select(string commandText, SqlParameter[] parameters)
        {
            sqlString = commandText;
            return Select(parameters);
        }
        public SqlDataReader Select(SqlParameter[] parameters)
        {
            try
            {
                if (!IsConnected && !Connect()) return null;

                command.CommandText = sqlString;

                if (parameters != null)
                {
                    foreach (SqlParameter p in parameters)
                        command.Parameters.Add(p);
                }

                SqlStringLog();

                return command.ExecuteReader();
            }
            catch (SqlException sqlexception)
            {
                Logger.E(sqlexception);
                message = sqlexception.Message;
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
            finally
            {
                command.Parameters.Clear();
            }
            return null;
        }
        public SqlDataReader Select(string commandText)
        {
            SqlParameter[] parameters = null;
            SqlString = commandText;
            return Select(parameters);
        }

        public List<T> Select<T>()
        {
            List<T> list = null;
            try
            {

                if (!IsConnected && !Connect()) return null;

                command.CommandText = sqlString;

                SqlStringLog();

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr != null)
                    {
                        list = new List<T>();
                        Type type = typeof(T);
                        //PropertyInfo[] pInfo = type.GetProperties();
                        DataTable tblschema = dr.GetSchemaTable();
                        while (dr.Read())
                        {
                            T newObject = (T)Activator.CreateInstance(type);
                            for (int column = 0; column < tblschema.Columns.Count; column++)
                            {
                                PropertyInfo property = type.GetProperty(tblschema.Columns[column].ColumnName);
                                if (property != null)
                                {
                                    property.SetValue(newObject, dr.GetValue(column), null);
                                }
                            }
                            list.Add(newObject);
                        }
                    }
                }
            }
            catch (SqlException sqlexception)
            {
                Logger.E(sqlexception);
                message = sqlexception.Message;
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
            finally
            {
                command.Parameters.Clear();
            }
            return list;
        }

        public DataTable FillTable(string commandText, SqlParameter[] parameters)
        {
            sqlString = commandText;
            return FillTable(parameters);
        }
        public DataTable FillTable(SqlParameter[] parameters)
        {
            try
            {
                if (!IsConnected && !Connect()) return null;

                command.CommandText = sqlString;
                if (parameters != null)
                {
                    foreach (SqlParameter p in parameters)
                        command.Parameters.Add(p);
                }

                SqlStringLog();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (SqlException sqlexception)
            {
                Logger.E(sqlexception);
                message = sqlexception.Message;
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
            finally
            {
                command.Parameters.Clear();
            }
            return null;
        }
        public DataTable FillTable(string commandText)
        {
            SqlParameter[] parameters = null;
            sqlString = commandText;
            return FillTable(parameters);
        }
        public DataTable FillTable()
        {
            SqlParameter[] parameters = null;
            return FillTable(parameters);
        }

        public bool Execute(string commandText, SqlParameter[] parameters)
        {
            sqlString = commandText;
            return Execute(parameters);
        }
        public bool Execute(SqlParameter[] parameters)
        {
            try
            {
                if (!IsConnected && !Connect()) return false;

                command.CommandText = sqlString;
                if (parameters != null)
                {
                    foreach (SqlParameter p in parameters)
                        command.Parameters.Add(p);
                }

                SqlStringLog();
                return command.ExecuteNonQuery() > 0;
            }
            catch (SqlException sqlexception)
            {
                Logger.E(sqlexception);
                message = sqlexception.Message;
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
            finally
            {
                command.Parameters.Clear();
            }
            return false;
        }
        public bool Execute(string commandText)
        {
            SqlParameter[] parameters = null;
            sqlString = commandText;
            return Execute(parameters);
        }
        public bool Execute()
        {
            SqlParameter[] parameters = null;
            return Execute(parameters);
        }

        public object ExecuteScalar(string commandText, SqlParameter[] parameters)
        {
            sqlString = commandText;
            return ExecuteScalar(parameters);
        }
        public object ExecuteScalar(SqlParameter[] parameters)
        {
            try
            {
                if (!IsConnected && !Connect()) return null;

                command.Parameters.Clear();
                command.CommandText = sqlString;
                if (parameters != null)
                {
                    foreach (SqlParameter p in parameters)
                        command.Parameters.Add(p);
                }

                SqlStringLog();
                return command.ExecuteScalar();
            }
            catch (SqlException sqlexception)
            {
                Logger.E(sqlexception);
                message = sqlexception.Message;
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
            finally
            {
                command.Parameters.Clear();
            }
            return null;
        }
        public object ExecuteScalar(string commandText)
        {
            sqlString = commandText;
            return ExecuteScalar();
        }
        public object ExecuteScalar()
        {
            SqlParameter[] parameters = null;
            return ExecuteScalar(parameters);
        }

        public int Count(string sql)
        {
            object obj = ExecuteScalar(sql, null);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return -1;
        }

        #region Transaction
        public void Begin()
        {
            try
            {
                if (!IsConnected && !Connect()) return;

                command.Transaction = connection.BeginTransaction();
            }
            catch (SqlException dbexc)
            {
                message = dbexc.Message;
                Logger.E(dbexc);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
        }

        public void Commit()
        {
            try
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Commit();
                }
            }
            catch (SqlException dbexc)
            {
                message = dbexc.Message;
                Logger.E(dbexc);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
        }

        public void Rollback()
        {
            try
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
            }
            catch (SqlException dbexc)
            {
                message = dbexc.Message;
                Logger.E(dbexc);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
        }
        #endregion

        #region Parameters
        public void AddParam(string name, object val)
        {
            try
            {
                if (!IsConnected && !Connect()) return;

                command.Parameters.AddWithValue(name, val);
            }
            catch (SqlException dbexc)
            {
                message = dbexc.Message;
                Logger.E(dbexc);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
        }
        public void AddParam(string name, System.Data.DbType dbType, ParameterDirection direction)
        {
            try
            {
                if (!IsConnected && !Connect()) return;

                command.Parameters.Add(new SqlParameter() { ParameterName = name, DbType = dbType, Direction = direction });

            }
            catch (SqlException dbexc)
            {
                message = dbexc.Message;
                Logger.E(dbexc);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
        }
        public void ClearParameters()
        {
            try
            {
                if (!IsConnected && !Connect()) return;

                command.Parameters.Clear();
            }
            catch (SqlException dbexc)
            {
                message = dbexc.Message;
                Logger.E(dbexc);
            }
            catch (Exception exc)
            {
                message = exc.Message;
                Logger.E(exc);
            }
        }
        #endregion

        public static implicit operator bool(SqlClient sql)
        {
            return sql != null && sql.IsConnected;
        }

        [DebuggerStepThrough()]
        private void SqlStringLog([CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = 0)
        {
            if (command != null)
            {
                if (command.Parameters.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (IDataParameter prm in command.Parameters) sb.AppendFormat("\tName:{0},Value:{1}\t", prm.ParameterName, prm.Value);
                    Logger.I(string.Concat("Command:", command.CommandText, "\tParameters:", sb.ToString(), ", Caller: ", callerName, ", lineNumber : ", lineNumber));
                }
                else
                {
                    Logger.I(string.Concat("Command:", command.CommandText, ", Caller: ", callerName, ", lineNumber : ", lineNumber));

                }
            }

        }

        #region IDisposable
        ~SqlClient()
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
                    connection.Close();
                    connection.Dispose();
                }

                command = null;
                connection = null;
            }

            disposed = true;
        }

        #endregion
    }
}
