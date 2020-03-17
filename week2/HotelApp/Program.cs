using System;
using System.Collections.Generic;

namespace Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hotel Manager
            HotelManager hotelManager = new HotelManager();

            // Add 2 hotels
            hotelManager.AddHotel("Hilton", "Iasi");
            hotelManager.AddHotel("Continental", "Iasi");

            // Show hotel details
            hotelManager.Print();


            //1. Find a room with a price lower than some value
            decimal maxValue = 100;
            hotelManager.ShowHotelRoomsWithLowPrice(maxValue);
            Console.Write("\n");



            //2. Get price for number of rooms
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("2. Show price per number of rooms");
            Console.Write("Give number of rooms: ");
            int numberOfRooms;
            if (int.TryParse(Console.ReadLine(), out numberOfRooms))
            {
                hotelManager.ShowPriceForNumberOfRooms(numberOfRooms);
            } else {
                Console.WriteLine("Invalid Number");
            }
            Console.Write("\n");



            //3. Get price per day
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("3. Show price per number of days");
            Console.Write("Give number of days: ");
            int numberOfDays;
            if (int.TryParse(Console.ReadLine(), out numberOfDays))
            {
                hotelManager.ShowPriceForNrDays(numberOfDays);
            } else {
                Console.WriteLine("Invalid Number");
            }
            Console.Write("\n");



            // 4. Remove a hotel
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("4.What hotel do you want to remove? Please remove by index:");
            foreach (var hotel in hotelManager.hotels)
            {
                Console.Write($"{hotelManager.hotels.IndexOf(hotel)}. ");
                Console.Write(hotel.Name);
                Console.Write("\n");
            }

            int hotelToRemove;
            if (int.TryParse(Console.ReadLine(), out hotelToRemove))
            {
                bool success = hotelManager.RemoveHotelByIndex(hotelToRemove);
                if(success)
                {
                    Console.WriteLine($"Hotel was removed!");
                } else
                {
                    Console.WriteLine($"Hotel not found!");
                }
            } else
            {
                Console.WriteLine("Invalid hotel index");
            }
        }


    }
}
