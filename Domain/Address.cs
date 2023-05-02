using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Address
    {
        public Guid IdAddress { get; set; }

        public string Street { get; set; }

        public int Number { get; set; }

        public string City { get; set; }

        public Address()
        {

        }

        public Address(string street, int number, string city)
        {
            Street = street;
            Number = number;
            City = city;
        }

        public override string ToString()
        {
            return $"Calle: {Street}, nro: {Number}, ciudad: {City}";
        }
    }
}
