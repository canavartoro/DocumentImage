using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using System.Net.Sockets;
using System.IO;

public class TcpCaptureClient
{
    [Microsoft.SqlServer.Server.SqlProcedure()]
    public static void CaptureImage(SqlInt64 recId, SqlString description, SqlString hostname, SqlInt32 port)
    {
        try
        {
            //System.Net.ServicePointManager.Expect100Continue = false;
            using (TcpClient clientSocket = new TcpClient())
            {
                #region ReadFromNetwork
                clientSocket.Connect(hostname.Value, port.Value);
                using (NetworkStream serverStream = clientSocket.GetStream())
                {
                    if (clientSocket != null && serverStream != null && serverStream.CanWrite)
                    {
                        byte[] outStream = Encoding.GetEncoding("Windows-1254").GetBytes(string.Concat("get-image|", recId.Value, "|", description));
                        serverStream.Write(outStream, 0, outStream.Length);
                        serverStream.Flush();
                        serverStream.Close();
                        clientSocket.Close();
                    }
                }
                #endregion
            }
            SqlContext.Pipe.Send("Bitti");
        }
        catch (SocketException socex)
        {
            SqlContext.Pipe.Send(string.Concat("An error occured Message:", socex.Message, ",Trace:", socex.StackTrace));
        }
        catch (IOException ioex)
        {
            SqlContext.Pipe.Send(string.Concat("An error occured Message:", ioex.Message, ",Trace:", ioex.StackTrace));
        }
        catch (SqlException ex)
        {
            SqlContext.Pipe.Send(string.Concat("An error occured Message:", ex.Message, ",Trace:", ex.StackTrace));
        }
    }
}

