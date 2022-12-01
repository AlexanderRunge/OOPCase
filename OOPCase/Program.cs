using OOPCase.Codes;
using System.Text.RegularExpressions;

Console.WriteLine("Velkommen!");

Vehicle vehicleRegistration = new() {Registrations = new List<Vehicle>() { }};
List<Vehicle> registrations = vehicleRegistration.Registrations;

while (true)
{
    Console.Write("Skriv en af følgende muligheder:\n" +
                  "[1] for at registrer ny bil\n" +
                  "[2] for at søge efter kunde i systemet\n" +
                  "[3] for at søge efter mekaniker i systemet\n" +
                  "[Q] for at afslutte programmet\n" +
                  "Skriv tegnet i parentes for at vælge: ");
    string? input = Console.ReadLine();
    Console.Clear();
    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Du skal skrive noget!");
    }
    else if (input.ToLower().Trim() == "1")
    {
        Console.WriteLine("Du har valgt at registrere en ny bil.");
        Console.Write("Skriv kundens fornavn: ");
        string? customerFirstName = Console.ReadLine();
        Console.Write("Skriv kundens efternavn: ");
        string? customerLastName = Console.ReadLine();
        int customerPhoneNumber;
        while (true)
        {
            Console.Write("Skriv kundens telefonnummer (+45): ");
            string? customerPhoneNumberString = Console.ReadLine();
            if (string.IsNullOrEmpty(customerPhoneNumberString))
            {
                Console.WriteLine("Du skal skrive noget!");
            }
            else if (customerPhoneNumberString.Length != 8)
            {
                Console.WriteLine("Du skal skrive et telefonnummer på 8 cifre!");
            } 
            else if (int.TryParse(customerPhoneNumberString, out customerPhoneNumber))
            {
                break;
            }
            Console.WriteLine("Du skal skrive et tal!");

        }
        string? vehicleLicensePlate;
        while (true)
        {
            Console.Write("Skriv nummerpladen (xx 00 000): ");
            vehicleLicensePlate = Console.ReadLine();
            if (string.IsNullOrEmpty(vehicleLicensePlate))
            {
                Console.WriteLine("Du skal skrive noget!");
            }
            else if (!Regex.IsMatch(vehicleLicensePlate.ToUpper(), @"^[A-Z]{2} \d{2} \d{3}$"))
            {
                Console.WriteLine("Ugyldigt nummerplade format!");
            }
            else
            {
                break;
            }
        }
        vehicleLicensePlate.ToUpper();
        Console.Write("Skriv mærket: ");
        string? vehicleBrand = Console.ReadLine();
        Console.Write("Skriv modelen:");
        string? vehicleModel = Console.ReadLine();
        int? registrationYear;
        while (true)
        {
            Console.Write("Skriv registrerings år (åååå): ");
            string? registrationYearString = Console.ReadLine();
            if (string.IsNullOrEmpty(registrationYearString))
            {
                Console.WriteLine("Du skal skrive noget!");
            }
            else if (int.TryParse(registrationYearString, out int registrationYearInt))
            {
                registrationYear = registrationYearInt;
                break;
            }
            else
            {
                Console.WriteLine("Du skal skrive et tal!");
            }
        }

        VehicleType vehicleType;
        while (true)
        {
            Console.Write("Skriv køretøjstypen (Bil, Motorcykel, Lastbil): ");
            string? vehicleTypeString = Console.ReadLine();
            if (string.IsNullOrEmpty(vehicleTypeString))
            {
                Console.WriteLine("Du skal skrive noget!");
            }
            else if (vehicleTypeString.ToLower().Trim() == VehicleType.Bil.ToString().ToLower())
            {
                vehicleType = VehicleType.Bil;
                break;
            }
            else if (vehicleTypeString.ToLower().Trim() == VehicleType.Motorcykel.ToString().ToLower())
            {
                vehicleType = VehicleType.Motorcykel;
                break;
            }
            else if (vehicleTypeString.ToLower().Trim() == VehicleType.Lastbil.ToString().ToLower())
            {
                vehicleType = VehicleType.Lastbil;
                break;
            }
            Console.WriteLine("Ugyldig køretøjstype!");
        }
        Customer customer = new Customer(customerFirstName, customerLastName, customerPhoneNumber);
        Vehicle vehicle = new Vehicle(customer, vehicleLicensePlate, vehicleBrand, vehicleModel, registrationYear, vehicleType);
        registrations.Add(vehicle);
        registrations.Sort();
        Console.WriteLine("Du har nu registreret et nyt køretøj. Her er alle registreret køretøjer: ");
        foreach (var vehicles in registrations)
        {
            Console.WriteLine($"{vehicles.Customer.FirstName} {vehicles.Customer.LastName} har en {vehicles.Brand} {vehicles.Model} {vehicles.RegistrationYear} {vehicles.VehicleType.ToString().ToLower()} med nummerplade {vehicles.LicensePlate}, som bliver serviceret af {vehicles.Mechanic.FirstName} {vehicles.Mechanic.LastName}.");
        }
        Console.WriteLine();
    }
    else if (input.ToLower().Trim() == "2")
    {
        Console.Write("Skriv fornavn og efternavn på en kunde: ");
        string? searchName = Console.ReadLine();
        foreach (var vehicle in registrations)
        {
            if (vehicle.Customer.FirstName.ToLower().Trim() == searchName.Split(" ")[0].ToLower().Trim() && vehicle.Customer.LastName.ToLower().Trim() == searchName.Split(" ")[1].ToLower().Trim())
            {
                Console.WriteLine($"{vehicle.Customer.FirstName} {vehicle.Customer.LastName} har en {vehicle.Brand} {vehicle.Model} {vehicle.RegistrationYear} {vehicle.VehicleType.ToString().ToLower()} med nummerplade {vehicle.LicensePlate}, som bliver serviceret af {vehicle.Mechanic.FirstName} {vehicle.Mechanic.LastName}.");
            }
        }
        Console.WriteLine();
    }
    else if (input.ToLower().Trim() == "3")
    {
        Console.Write("Skriv fornavn og efternavn på en mekaniker: ");
        string? searchName = Console.ReadLine();
        foreach (var vehicle in registrations)
        {
            if (vehicle.Mechanic.FirstName.ToLower().Trim() == searchName.Split(" ")[0].ToLower().Trim() && vehicle.Mechanic.LastName.ToLower().Trim() == searchName.Split(" ")[1].ToLower().Trim())
            {
                Console.WriteLine($"{vehicle.Mechanic.FirstName} {vehicle.Mechanic.LastName} servicerer en {vehicle.Brand} {vehicle.Model} {vehicle.RegistrationYear} med nummerplade {vehicle.LicensePlate} for {vehicle.Customer.FirstName} {vehicle.Customer.LastName}.");
            }
        }
        Console.WriteLine();
    }
    else if (input.ToLower().Trim() == "q")
    {
        break;
    }
    else
    {
        Console.WriteLine("Du valgte ikke en gyldig muglighed!");
    }
}