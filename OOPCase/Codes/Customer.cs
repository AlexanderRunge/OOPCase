using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCase.Codes
{
    internal sealed class Customer : Person
    {
        public Customer(string? firstName, string? lastName, int? phoneNumber) : base(firstName, lastName, phoneNumber) {}
    }
}
