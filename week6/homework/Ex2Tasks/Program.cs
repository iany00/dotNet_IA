using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ex2Tasks
{
    class Program
    {
        static CancellationTokenSource tokenSource = new CancellationTokenSource();
        static CancellationToken token = tokenSource.Token;

        static void Main(string[] args)
        {
            var countDownEvent = new CountdownEvent(10);

            var publisher = new FilePublisher();
            var consumer = new FileConsumer(countDownEvent, token);

            Task.Factory.StartNew(() =>
            {
                publisher.StartMonitoring();
            }, token);

            var task = Task.Factory.StartNew(() =>
            {
                consumer.Consume();
            }, token);

            countDownEvent.Wait();

            tokenSource.Cancel();
        }
    }
}
