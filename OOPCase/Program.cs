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
        DateTime registrationYear = new DateTime(2015, 9, 11); //check format og split fra dansk til datetime format
        VehicleType vehicleType = VehicleType.Bil;
        Customer customer = new Customer(customerFirstName, customerLastName, customerPhoneNumber);
        Vehicle vehicle = new Vehicle(customer, vehicleLicensePlate, vehicleBrand, vehicleModel, registrationYear, vehicleType);
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

    }
    else if (input.ToLower().Trim() == "3")
    {

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