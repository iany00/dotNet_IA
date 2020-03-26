using System;

namespace LinqAndLamdaExpressions.Models
{
    public class Address
    {
        public string Street { get; set; }

        public string Suite { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        public Geo Geo { get; set; }

        public void Print()
        {
            Console.WriteLine(this.Street);
            Console.WriteLine(this.Suite);
            Console.WriteLine(this.City);
            Console.WriteLine(this.Zipcode);
            Console.WriteLine(this.Geo.Lng + " / " + this.Geo.Lat );
        }
    }
}