using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TesteLeonardo.Dominio;
using TesteLeonardo.Interface;

namespace TesteLeonardo.Helper
{
    //public class TokenRepositorio : ITokenRepositorio
    //{
    //    public Token GenerateToken()
    //    {
    //        Token token = new Token();
    //        token.Guid = Guid.NewGuid();
    //        token.ExpiraEm = DateTime.Now.AddMinutes(1);
    //        return token;
    //    }
    //}

    public static class StringCipher
    {
        private const int Keysize = 256;
        private const int DerivationIterations = 1000;

        //public static string Encrypt(string plainText, string passPhrase, bool converterMD5)
        //{
        //    // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
        //    // so that the same Salt and IV values can be used when decrypting.  
        //    var saltStringBytes = Generate256BitsOfRandomEntropy();
        //    var ivStringBytes = Generate256BitsOfRandomEntropy();
        //    var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        //    using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
        //    {
        //        var keyBytes = password.GetBytes(Keysize / 8);
        //        using (var symmetricKey = new RijndaelManaged())
        //        {
        //            symmetricKey.BlockSize = 256;
        //            symmetricKey.Mode = CipherMode.CBC;
        //            symmetricKey.Padding = PaddingMode.PKCS7;
        //            using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
        //            {
        //                using (var memoryStream = new MemoryStream())
        //                {
        //                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        //                    {
        //                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
        //                        cryptoStream.FlushFinalBlock();
        //                        // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
        //                        var cipherTextBytes = saltStringBytes;
        //                        cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
        //                        cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
        //                        memoryStream.Close();
        //                        cryptoStream.Close();

        //                        if (converterMD5)
        //                        {
        //                            using (MD5 md5Hash = MD5.Create())
        //                            {
        //                                return GetMD5(md5Hash, Convert.ToBase64String(cipherTextBytes));
        //                            }
        //                        }
        //                        else
        //                        {
        //                            return Convert.ToBase64String(cipherTextBytes);
        //                        }
                                
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        public static string ToMD5(string frase)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return GetMD5(md5Hash, frase);
            }
        }

        public static bool ValidaMD5(string md5, string frase)
        {
            bool validado = false;
            using (MD5 md5Hash = MD5.Create())
            {
                validado = VerifyMd5Hash(md5Hash, frase, md5);
            }

            return validado;
        }

        static string GetMD5(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMD5(md5Hash, input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public static string Decrypt(string hashMD5, string passPhrase, string expiraEm)
        //{
        //    using (MD5 md5Hash = MD5.Create())
        //    {
        //        var cipher = Encrypt(expiraEm, passPhrase, false);

        //        if (VerifyMd5Hash(md5Hash, cipher, hashMD5))
        //        {
                    

        //            // Get the complete stream of bytes that represent:
        //            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
        //            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipher);
        //            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
        //            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
        //            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
        //            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
        //            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
        //            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

        //            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
        //            {
        //                var keyBytes = password.GetBytes(Keysize / 8);
        //                using (var symmetricKey = new RijndaelManaged())
        //                {
        //                    symmetricKey.BlockSize = 256;
        //                    symmetricKey.Mode = CipherMode.CBC;
        //                    symmetricKey.Padding = PaddingMode.PKCS7;
        //                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
        //                    {
        //                        using (var memoryStream = new MemoryStream(cipherTextBytes))
        //                        {
        //                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
        //                            {
        //                                var plainTextBytes = new byte[cipherTextBytes.Length];
        //                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
        //                                memoryStream.Close();
        //                                cryptoStream.Close();
        //                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception("Erro na descriptografia.");
        //        }
        //    }            
        //}

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }
}
