using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DnDPersoUtil.AESCrypt
{
    public class AESCrypt
    {
        #region File encryption
        public static void EncryptFile(string inputFilePath, string outputfilePath, string key)
        {
            using (Aes encryptor = Aes.Create())
            {
                if (encryptor != null)
                {
                    List<byte[]> listPassPhrase = GenerateAlgotihmInputs(key.Substring(6, 40));
                    encryptor.Key = listPassPhrase[0];
                    encryptor.IV = listPassPhrase[1];
                    encryptor.Mode = CipherMode.CBC;

                    using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
                    {
                        using (CryptoStream cs = new CryptoStream(fsOutput, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
                            {
                                int data;
                                while ((data = fsInput.ReadByte()) != -1)
                                {
                                    cs.WriteByte((byte)data);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void DecryptFile(string inputFilePath, string outputfilePath, string key)
        {
            using (Aes encryptor = Aes.Create())
            {
                if (encryptor != null)
                {
                    List<byte[]> listPassPhrase = GenerateAlgotihmInputs(key.Substring(6, 40));
                    encryptor.Key = listPassPhrase[0];
                    encryptor.IV = listPassPhrase[1];
                    encryptor.Mode = CipherMode.CBC;

                    using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
                    {
                        using (CryptoStream cs = new CryptoStream(fsInput, encryptor.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
                            {
                                int data;
                                while ((data = cs.ReadByte()) != -1)
                                {
                                    fsOutput.WriteByte((byte)data);
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region String encryption

        public static string[] CryptIni(string dataString)
        {
            string[] tabCrypto = new string[2];

            string cleId = randomString(64);
            tabCrypto[0] = cleId;

            List<byte[]> listPassPhrase = GenerateAlgotihmInputs(cleId.Substring(6, 40));
            byte[] clef = listPassPhrase[0];
            byte[] vecteur = listPassPhrase[1];

            string mdpCrypte = Encrypt(dataString, clef, vecteur);
            tabCrypto[1] = mdpCrypte;

            return tabCrypto;
        }

        public static string CryptString(string dataString, string cle)
        {
            List<byte[]> listPassPhrase = GenerateAlgotihmInputs(cle.Substring(6, 40));
            byte[] clef = listPassPhrase[0];
            byte[] vecteur = listPassPhrase[1];

            return Encrypt(dataString, clef, vecteur);
        }

        public static string DeCryptString(string mdpC, string cleUniq)
        {
            List<byte[]> listPassPhrase = GenerateAlgotihmInputs(cleUniq.Substring(6, 40));
            byte[] clef = listPassPhrase[0];
            byte[] vecteur = listPassPhrase[1];

            string mdpDecrypte = Decrypt(mdpC, clef, vecteur);

            return mdpDecrypte;
        }

        private static string Encrypt(string clearText, byte[] byteKey, byte[] byteIv)
        {
            byte[] plainText = Encoding.UTF8.GetBytes(clearText);

            AesManaged rijndael = new AesManaged();
            rijndael.Mode = CipherMode.CBC;

            ICryptoTransform aesEncryptor = rijndael.CreateEncryptor(byteKey, byteIv);

            MemoryStream memStream = new MemoryStream();

            CryptoStream cryptoS = new CryptoStream(memStream, aesEncryptor, CryptoStreamMode.Write);
            cryptoS.Write(plainText, 0, plainText.Length);
            cryptoS.FlushFinalBlock();

            byte[] byteEncode = memStream.ToArray();

            memStream.Close();
            memStream.Dispose();
            cryptoS.Close();
            cryptoS.Dispose();

            return Convert.ToBase64String(byteEncode);
        }

        private static string Decrypt(string textEncode, byte[] byteKey, byte[] byteIv)
        {
            byte[] cipheredData = Convert.FromBase64String(textEncode);

            AesManaged rijndael = new AesManaged();
            rijndael.Mode = CipherMode.CBC;

            ICryptoTransform decryptor = rijndael.CreateDecryptor(byteKey, byteIv);
            MemoryStream memStream = new MemoryStream(cipheredData);
            CryptoStream cryptoS = new CryptoStream(memStream, decryptor, CryptoStreamMode.Read);

            byte[] plainTextData = new byte[cipheredData.Length];

            int decryptedByteCount = cryptoS.Read(plainTextData, 0, plainTextData.Length);

            memStream.Close();
            memStream.Dispose();
            cryptoS.Close();
            cryptoS.Dispose();

            return Encoding.UTF8.GetString(plainTextData, 0, decryptedByteCount);
        }

        #endregion

        private static List<byte[]> GenerateAlgotihmInputs(string data)
        {
            byte[] key;
            byte[] iv;

            List<byte[]> result = new List<byte[]>();

            Rfc2898DeriveBytes rfcDb = new Rfc2898DeriveBytes(data, Encoding.UTF8.GetBytes(data));

            key = rfcDb.GetBytes(32);
            iv = rfcDb.GetBytes(16);

            result.Add(key);
            result.Add(iv);

            return result;
        }

        private static string randomString(int length)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            char[] chars = new char[length];

            string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            for (int i = 0; i < length; i++)
            {
                byte[] bytes = new byte[1];
                rng.GetBytes(bytes);

                Random rnd = new Random(bytes[0]);

                chars[i] = validChars[rnd.Next(0, validChars.Length)];
            }

            return (new string(chars));
        }
    }
}
