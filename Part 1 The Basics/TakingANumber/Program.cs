int AskForNumber(string textToDisplay)
{
    Console.WriteLine(textToDisplay);
    Console.Write("Number: ");
    int number = Convert.ToInt32(Console.ReadLine());

    return number;
}

int AskForNumberInRange(string textToDisplay, int minRange, int maxRange)
{
    Console.WriteLine(textToDisplay);
    Console.Write("Number: ");
    int number = Convert.ToInt32(Console.ReadLine());
    while (number < minRange || number > maxRange)
    {
        Console.Write("Out of range, try again: ");
        number = Convert.ToInt32(Console.ReadLine());
    }
    return number;
}

AskForNumberInRange("Gimme a number between 8 and 10", 8, 10);