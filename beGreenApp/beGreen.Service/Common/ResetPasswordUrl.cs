using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace beGreen.Services.Common
{
    public static class ResetPasswordUrl
    {
        public static string Create(string uniq)
        {
            byte[] salt = Encoding.UTF8.GetBytes($"{Guid.NewGuid().ToString()}{DateTime.UtcNow.ToLongDateString()}");
            byte[] plainText = Encoding.UTF8.GetBytes(uniq);

            byte[] saltedHash = GenerateSaltedHash(plainText, salt);

            string result = Convert.ToBase64String(saltedHash);

            return result;
        }

        private static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }

            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        private static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
