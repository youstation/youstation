namespace YouStation.Platform.Domain.Cryptography
{
    using System.Security.Cryptography.X509Certificates;

    public interface IX509CertificateFactory
    {
        X509Certificate2 Create();
    }
}
