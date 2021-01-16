using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DocumentImageCapture
{
    public class AppSettingHelper
    {
        static AppSettingHelper defaultSetting = null;
        public static AppSettingHelper Default
        {
            get
            {
                if (defaultSetting == null) defaultSetting = new AppSettingHelper();
                return defaultSetting;
            }
        }

        public string GetSqlConnectionString()
        {
            return string.Format("data source={0};persist security info=False;initial catalog={1};Connect Timeout=50;User={2};Password={3};", this.SqlServer, this.Database, this.DbUser, this.DbPassword);
        }

        const string SETTING_FILE_NAME = "config.dat";

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private void WriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, string.Concat(System.Windows.Forms.Application.StartupPath, "\\config.dat"));
        }

        private string ReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, string.Concat(System.Windows.Forms.Application.StartupPath, "\\", SETTING_FILE_NAME));
            return temp.ToString();

        }

        private string ReadValue(string Section, string Key, string dvalue)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, string.Concat(System.Windows.Forms.Application.StartupPath, "\\", SETTING_FILE_NAME));
            if (i == 0)
            {
                WriteValue(Section, Key, dvalue);
                return dvalue;
            }
            return temp.ToString();

        }

        public string SqlServer
        {
            get
            {
                return ReadValue("DATA", "SQL-SERVER", "");
            }
            set
            {
                WriteValue("DATA", "SQL-SERVER", value);
            }
        }

        public string Database
        {
            get
            {
                return ReadValue("DATA", "SQL-DB", "");
            }
            set
            {
                WriteValue("DATA", "SQL-DB", value);
            }
        }

        public string DbUser
        {
            get
            {
                return ReadValue("DATA", "SQL-USER", "");
            }
            set
            {
                WriteValue("DATA", "SQL-USER", value);
            }
        }

        public string DbPassword
        {
            get
            {
                return Decrypt(ReadValue("DATA", "SQL-PASSWORD", ""));
            }
            set
            {
                WriteValue("DATA", "SQL-PASSWORD", Encrypt(value));
            }
        }

        public int TimeOut
        {
            get
            {
                return Convert.ToInt32(ReadValue("APP", "TIMEOUT", "10"), CultureInfo.CreateSpecificCulture("en-US"));
            }
            set
            {
                WriteValue("APP", "TIMEOUT", value.ToString(CultureInfo.CreateSpecificCulture("en-US")));
            }
        }

        public global::System.Diagnostics.TraceLevel TraceLavel
        {
            get
            {
                global::System.Diagnostics.TraceLevel level = System.Diagnostics.TraceLevel.Verbose;
                Enum.TryParse<System.Diagnostics.TraceLevel>(ReadValue("APP", "TRACELAVEL", global::System.Diagnostics.TraceLevel.Verbose.ToString()), out level);
                return level;
            }
            set
            {
                WriteValue("APP", "TRACELAVEL", value.ToString());
            }
        }

        public static string Encrypt(string clearText)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(clearText))
                {
                    string EncryptionKey = "Whm!Uyum*.";
                    byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
                    using (Aes encryptor = Aes.Create())
                    {
                        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                        encryptor.Key = pdb.GetBytes(32);
                        encryptor.IV = pdb.GetBytes(16);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                            {
                                cs.Write(clearBytes, 0, clearBytes.Length);
                                cs.Close();
                            }
                            clearText = Convert.ToBase64String(ms.ToArray());
                        }
                    }
                }
                else
                {
                    clearText = string.Empty;
                }
                return clearText;
            }
            catch
            {
            }
            return "";
        }

        public static string Decrypt(string cipherText)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(cipherText))
                {
                    string EncryptionKey = "Whm!Uyum*.";
                    cipherText = cipherText.Replace(" ", "+");
                    byte[] cipherBytes = Convert.FromBase64String(cipherText);
                    using (Aes encryptor = Aes.Create())
                    {
                        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                        encryptor.Key = pdb.GetBytes(32);
                        encryptor.IV = pdb.GetBytes(16);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                            {
                                cs.Write(cipherBytes, 0, cipherBytes.Length);
                                cs.Close();
                            }
                            cipherText = Encoding.Unicode.GetString(ms.ToArray());
                        }
                    }
                }
                else
                {
                    cipherText = string.Empty;
                }
                return cipherText;
            }
            catch
            {
            }
            return "";
        }
    }
}
