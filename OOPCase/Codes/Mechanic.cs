using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCase.Codes
{
    internal sealed class Mechanic : Person
    {
        public MechanicTask MechanicTask { get; set; }

        public Mechanic(string? firstName, string? lastName, int phoneNumber, MechanicTask mechanicTask) : base(firstName, lastName, phoneNumber)
        {
            MechanicTask = mechanicTask;
        }
        
        public static readonly Mechanic MechanicBil = new Mechanic("Martin", "Jensen", 11111111, MechanicTask.Bilmekaniker);
        public static readonly Mechanic MechanicMotorcykel = new Mechanic("Thomas", "Hansen", 22222222, MechanicTask.Motorcykelmekaniker);
        public static readonly Mechanic MechanicLastbil = new Mechanic("Henrik", "Nielsen", 33333333, MechanicTask.Lastbilmekaniker);
        public List<Mechanic> MechanicList = new() { MechanicBil, MechanicMotorcykel, MechanicLastbil };
    }
}
