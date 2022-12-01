using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCase.Codes
{
    internal class Vehicle : IComparable<Vehicle>
    {
        public Customer? Customer { get; set; }
        public string? LicensePlate { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? RegistrationYear { get; set; }
        public VehicleType _VehicleType { get; set; }
        public VehicleType VehicleType
        {
            get { return _VehicleType; }
            set
            {
                _VehicleType = value;
                if (value == VehicleType.Bil)
                {
                    Mechanic = Mechanic.MechanicBil;
                }
                else if (value == VehicleType.Motorcykel)
                {
                    Mechanic = Mechanic.MechanicMotorcykel;
                }
                else if (value == VehicleType.Lastbil)
                {
                    Mechanic = Mechanic.MechanicLastbil;
                }
                else
                {
                    Mechanic = null;
                }
            }
        }
        public Mechanic? Mechanic { get; set; }
        public Vehicle(Customer customer, string? licensePlate, string? brand, string? model, int? registrationYear, VehicleType vehicleType)
        {
            Customer = customer;
            LicensePlate = licensePlate;
            Brand = brand;
            Model = model;
            RegistrationYear = registrationYear;
            VehicleType = vehicleType;
        }
        public Vehicle() { }
        
        public List<Vehicle> Registrations = new();
        public int CompareTo(Vehicle? other)
        {
            if (other != null)
            {
                return this.VehicleType.CompareTo(other.VehicleType);
            }
            return 1;
        }
    }
}
