using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //
        // out keyword'ünü birden çok veri dödürceğimiz zamanda kullanabiliriz. Bu functiondan passwordHash ve passwordSalt döner
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //
            //Dissposible Pattern. Using bitince garbageCollector temizler
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                //
                // salt olarak bu değeri veriyoruz. Her kullanıcı için bir key oluşturur
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }

        }
    }
}
