using System;
using System.Collections.Generic;
using System.Text;

namespace Car_store
{
    interface IStore
    {
        void StoreCustomerOrder(Customer customer, Car orderedCar);
        void CancelCustomerOrder(Customer customer, Car orderedCar);
        void PrintOrder(Order order);
        void PrintCustomerOrders(Customer customer);
    }
}
