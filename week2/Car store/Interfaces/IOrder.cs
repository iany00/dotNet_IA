using System;
using System.Collections.Generic;
using System.Text;

namespace Car_store
{
    interface IOrder
    { 
        void Cancel();
        void Print();
    }
}
