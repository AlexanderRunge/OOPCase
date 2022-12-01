Mechanic MechanicBil = new Mechanic("Martin", "Jensen", 11111111, MechanicTask.Bilmekaniker);
Mechanic MechanicMotorcykel = new Mechanic("Thomas", "Hansen", 22222222, MechanicTask.Motorcykelmekaniker);
Mechanic MechanicLastbil = new Mechanic("Henrik", "Nielsen", 33333333, MechanicTask.Lastbilmekaniker);
List<Mechanic> MechanicList = new() { MechanicBil, MechanicMotorcykel, MechanicLastbil };

Console.WriteLine("Velkommen!");
var runningCheck = true;
do
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

    }
    else if (input.ToLower().Trim() == "2")
    {

    }
    else if (input.ToLower().Trim() == "q")
    {
        
    }
    else
    {
        Console.WriteLine("Du valgte ikke en gyldig muglighed!");
    }
} while(runningCheck);