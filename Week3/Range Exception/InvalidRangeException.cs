using System;
using System.Collections.Generic;
using System.Text;

namespace Range_Exception
{
    class InvalidRangeException<T> : Exception
    {
        public T Min { get; set; }
        public T Max { get; set; }

       
        public InvalidRangeException(string message, T min, T max): base(message)
        {
            Min = min;
            Max = max;
           
        }

    }
}
