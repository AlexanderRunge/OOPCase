using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCase.Codes
{
    internal class Vehicle
    {
        public string? licensePlate { get; set; }
        public string? brand { get; set; }
        public string? model { get; set; }
        public int registrationYear { get; set; }
        public VeichleType veichleType { get; set; }
        public Mechanic mechanic { get; set; }
        public Customer customer { get; set; }
    }
}
