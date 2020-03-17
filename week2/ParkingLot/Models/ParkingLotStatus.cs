using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    public class ParkingLotStatus
    {
        public List<ParkingSpot> FreeSpots { get; set; }
        public Dictionary<string, ParkingSpot> OccupiedSpot { get; set; }

        public ParkingSpot GetFreeSpot()
        {
            return this.FreeSpots.First();
        }

        internal void AddFreeSpot(ParkingSpot spot)
        {
            this.FreeSpots.Add(spot);
        }
    }

}
 