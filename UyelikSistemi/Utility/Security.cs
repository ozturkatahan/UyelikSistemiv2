using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace UyelikSistemi.Utility
{
    public static class Security
    {
        public static string HashPassword(string password)
        {
            SHA256 hasher = SHA256.Create();
            byte[] hashArray = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));
            string hexString = BitConverter.ToString(hashArray).Replace("-", "");
            return hexString;
        }
    }
}