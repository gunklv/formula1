using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace API.Helpers
{
    public static class Hasher
    {
        public static byte[] Salt
        {
            get { 
                var salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
                return salt;
            }
        }

        public static string Hash(string input, byte[] salt)
            => Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: input,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));
    }
}
