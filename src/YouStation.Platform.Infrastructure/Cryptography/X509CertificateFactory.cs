namespace YouStation.Platform.Infrastructure.Cryptography
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Security.Cryptography.X509Certificates;
    using Domain.Cryptography;

    public class X509CertificateFactory : IX509CertificateFactory
    {
        // TODO: config?
        private const string CertificateName = "certificate.p12";
        private const string CertificateSecureString = "#youstation$";
        
        private const string CannotAccessBinaryDirectory = "cannot access binary directory";
        
        public X509Certificate2 Create()
        {
            var binDirectoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            if (binDirectoryName == default)
                // TODO: crate a custom exception.
                throw new NullReferenceException("cannot access binary directory");

            var certificateBytes = File.ReadAllBytes(Path.Combine(binDirectoryName, CertificateName));
            var certificate = new X509Certificate2(certificateBytes, CertificateSecureString);

            return certificate;
        }
    }
}
