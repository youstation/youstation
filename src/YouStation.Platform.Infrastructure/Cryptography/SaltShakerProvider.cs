namespace YouStation.Platform.Infrastructure.Cryptography
{
    using System;
    using System.Security.Cryptography;
    using Domain.Cryptography;

    internal class SaltShakerProvider : ISaltShakerProvider
    {
        private const int SaltAmount = 16;
        private const int Iterations = 1000;
        private const int HashSize = 20;
        private const int SaltyHashSize = 36;

        private readonly ICryptoProvider _cryptoProvider;

        public SaltShakerProvider(ICryptoProvider cryptoProvider)
        {
            _cryptoProvider = cryptoProvider;
        }

        public string Salinize(string value)
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();

            var salt = new byte[SaltAmount];
            rngCryptoServiceProvider.GetBytes(salt);

            var pbkdf2 = new Rfc2898DeriveBytes(value, salt, Iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            var saltyHash = new byte[SaltyHashSize];
            Array.Copy(salt, 0, saltyHash, 0, SaltAmount);
            Array.Copy(hash, 0, saltyHash, SaltAmount, HashSize);

            var salty = Convert.ToBase64String(saltyHash);

            return _cryptoProvider.Encrypt(salty);
        }

        public bool Desalinate(string value, string saltyValue)
        {
            var salty = _cryptoProvider.Decrypt(saltyValue);

            var saltyHash = Convert.FromBase64String(salty);

            var salt = new byte[SaltAmount];
            Array.Copy(saltyHash, 0, salt, 0, SaltAmount);

            var pbkdf2 = new Rfc2898DeriveBytes(value, salt, Iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            for (var i = 0; i < HashSize; i++)
            {
                if (saltyHash[i + SaltAmount] != hash[i]) return false;
            }

            return true;
        }
    }
}
