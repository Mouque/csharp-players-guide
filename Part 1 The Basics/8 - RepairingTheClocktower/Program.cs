Console.Write("Insira um número inteiro, sem decimais: ");
int inputNumber = Convert.ToInt32(Console.ReadLine());

if ((inputNumber % 2) == 0)
{
    // number is even
    Console.WriteLine("Tick");
}
else
{
    // number is odd
    Console.WriteLine("Tock");
}