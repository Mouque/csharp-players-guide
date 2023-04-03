Console.Write("User 1, enter a number between 0 and 100: ");

int pickedNumber = Convert.ToInt32(Console.ReadLine());

Console.Clear();

bool isNumberGuessed = false;

Console.WriteLine("User 2, guess the number.");

while (!isNumberGuessed)
{
    Console.Write("What is your guess? ");
    int guess = Convert.ToInt32(Console.ReadLine());

    if (guess > pickedNumber) Console.WriteLine($"{guess} is too high.");
    else if (guess < pickedNumber) Console.WriteLine($"{guess} is too low");
    else
    {
        Console.WriteLine("You guessed the number!");
        isNumberGuessed = true;
    }
}