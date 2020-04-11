namespace YouStation.Platform.Infrastructure.Cryptography
{
    using System;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using Domain.Cryptography;

    internal class RsaCryptoProvider : ICryptoProvider
    {
        private readonly IX509CertificateFactory _x509CertificateFactory;

        public RsaCryptoProvider(IX509CertificateFactory x509CertificateFactory)
        {
            _x509CertificateFactory = x509CertificateFactory;
        }

        public string Encrypt(string decrypted)
        {
            var cert = _x509CertificateFactory.Create();

            using var csp = cert.GetRSAPublicKey();
            var bytesData = Encoding.UTF8.GetBytes(decrypted);
            var bytesEncrypted = csp.Encrypt(bytesData, RSAEncryptionPadding.Pkcs1);
            var output = Convert.ToBase64String(bytesEncrypted);
            
            return output;
        }

        public string Decrypt(string encrypted)
        {
            var cert = _x509CertificateFactory.Create();

            using var csp = cert.GetRSAPrivateKey();
            var bytesEncrypted = Convert.FromBase64String(encrypted);
            var bytesDecrypted = csp.Decrypt(bytesEncrypted, RSAEncryptionPadding.Pkcs1);
            var text = Encoding.UTF8.GetString(bytesDecrypted);
            
            return text;
        }
    }
}
