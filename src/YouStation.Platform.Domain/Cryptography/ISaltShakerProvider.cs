namespace YouStation.Platform.Domain.Cryptography
{
    public interface ISaltShakerProvider
    {
        string Salinize(string value);
        bool Desalinate(string value, string saltyValue);
    }
}
