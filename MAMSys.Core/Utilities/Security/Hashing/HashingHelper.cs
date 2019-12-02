using System;
using System.Collections.Generic;
using System.Text;

namespace MAMSys.Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void sifreHashOlustur(string sifre, out byte[] sifreHash, out byte[] sifreTuz)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                sifreTuz = hmac.Key;
                sifreHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(sifre));
            }
        }

        public static bool sifreHashDogrula(string sifre, byte[] sifrehash, byte[] sifreTuz)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(sifreTuz))
            {
                var hashDegeri = hmac.ComputeHash(Encoding.UTF8.GetBytes(sifre));
                for (int i = 0; i < hashDegeri.Length; i++)
                {
                    if (hashDegeri[i] != sifrehash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
