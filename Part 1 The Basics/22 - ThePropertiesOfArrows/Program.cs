CreateArrow();

int AskForNumberInRange(int minRange, int maxRange)
{
    int number = Convert.ToInt32(Console.ReadLine());
    while (number < minRange || number > maxRange)
    {
        Console.Write($"Please, pick a number between {minRange} and {maxRange}: ");
        number = Convert.ToInt32(Console.ReadLine());
    }
    return number;
}

void CreateArrow()
{
    Console.WriteLine("Select the components of the arrow:");
    Console.WriteLine("Arrowhead options:");
    Console.WriteLine("1: Steel (10 gold)");
    Console.WriteLine("2: Obsidian (5 gold)");
    Console.WriteLine("3: Wood (3 gold)");
    Console.Write("Option number: ");
    int arrowheadChoice = AskForNumberInRange(1, 3);

    Console.WriteLine("---------------------------");

    Console.WriteLine("Fletching options:");
    Console.WriteLine("1: Plastic (10 gold)");
    Console.WriteLine("2: Turkey Feathers (5 gold)");
    Console.WriteLine("3: Goose Feathers (3 gold)");
    Console.Write("Option number: ");
    int fletchingChoice = AskForNumberInRange(1, 3);

    Console.WriteLine("---------------------------");

    Console.WriteLine("Shaft (between 60cm and 100cm long, 0.05 gold per centimeter)");
    Console.Write("Lenght (only the number): ");
    int shaftLenghtChoice = AskForNumberInRange(60, 100);

    Arrow arrow = new(arrowheadChoice, shaftLenghtChoice, fletchingChoice);

    Console.WriteLine($"Your {arrow.Length}-centimeters-long arrow with " +
        $"{arrow.ArrowheadType} arrowhead and {arrow.FletchingType} fletching " +
        $"will cost {arrow.GetCost()} gold.");
}

class Arrow
{
    public Arrowhead ArrowheadType { get; private set; }
    public Fletching FletchingType { get; private set; }
    public int Length { get; private set; }

    public float GetCost()
    {
        float arrowheadPrice = ArrowheadType switch
        {
            Arrowhead.Steel => 10f,
            Arrowhead.Obsidian => 5f,
            Arrowhead.Wood => 3f,
        };
        float fletchingPrice = FletchingType switch
        {
            Fletching.Plastic => 10f,
            Fletching.TurkeyFeathers => 5f,
            Fletching.GooseFeathers => 3f,
        };
        float shaftPrice = Length * 0.05f;

        float cost = arrowheadPrice + shaftPrice + fletchingPrice;
        return cost;
    }

    public Arrow(int desiredArrowheadOption, int desiredshaftLength, int desiredFletchingOption)
    {
        ArrowheadType = (Arrowhead)desiredArrowheadOption;
        Length = desiredshaftLength;
        FletchingType = (Fletching)desiredFletchingOption;
    }

    public enum Arrowhead
    {
        Steel = 1,
        Obsidian,
        Wood,
    }

    public enum Fletching
    {
        Plastic = 1,
        TurkeyFeathers,
        GooseFeathers,
    }
}