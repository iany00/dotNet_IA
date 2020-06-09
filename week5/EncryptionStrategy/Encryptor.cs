using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptionStrategy
{
    class Encryptor
    {
        private EncryptionStrategy Strategy;
        private string FileName;

        public Encryptor(EncryptionStrategy strategy)
        {
            this.Strategy = strategy;
        }

        public void encrypt()
        {
            Strategy.EncryptData(FileName);
        }

        internal void setFileName(string fileName)
        {
            this.FileName = fileName;
        }
    }
}
