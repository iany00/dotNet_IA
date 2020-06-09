using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptionStrategy
{
    public interface EncryptionStrategy
    {
        void EncryptData(string fileName);
    }
}
