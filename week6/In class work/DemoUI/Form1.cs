namespace DemoUI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using DemoUI.Core;

    public partial class Form1 : Form
    {
        private const string Path =
            @"..\..\..\cars.csv";

        public Form1()
        {
            this.InitializeComponent();
        }

        private void GetDataBtn_Click(object sender, EventArgs e)
        {
            this.Log("start to process file");

            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            Task<IList<Car>> task = new Task<IList<Car>>(() =>
            {
                var cars = this.ProcessCarsFile(Path).ToList();
                return cars;
            });

            task.ContinueWith(prev =>
           {
               this.DisplayCars(prev.Result);
               this.Log($"finish to process file .{prev.Result.Count()} cars Downloaded");
           }, uiScheduler);

            task.Start();
        }

        private void DisplayCars(IList<Car> cars)
        {
            foreach (var car in cars)
            {
                this.AppendToContent(car.ToString());
            }
        }

        private IEnumerable<Car> ProcessCarsFile(string filePath)
        {
            var cars = new List<Car>(600);
            var lines = File.ReadAllLines(filePath).Skip(2);

            foreach (var line in lines)
            {
                cars.Add(Car.Parse(line));
            }

            Thread.Sleep(TimeSpan.FromSeconds(3)); // simulate some work

            return cars;
        }

        public void Log(string s)
        {
            this.logTbx.AppendText($"{DateTime.Now} - {s}{Environment.NewLine}");
        }

        public void AppendToContent(string s)
        {
            this.contentTxb.AppendText($"{s}{Environment.NewLine}");

            //Thread.Sleep(TimeSpan.FromSeconds(3)); // simulate other work
        }
    }
}
