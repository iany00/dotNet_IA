using System;
using System.IO;

namespace Ex2Tasks
{
    internal class FilePublisher
    {
        private FileSystemWatcher watcher;
        public FilePublisher()
        {
            watcher = new FileSystemWatcher();
        }

        internal void StartMonitoring()
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "EX3\\watchFiles");

            watcher.Path = path;

            watcher.Created += OnCreated;

            watcher.EnableRaisingEvents = true;

        }

        private void OnCreated(object source, FileSystemEventArgs e) => FileStorage.FileQueue.Enqueue(e.FullPath);
        
    }
}