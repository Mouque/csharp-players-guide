Console.WriteLine("What kind of thing are we talking about?");
// Receive the thing name
string thingName = Console.ReadLine();

Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
// Receive the description of the thing
string description = Console.ReadLine();
/* Adding cool suffixes */
string firstSuffix = "Doom";
string secondSuffix = "3000";
Console.WriteLine("The " + description + " " + thingName + " of " + firstSuffix + " " + secondSuffix + "!");