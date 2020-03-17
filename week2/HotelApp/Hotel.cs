using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel
{
    class Hotel
    {
        public string Name { get; set;}
        public string City { get; set; }
        public List<Room> Rooms { get; set; }

        // Construct
        public Hotel(string name, string city)
        {
            this.Name = name;
            this.City = city;
        }


        /*
        * Show hotel details
        */
        public void Print()
        {
            Console.WriteLine($"Hotel: {this.Name}\nCity: {this.City} \n");

            foreach (var room in this.Rooms)
            {
                room.Print();
            }
        }


        // Add some hard coded rooms
        internal void AddHardCodedRooms()
        {
            this.Rooms = new List<Room>();

            // Set a new room
            Room room = new Room
            {
                Name     = "Standard",
                Adults   = 2,
                Children = 1,
                Rate     = new Rate
                {
                    Amount   = 100,
                    Currency = "Lei"
                }
            };
            // Set a new room
            Room room2 = new Room
            {
                Name     = "Deluxe",
                Adults   = 3,
                Children = 1,
                Rate     = new Rate
                {
                    Amount   = 200,
                    Currency = "Lei"
                }
            };

            // Add rooms
            this.Rooms.Add(room);
            this.Rooms.Add(room2);
        }

        /**
         *  Find a room with a price lower than some value
         */
        internal Room GetHotelRoomsWithLowPrice(decimal maxValue)
        {
            foreach (Room hotelRoom in this.Rooms)
            {
                if (hotelRoom.Rate.Amount <= maxValue)
                {
                    return hotelRoom;
                }
            }
            return null;
        }
    }
}
