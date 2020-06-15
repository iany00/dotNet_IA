namespace UiFormApp
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class UiForm : Form
    {
        public UiForm()
        {
            this.InitializeComponent();
        }

        private void DownloadBtnLeft_Click(object sender, System.EventArgs e)
        {
            var url = this.urlTextBoxLeft.Text;
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Task<string> task = new Task<string>(() =>
            {
                return this.DownloadString(url);
            });

            task.ContinueWith(ant =>
            {
                this.contentTxbLeft.Text = ant.Exception.Message;
               
            }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, uiScheduler);


            task.ContinueWith(prev =>
            {
                this.contentTxbLeft.Text = task.Result;
                this.logLabelLeft.Text = $@"Downloaded in {stopwatch.ElapsedMilliseconds} ms";
            }, CancellationToken.None, TaskContinuationOptions.NotOnFaulted, uiScheduler);

            task.Start();
        }

        private async void DownloadBtnRight_Click(object sender, System.EventArgs e)
        {
            var url = this.urlTextBoxRight.Text;        

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            /* var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
             Task<string> task = new Task<string>(() =>
             {
                 try
                 {
                     var html = this.DownloadString(url);
                     return html;
                 }
                 catch
                 {
                     throw new Exception("Invalid Url");
                 }
             });

             task.ContinueWith(ant =>
             {
                 this.contentTxbRight.Text = ant.Exception.InnerException.Message;

             }, TaskContinuationOptions.OnlyOnFaulted);


             task.ContinueWith(prev =>
             {
                 this.contentTxbRight.Text = task.Result;
                 this.logLabelRight.Text = $@"Downloaded in {stopwatch.ElapsedMilliseconds} ms";
             }, uiScheduler);

             task.Start();*/

            try
            {

                var task = await DownloadStringAsync(url);
                this.contentTxbRight.Text = task;
            }
            catch (Exception ex)
            {

                this.contentTxbRight.Text = ex.Message;
            }
            
            this.logLabelRight.Text = $@"Downloaded in {stopwatch.ElapsedMilliseconds} ms";

        }

        private string DownloadString(string url)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2)); // simulate some work
            return new WebClient().DownloadString(url);
        }

        private Task<string> DownloadStringAsync(string url)
        {
            return Task.Run(() => DownloadString(url));
        }
    }
}
