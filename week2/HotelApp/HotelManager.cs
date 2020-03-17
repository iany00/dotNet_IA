using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel
{
    class HotelManager
    { 
        public List<Hotel> hotels { get; set; }

        public HotelManager()
        {
            this.hotels = new List<Hotel>();
        }

        internal void AddHotel(string name, string city)
        {
            // Set a new hotel
            Hotel hotel = new Hotel(name, city);

            // Add hard coded rooms
            hotel.AddHardCodedRooms();

            // Add hotel to list
            this.hotels.Add(hotel);
        }

        // Remove hotel by index
        internal bool RemoveHotelByIndex(int hotelIndexToRemove)
        {
            try
            {
                this.hotels.RemoveAt(hotelIndexToRemove);
            }
            catch (Exception)
            {
                return false;
            }
           
            return true;
        }


        // Show all hotels
        public void Print()
        {
            Console.WriteLine("--- Show all Hotels ---");
            foreach (var hotel in this.hotels)
            {
                hotel.Print();
                Console.WriteLine("----------------------------------------");
            }
        }

        /*
        *  Find a room with a price lower than some value
        */
        internal void ShowHotelRoomsWithLowPrice(decimal maxValue)
        {
            Console.WriteLine($"1. Hotel rooms with price lower then 100 are:");
            foreach (var hotel in this.hotels)
            {
                Room hotelRoom = hotel.GetHotelRoomsWithLowPrice(maxValue);
                if (hotelRoom != null)
                {
                    Console.WriteLine($"Hotel:`{hotel.Name}` Room: `{hotelRoom.Name}`");
                }
            }
        }

        /*
        * Show price per day
        */
        internal void ShowPriceForNrDays(int numberOfDays)
        {
            foreach (var hotel in this.hotels)
            {
                decimal price = 0;
                foreach (var room in hotel.Rooms)
                {
                    price = numberOfDays * room.Rate.Amount;
                    Console.WriteLine($"Hotel: `{hotel.Name}` Room: '{room.Name}' price is {price} {room.Rate.Currency}");
                }
            }
        }

        /**
         *  Show price per number of rooms
         */
        internal void ShowPriceForNumberOfRooms(int numberOfRooms)
        {
            foreach (var hotel in this.hotels)
            {
                decimal price = 0;
                var hotelNrRooms  = hotel.Rooms.Count;
                if (numberOfRooms <= hotelNrRooms)
                {
                    foreach (var room in hotel.Rooms)
                    {
                        price += room.Rate.Amount;
                    }
                    Console.WriteLine($"Hotel `{hotel.Name}` price for {numberOfRooms} rooms is: {price}");
                } else
                {
                    Console.WriteLine($"Hotel  `{hotel.Name}` has only {hotelNrRooms} rooms");
                }
            }
        }

       

    }
}
