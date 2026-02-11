namespace Neoble.AssetProvider.Infrastructure.Security.Encryption.Abstractions;

public interface IEncryptionProvider
{
    string Encrypt(string providerName, string plaintext);
    string Decrypt(string providerName, string ciphertext);
}
