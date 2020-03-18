using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Models
{
    class ParkingLevel : IEnumerable
    {
        public IEnumerable<List<ParkingSpot>> parkingLevel;
        protected int levelNumber;

        public IEnumerator<ParkingSpot> GetEnumerator()
        {
            return ParkingSpot.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ParkingSpot.GetEnumerator();
        }
    }
}
