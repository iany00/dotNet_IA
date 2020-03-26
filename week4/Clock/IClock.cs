using System;


namespace Clock
{
    public interface IClock
    {
        DateTime Now { get; }

        DateTime UtcNow { get; }

        BusinessDate Today { get; }
    }

  
}
