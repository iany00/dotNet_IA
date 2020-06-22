using System;
using System.IO;
using System.Threading;

namespace Ex2Tasks
{
    internal class FileConsumer
    {
        private CountdownEvent countDownEvent;
        private CancellationToken token;
        private SemaphoreSlim semaphore;

        public FileConsumer(CountdownEvent countDownEvent, CancellationToken token)
        {
            this.countDownEvent = countDownEvent;
            this.token = token;
            semaphore = new SemaphoreSlim(4)
        }

        internal void Consume()
        {
            while(!token.IsCancellationRequested)
            {
                lock(FileStorage.FileQueue)
                {
                    if(FileStorage.FileQueue.Count > 0)
                    {
                        semaphore.Wait();
                        var filePath = FileStorage.FileQueue.Dequeue();
                        try
                        {
                            var fileContent = File.ReadAllText(filePath);
                            var fileName = Path.GetFileName(filePath);

                            FileStorage.ProccessedFiles.Add(fileName, fileContent);

                            this.countDownEvent.Signal();

                        }
                        catch { }
                        semaphore.Release();
                    }
                }
            }
        }
    }
}