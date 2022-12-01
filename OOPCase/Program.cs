using System.Text.RegularExpressions;

Console.WriteLine("Velkommen!");

Vehicle vehicleRegistration = new() {Registrations = new List<Vehicle>() { }};
List<Vehicle> registrations = vehicleRegistration.Registrations;

while (true)
{
    Console.Write("Skriv en af følgende muligheder:\n" +
                  "[1] for at registrer ny bil\n" +
                  "[2] for at søge i systemet\n" +
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
            
            if (int.TryParse(customerPhoneNumberString, out customerPhoneNumber))
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
            else if (!Regex.IsMatch(vehicleLicensePlate.ToUpper(), @"^[A-ZÆØÅ][A-ZÆØÅ]\s\d\d\s\d\d\d$"))
            {
                Console.WriteLine("Ugyldigt nummerplade format!");
            }
            else
            {
                break;
            }
        }
        vehicleLicensePlate.ToUpper();
        Console.WriteLine("Skriv mærket: ");
        string? vehicleBrand = Console.ReadLine();
        Console.WriteLine("Skriv modelen:");
        string? vehicleModel = Console.ReadLine();
        DateTime registrationDate;
        while (true)
        {
            Console.Write("Skriv registreringsDato (dd/MM/yyyy): ");
            string? registrationDateString = Console.ReadLine();
            string[]? registrationDateSplit = registrationDateString.Split("/");
            try
            {
                registrationDate = new DateTime(int.Parse(registrationDateSplit[2]), int.Parse(registrationDateSplit[1]), int.Parse(registrationDateSplit[0]));
                break;
            }
            catch (Exception)
            {
                Console.WriteLine("Ugyldig dato!");
            }
            Console.WriteLine("Du skal skrive et tal!");
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
        Vehicle vehicle = new Vehicle(customer, vehicleLicensePlate, vehicleBrand, vehicleModel, registrationDate, vehicleType);
        registrations.Add(vehicle);
        registrations.Sort();
        Console.WriteLine("Du har nu registreret en ny bil. Her er alle registreret biler:");
        foreach (var vehicles in registrations)
        {
            Console.WriteLine($"{vehicles.Customer.FirstName} {vehicles.Customer.LastName} har en {vehicles.Brand} {vehicles.Model} {vehicles.VehicleType.ToString().ToLower()} med nummerplade {vehicles.LicensePlate}, som bliver serviceret af {vehicles.Mechanic.FirstName} {vehicles.Mechanic.LastName}.");
        }
        Console.WriteLine();
    }
    else if (input.ToLower().Trim() == "2")
    {
        Console.Write("Skriv fornav og efternavn på en kunde: ");
        string? searchName = Console.ReadLine();
        foreach (var vehicle in registrations)
        {
            if (vehicle.Customer.FirstName.ToLower().Trim() == searchName.Split(" ")[0].ToLower().Trim() && vehicle.Customer.LastName.ToLower().Trim() == searchName.Split(" ")[1].ToLower().Trim())
            {
                Console.WriteLine($"{vehicle.Customer.FirstName} {vehicle.Customer.LastName} har en {vehicle.Brand} {vehicle.Model} {vehicle.VehicleType.ToString().ToLower()} med nummerplade {vehicle.LicensePlate}, som bliver serviceret af {vehicle.Mechanic.FirstName} {vehicle.Mechanic.LastName}.");
            }
        }
    }
    else if (input.ToLower().Trim() == "3")
    {
        Console.Write("Skriv fornav og efternavn på en mekaniker: ");
        string? searchName = Console.ReadLine();
        foreach (var vehicle in registrations)
        {
            if (vehicle.Mechanic.FirstName.ToLower().Trim() == searchName.Split(" ")[0].ToLower().Trim() && vehicle.Mechanic.LastName.ToLower().Trim() == searchName.Split(" ")[1].ToLower().Trim())
            {
                Console.WriteLine($"{vehicle.Mechanic.FirstName} {vehicle.Mechanic.LastName} servicerer en {vehicle.Brand} {vehicle.Model} med nummerplade {vehicle.LicensePlate} for {vehicle.Customer.FirstName} {vehicle.Customer.LastName}.");
            }
        }
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