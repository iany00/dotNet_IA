using System;

namespace EncryptionStrategy
{
    class Program
    {
        static void Main(string[] args)
        {
            // In memory
            EncryptionStrategy InMemoryStrategy = new EncryptInMemory();
            Encryptor InMemoryEncryptor         = new Encryptor(InMemoryStrategy);
            InMemoryEncryptor.setFileName("smallFile.txt");
            InMemoryEncryptor.encrypt();

            // large file
            EncryptionStrategy LargeFileStrategy = new EncryptLargeFile();
            Encryptor LargeFileEncryptor         = new Encryptor(InMemoryStrategy);
            LargeFileEncryptor.setFileName("smallFile.txt");
            LargeFileEncryptor.encrypt();
        }
    }
}
