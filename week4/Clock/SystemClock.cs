using System;
using System.Collections.Generic;
using System.Text;

namespace Clock
{
    public class SystemClock : IClock
    {
        public DateTime Now => throw new NotImplementedException();

        public DateTime UtcNow => throw new NotImplementedException();

        public BusinessDate Today => throw new NotImplementedException();
    }
}
