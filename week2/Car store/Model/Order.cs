using System;
using System.Collections.Generic;
using System.Text;

namespace Car_store
{
    class Order : IOrder
    {
        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliverDate { get; set; }
        public bool Deliverd { get; set; }
        public bool PaymentConfirmed { get; set; }
        public bool Canceled { get; set; }


        public Order(Customer customer, Car car)
        {
            car.Reserved = true;

            this.Customer = customer;
            this.Car = car;
            this.OrderDate = DateTime.Now;
            this.DeliverDate = car.DeliverDate;
        }

        public void Cancel()
        {
            this.Canceled = true;
        }

        public void DeliverCar()
        {
            // Mark car not available
            this.Car.MakeCarNotAvailable();

            this.Deliverd = true;

            this.PaymentConfirmed = true;
        }

        public void Print()
        {
            DataWriteManager dataWriteManager = new DataWriteManager();

            // Print ordered car
            this.Car.Print();

            dataWriteManager.WriteLine($"Order date: {this.OrderDate}");
            dataWriteManager.WriteLine($"Deliver date: {this.DeliverDate}");
            string PaymentMade = this.PaymentConfirmed ? "YES" : "NO" ;
            dataWriteManager.WriteLine($"Payment made: {PaymentMade}");

        }

    }
}
