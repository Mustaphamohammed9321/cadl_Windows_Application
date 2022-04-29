using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace cadl.Helpers
{
    public class Configuration
    {
        public class Crypt
        {
           
            public string Encrypt(string encryptString)
            {
                //string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string EncryptionKey = Properties.Settings.Default.CryptKey.ToString();
                    ;
                byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[]
                    {
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                    });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        encryptString = Convert.ToBase64String(ms.ToArray());
                    }
                }
                return encryptString;
            }

            public string Decrypt(string cipherText)
            {
                //string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string EncryptionKey = Properties.Settings.Default.CryptKey.ToString();
                cipherText = cipherText.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey,
                        new byte[]
                        {
                        0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                        });

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
                return cipherText;
            }
        }

        public class Connection
        {
            private string ConnectionString()
            {
                return "Data Source=mustapha-garba-;Initial Catalog=ONE_HOME;Persist Security Info=True;Integrated Security=True;TrustServerCertificate=True;encrypt=false;";
            }

            private dynamic ConString()
            {
                return new 
                {
                    DataScource = "Data Source=mustapha-garba-;", 
                    InitialCatalog = "Initial Catalog=ONE_HOME;",
                    PersistSecurity = "Persist Security Info=True;",
                    IntegratedSecurity = "Integrated Security=True;",
                    TrustedCertificate = "TrustServerCertificate=True;"
                };
            }
        }


        public class AppDbContext
        {
            protected readonly string _connectionString = Properties.Settings.Default.ConnectionString.ToString();
            public AppDbContext(string connectionString)
            {
                RepoDb.SqlServerBootstrap.Initialize();
                this._connectionString = connectionString;
            }

            public string ConnectionString()
            {
                var constr = _connectionString;
                return constr;
            }

        }





    }
}
