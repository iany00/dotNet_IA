using ParkingLot.Enums;
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

        internal void AddFreeSpot(ParkingSpot spot)
        {
            spot.status = ParkingSpotStatus.Vacant;
            this.FreeSpots.Add(spot);
        }

        internal void OccupySpot(string vehicleNumber, ParkingSpot spot)
        {
            spot.status = ParkingSpotStatus.Occupied;
            this.FreeSpots.Remove(spot);
            this.OccupiedSpot.Add(vehicleNumber, spot);
        }

        internal void RemoveOccupiedSpot(ParkingSpot spot)
        {
            foreach (var oSpot in this.OccupiedSpot)
            {
                if (oSpot.Value == spot)
                {
                    this.OccupiedSpot.Remove(oSpot.Key);
                    this.AddFreeSpot(spot);
                    break;
                }
            }
        }
    }

}
 