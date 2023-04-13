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
    Console.WriteLine("Welcome!");
    Console.WriteLine("What are you buying?");
    Console.WriteLine("1: Beginner Arrow");
    Console.WriteLine("2: Marksman Arrow");
    Console.WriteLine("3: Elite Arrow");
    Console.WriteLine("4: Custom Arrow (you can decide the components)");
    Console.Write("Option number: ");
    int input = AskForNumberInRange(1, 4);

    switch (input)
    {
        case 1:
            Arrow beginnerArrow = Arrow.CreateBeginnerArrow();
            Console.WriteLine($"A Beginner Arrow will cost {beginnerArrow.GetCost()} gold!");
            break;
        case 2:
            Arrow marksmanArrow = Arrow.CreateMarksmanArrow();
            Console.WriteLine($"An Marksman Arrow will cost {marksmanArrow.GetCost()} gold!");
            break;
        case 3:
            Arrow eliteArrow = Arrow.CreateEliteArrow();
            Console.WriteLine($"An Elite Arrow will cost {eliteArrow.GetCost()} gold!");
            break;
        case 4:
            Console.WriteLine("---------------------------");
            CreateCustomArrow();
            break;
        
    }
}

void CreateCustomArrow()
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

    public Arrow(int desiredArrowheadOption, int desiredshaftLength, int desiredFletchingOption)
    {
        ArrowheadType = (Arrowhead)desiredArrowheadOption;
        Length = desiredshaftLength;
        FletchingType = (Fletching)desiredFletchingOption;
    }

    public static Arrow CreateEliteArrow()
    {
        Arrowhead arrowheadType = Arrowhead.Steel;
        int length = 95;
        Fletching fletching = Fletching.Plastic;
        return new Arrow((int)arrowheadType, length, (int)fletching);
    }
    public static Arrow CreateBeginnerArrow()
    {
        Arrowhead arrowheadType = Arrowhead.Wood;
        int length = 75;
        Fletching fletching = Fletching.GooseFeathers;
        return new Arrow((int)arrowheadType, length, (int)fletching);
    }
    public static Arrow CreateMarksmanArrow()
    {
        Arrowhead arrowheadType = Arrowhead.Steel;
        int length = 65;
        Fletching fletching = Fletching.GooseFeathers;
        return new Arrow((int)arrowheadType, length, (int)fletching);
    }

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