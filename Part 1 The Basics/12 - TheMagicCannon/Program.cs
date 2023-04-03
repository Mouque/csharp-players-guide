Console.WriteLine("The Magic Cannon will fire these ammo at each turn: ");

for (int turn = 1; turn <= 100; turn++)
{
    if (turn % 3 == 0 && turn % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"{turn}: Combined! Electric and Fire!!");
    }
    else if (turn % 3 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{turn}: Fire");
    }
    else if (turn % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{turn}: Electric");

    }
    else
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{turn}: Normal");
    }

}