int currentRound = 1;
int cityMaxHealth = 15;
int cityCurrentHealth = 15;
int manticoreMaxHealth = 10;
int manticoreCurrentHealth = 10;
int cannonDamage;

int manticorePosition;
int cannonFiredPosition;


// Ask for a number to the player
int AskForNumberInRange(string textToDisplay, int minRange, int maxRange)
{
    Console.WriteLine(textToDisplay);
    Console.Write($"Number between {minRange} and {maxRange}: ");
    int number = Convert.ToInt32(Console.ReadLine());
    if (number < minRange || number > maxRange)
    {
        Console.Write("Out of range, try again: ");
        number = Convert.ToInt32(Console.ReadLine());
    }
    return number;
}

// Show round status at the beginning of the round
void ShowStatus()
{
    string status = $"Round: {currentRound} City: {cityCurrentHealth}/{cityMaxHealth}  Manticore: {manticoreCurrentHealth}/{manticoreMaxHealth}";
    Console.WriteLine(status);
}

// Compute the cannon damage of the round
int ComputeDamage()
{

    if (currentRound % 3 == 0 && currentRound % 5 == 0)
    {
        return cannonDamage = 10;
    }
    else if (currentRound % 5 == 0 || currentRound % 3 == 0)
    {
        return cannonDamage = 3;
    }
    else return cannonDamage = 1;
}

// Show to the player how much damage the cannon will deal at that round
void ShowExpectedDamage()
{
    if (cannonDamage == 10) Console.ForegroundColor = ConsoleColor.Blue;
    if (cannonDamage == 3)
    {
        if (currentRound % 5 == 0) Console.ForegroundColor = ConsoleColor.Yellow;
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
    Console.WriteLine($"The cannon is expected to deal {cannonDamage} damage this round");
    Console.ForegroundColor = ConsoleColor.White;
}

// Compute if the player 2 hit the manticore and show feedback. Also reduce the city health if shot missed
void ComputeAndShowRoundResult()
{

    if (manticorePosition == cannonFiredPosition)
    {
        Console.WriteLine("That round was a DIRECT HIT!");
        ComputeDamage();
        manticoreCurrentHealth -= cannonDamage;
    }
    else if (manticorePosition > cannonFiredPosition)
    {
        Console.WriteLine("That round FELL SHORT of the target.");
    }
    else if (manticorePosition < cannonFiredPosition)
    {
        Console.WriteLine("That round OVERSHOT the target.");
    }
    cityCurrentHealth--;
    currentRound++;
}

// Run the game calling the methods
void RunGame()
{
    manticorePosition = new Random().Next(0, 100) + 1;
    Console.WriteLine("The Manticore is here! Destroy it!");
    Console.WriteLine("-----------------------------------------------------------");

    while (cityCurrentHealth > 0 && manticoreCurrentHealth > 0)
    {
        ShowStatus();
        ComputeDamage();
        ShowExpectedDamage();
        cannonFiredPosition = AskForNumberInRange("Enter desired cannon range: ", 0, 100);
        ComputeAndShowRoundResult();
        Console.WriteLine("-----------------------------------------------------------");
    }

    if (cityCurrentHealth <= 0)
    {
        Console.WriteLine("Consolas has been destroyed!!");
    }
    else if (manticoreCurrentHealth <= 0)
    {
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
    }
}

RunGame();