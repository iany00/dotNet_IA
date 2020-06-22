using System;
using System.Collections.Generic;
using System.Text;

namespace Ex2Tasks
{
    static class FileStorage
    {
        public static Queue<string> FileQueue = new Queue<string>();

        public static Dictionary<string, string> ProccessedFiles = new Dictionary<string, string>();

    }
}
