int estatePointMultiplier = 1;
int duchyPointMultiplier = 3;
int provincePointMultiplier = 6;

Console.WriteLine("Quantos estados o usuário tem? (digite apenas o número)");
int estates = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Quantos ducados o usuário tem? (digite apenas o número)");
int duchies = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Quantas províncias o usuário tem? (digite apenas o número)");
int provinces = Convert.ToInt32(Console.ReadLine());

int totalPoints = 
    (estatePointMultiplier * estates) + 
    (duchyPointMultiplier * duchies) + 
    (provincePointMultiplier * provinces);

Console.WriteLine("O valor de pontos totais do usuário é: " + totalPoints);
