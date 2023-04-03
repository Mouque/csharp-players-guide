Console.WriteLine("The following items are available:");
Console.WriteLine("1 - Rope");
Console.WriteLine("2 - Torches");
Console.WriteLine("3 - Climbing Equipment");
Console.WriteLine("4 - Clean Water");
Console.WriteLine("5 - Machete");
Console.WriteLine("6 - Canoe");
Console.WriteLine("7 - Food Supplies");

Console.Write("What number do you want to see the price of? ");
int choice = Convert.ToInt32(Console.ReadLine());

Console.Write("What is your name? ");
string name = Console.ReadLine().ToLower();

string priceMessage;

if (name == "henrique")
{
    priceMessage = choice switch
    {
        1 => "Rope costs 5 gold",
        2 => "Torches cost 7.5 gold",
        3 => "Climbing Equipment costs 12.5 gold",
        4 => "Clean Water costs 0.5 gold",
        5 => "Machete costs 10 gold",
        6 => "Canoe costs 100 gold",
        7 => "Food Supplies cost 0.5 gold",
        _ => "Number does not correspond to an item",
    };
}
else 
{
    priceMessage = choice switch
    {
        1 => "Rope costs 10 gold",
        2 => "Torches cost 15 gold",
        3 => "Climbing Equipment costs 25 gold",
        4 => "Clean Water costs 1 gold",
        5 => "Machete costs 20 gold",
        6 => "Canoe costs 200 gold",
        7 => "Food Supplies cost 1 gold",
        _ => "Number does not correspond to an item",
    };
}

Console.WriteLine(priceMessage);