using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DocumentImageCapture
{
    internal class DataProvider : SqlClient
    {
        public DataProvider() { }

        public DataProvider(string connstr) : base(connstr) { }

        public static string ToXml(object serilizeObject)
        {
            if (object.ReferenceEquals(serilizeObject, null)) return string.Empty;
            var xmlstring = "";

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(serilizeObject.GetType());
                using (var sww = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww))
                    {
                        xmlSerializer.Serialize(writer, serilizeObject);
                        xmlstring = sww.ToString();
                    }
                }
            }
            catch (Exception exc)
            {
                Utility.Hata(exc.Message);
            }

            return xmlstring;
        }

        public static object FromXml(string xmlstr, Type type)
        {
            if (string.IsNullOrEmpty(xmlstr)) return null;

            try
            {
                XmlSerializer deserializer = new XmlSerializer(type);
                StringReader streamreader = new StringReader(xmlstr);
                XmlReader xmlreader = new XmlTextReader(streamreader);
                if (deserializer.CanDeserialize(xmlreader))
                {
                    return deserializer.Deserialize(xmlreader);
                }
            }
            catch (Exception exc)
            {
                Utility.Hata(exc.Message);
            }

            return null;
        }

        public static void SaveObj(string filename, object obj)
        {
            try
            {
                string fullName = string.Format("{0}\\{1}", Application.StartupPath, filename);
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(fullName, FileMode.Create, FileAccess.Write))
                {
                    formatter.Serialize(stream, obj);
                    stream.Close();
                }
            }
            catch (Exception exc)
            {
                Utility.Hata(exc);
            }
        }

        public static object ReadObj(string filename)
        {
            try
            {

                string fullName = string.Format("{0}\\{1}", Application.StartupPath, filename);

                if (File.Exists(fullName))
                {
                    IFormatter formatter = new BinaryFormatter();
                    using (FileStream stream = new FileStream(fullName, FileMode.Open, FileAccess.Read))
                    {
                        return formatter.Deserialize(stream);
                    }
                }
            }
            catch (Exception exc)
            {
                Utility.Hata(exc.Message);
            }
            finally
            {
            }
            return null;
        }

        public void SaveFile(string filename, string data)
        {
            try
            {
                string fullName = string.Format("{0}\\{1}", Application.StartupPath, filename);

                using (FileStream file = new FileStream(fullName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                using (StreamWriter write = new StreamWriter(file, Encoding.GetEncoding("windows-1254")))
                {
                    write.WriteLine(data);
                    write.Flush();
                    write.Close();
                    file.Close();
                }
            }
            catch (Exception exc)
            {
                Utility.Hata(exc.Message);
            }
            finally
            {
            }
        }

        public string ReadFile(string filename)
        {
            string data = null;
            try
            {

                string fullName = string.Format("{0}\\{1}", Application.StartupPath, filename);

                if (File.Exists(fullName))
                {
                    using (FileStream file = new FileStream(fullName, FileMode.Open, FileAccess.Read))
                    using (StreamReader reader = new StreamReader(file, Encoding.Default))
                    {
                        data = reader.ReadToEnd();
                        reader.Close();
                        file.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                Utility.Hata(exc.Message);
            }
            finally
            {
            }
            return data;
        }

        public byte[] GetFileByte(string filename)
        {
            byte[] fileByes = null;
            try
            {
                if (File.Exists(filename))
                {
                    using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = new BinaryReader(stream))
                        {
                            fileByes = reader.ReadBytes((int)stream.Length);
                            reader.Close();
                        }
                        stream.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                Utility.Hata(exc.Message);
            }
            finally
            {
            }
            return fileByes;
        }

        public long CheckSeq(string date)
        {
            string[] dates = date.Split('_');
            object seqobj = ExecuteScalar(string.Format(Kamera.SELECT_STRING, string.Concat(dates[0], "-", dates[1], "-", dates[2], " ", dates[3], ":", dates[4])));
            if (seqobj != null)
            {
                return Convert.ToInt64(seqobj);
            }
            return 0;
        }

        public void CheckField()
        {
            try
            {
                Execute("IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WITH (NOLOCK) WHERE TABLE_NAME = N'Weigh2' AND COLUMN_NAME = N'DocImage') BEGIN ALTER TABLE dbo.Weigh2 ADD DocImage IMAGE NULL END");
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
        }

    }
}
