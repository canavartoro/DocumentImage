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
        OracleTransaction transaction = null;
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

        //public int GetWaybilId(PdfFileInfo fileInf)
        //{
        //    try
        //    {
        //        //AL JAWAD N°0028440.pdf
        //        int waybilId = 0;
        //        object objIds = null;
        //        if (!fileInf.IsManuel)
        //        {
        //            string docNo = Path.GetFileNameWithoutExtension(fileInf.FullName);
        //            if (docNo.IndexOf('-') != -1)
        //            {
        //                docNo = docNo.Substring(0, docNo.IndexOf('-'));
        //            }

        //            objIds = ExecuteScalar(string.Format("SELECT INVOICE_M_ID FROM UYUMSOFT.PSMT_INVOICE_M WHERE {0} = :NOTEFIELD AND ROWNUM = 1", AppSettingHelper.Default.orafieldname),
        //          new OracleParameter[] {
        //                new OracleParameter(":NOTEFIELD", docNo)
        //          });

        //            if (objIds != null && object.ReferenceEquals(objIds, DBNull.Value) == false)
        //            {
        //                waybilId = Convert.ToInt32(objIds);
        //            }
        //        }
        //        else if (fileInf.Name.IndexOf("°") == -1)
        //        {
        //            objIds = ExecuteScalar(string.Format("SELECT INVOICE_M_ID FROM UYUMSOFT.PSMT_INVOICE_M WHERE {0} = :NOTEFIELD AND CO_ID = :CO_ID AND BRANCH_ID = :BRANCH_ID AND PURCHASE_SALES = :PURCHASE_SALES AND ROWNUM = 1", AppSettingHelper.Default.orafieldname),
        //            new OracleParameter[] {
        //                new OracleParameter(":NOTEFIELD", Path.GetFileNameWithoutExtension(fileInf.FullName)),
        //                new OracleParameter(":CO_ID", AppSettingHelper.Default.coid),
        //                new OracleParameter(":BRANCH_ID", AppSettingHelper.Default.branchid),
        //                new OracleParameter(":PURCHASE_SALES", AppSettingHelper.Default.purchase_sales + 1)
        //            });

        //            if (objIds != null && object.ReferenceEquals(objIds, DBNull.Value) == false)
        //            {
        //                waybilId = Convert.ToInt32(objIds);
        //            }
        //        }
        //        else
        //        {
        //            string docno = Path.GetFileNameWithoutExtension(fileInf.FullName);
        //            docno = docno.Substring(docno.IndexOf("°") + 1);
        //            objIds = ExecuteScalar(string.Format("SELECT INVOICE_M_ID FROM UYUMSOFT.PSMT_INVOICE_M WHERE DOC_NO = :DOC_NO AND CO_ID = :CO_ID AND BRANCH_ID = :BRANCH_ID AND PURCHASE_SALES = :PURCHASE_SALES AND ROWNUM = 1", AppSettingHelper.Default.orafieldname),
        //            new OracleParameter[] {
        //                new OracleParameter(":DOC_NO", docno),
        //                new OracleParameter(":CO_ID", AppSettingHelper.Default.coid),
        //                new OracleParameter(":BRANCH_ID", AppSettingHelper.Default.branchid),
        //                new OracleParameter(":PURCHASE_SALES", AppSettingHelper.Default.purchase_sales + 1)
        //            });

        //            if (objIds != null && object.ReferenceEquals(objIds, DBNull.Value) == false)
        //            {
        //                waybilId = Convert.ToInt32(objIds);
        //            }
        //        }


        //        return waybilId;
        //    }
        //    catch (Exception exception)
        //    {
        //        Logger.E(string.Concat("Yeni kayıt eklenemedi! Message:" + exception.Message, ",StackTrace:", exception.StackTrace));
        //        return 0;
        //    }
        //}

        //public int InsertRecord(PdfFileInfo fileInf)
        //{
        //    try
        //    {
        //        int uploadFileId = 1;

        //        if (ExecuteScalar("SELECT UPLOAD_FILE_ID FROM GNLD_UPLOAD_FILE WHERE RELATION_OBJECT = :RELATION_OBJECT AND RELATION_ID = :RELATION_ID AND SH0RT_FILE_NAME = :SH0RT_FILE_NAME AND ROWNUM = 1",
        //            new OracleParameter[]{
        //                new OracleParameter(":RELATION_OBJECT",fileInf.RelationObject),
        //                new OracleParameter(":RELATION_ID",fileInf.RelationId),
        //                new OracleParameter(":SH0RT_FILE_NAME",fileInf.Name)
        //            }) != null)
        //        {
        //            return -1;
        //        }

        //        object objIds = ExecuteScalar("select last_number \"id\" from user_sequences where sequence_name = 'UPLOAD_FILE_ID_GNLD_UPLOAD_FI'", null);

        //        if (objIds != null && object.ReferenceEquals(objIds, DBNull.Value) == false)
        //        {
        //            uploadFileId = Convert.ToInt32(objIds) + 1;
        //        }

        //        string commandText = "INSERT INTO GNLD_UPLOAD_FILE (UPLOAD_FILE_ID, RELATION_OBJECT, RELATION_ID, SH0RT_FILE_NAME, LONG_FILE_NAME, DOCUMENT_TYPE, DESCRIPTION, CREATE_DATE, CREATE_USER_ID) VALUES (:UPLOAD_FILE_ID, :RELATION_OBJECT, :RELATION_ID, :SH0RT_FILE_NAME, :LONG_FILE_NAME, :DOCUMENT_TYPE, :DESCRIPTION, :CREATE_DATE, :CREATE_USER_ID)";
        //        OracleParameter[] oraParameters = new OracleParameter[9];
        //        oraParameters[0] = new OracleParameter(":UPLOAD_FILE_ID", uploadFileId);
        //        oraParameters[1] = new OracleParameter(":RELATION_OBJECT", fileInf.RelationObject);
        //        oraParameters[2] = new OracleParameter(":RELATION_ID", fileInf.RelationId);
        //        oraParameters[3] = new OracleParameter(":SH0RT_FILE_NAME", fileInf.Name);
        //        oraParameters[4] = new OracleParameter(":LONG_FILE_NAME", fileInf.Name);
        //        oraParameters[5] = new OracleParameter(":DOCUMENT_TYPE", StaticsVariable.DOCUMENT_TYPE);
        //        oraParameters[6] = new OracleParameter(":DESCRIPTION", StaticsVariable.DESCRIPTION);
        //        oraParameters[7] = new OracleParameter(":CREATE_DATE", DateTime.Now);
        //        oraParameters[8] = new OracleParameter(":CREATE_USER_ID", AppSettingHelper.Default.userid);

        //        if (Execute(commandText, oraParameters))
        //        {
        //            OracleParameter[] selParameters = new OracleParameter[2];
        //            selParameters[0] = new OracleParameter(":UPLOAD_FILE_ID", uploadFileId);
        //            selParameters[1] = new OracleParameter(":SH0RT_FILE_NAME", fileInf.Name);
        //            objIds = ExecuteScalar("SELECT UPLOAD_FILE_ID FROM GNLD_UPLOAD_FILE WHERE UPLOAD_FILE_ID = :UPLOAD_FILE_ID OR SH0RT_FILE_NAME = :SH0RT_FILE_NAME", selParameters);

        //            if (objIds != null && object.ReferenceEquals(objIds, DBNull.Value) == false)
        //            {
        //                return Convert.ToInt32(objIds);
        //            }

        //            return uploadFileId;
        //        }
        //        else
        //        {
        //            return -1;
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        Logger.E(string.Concat("Yeni kayıt eklenemedi! Message:" + exception.Message, ",StackTrace:", exception.StackTrace));
        //        return -2;
        //    }
        //}

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
