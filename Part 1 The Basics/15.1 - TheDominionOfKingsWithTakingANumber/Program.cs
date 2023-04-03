int estatePointMultiplier = 1;
int duchyPointMultiplier = 3;
int provincePointMultiplier = 6;

int AskForNumber(string textToDisplay)
{
    Console.WriteLine(textToDisplay);
    Console.Write("Number: ");
    int number = Convert.ToInt32(Console.ReadLine());

    return number;
}

int estates = AskForNumber("Quantos estados o usuário tem? (digite apenas o número)");

int duchies = AskForNumber("Quantos ducados o usuário tem? (digite apenas o número)");

int provinces = AskForNumber("Quantas províncias o usuário tem? (digite apenas o número)");

int totalPoints =
    (estatePointMultiplier * estates) +
    (duchyPointMultiplier * duchies) +
    (provincePointMultiplier * provinces);

Console.WriteLine("O valor de pontos totais do usuário é: " + totalPoints);

