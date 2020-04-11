namespace YouStation.Platform.Domain.Cryptography
{
    public interface ICryptoProvider
    {
        string Encrypt(string decrypted);
        string Decrypt(string encrypted);
    }
}
