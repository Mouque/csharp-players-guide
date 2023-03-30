Console.WriteLine("Escreva a quantidade de ovos de chocolate: (apenas o número)");

int eggsQuantity = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Para quantas irmãs serão divididos os ovos? (digite apenas o número)");

int sisters = Convert.ToInt32(Console.ReadLine());

int remainingEggs = eggsQuantity % sisters;
int eggsQuantityForEachSister = (eggsQuantity - remainingEggs) / sisters;

if (eggsQuantityForEachSister <= 0)
{
    Console.WriteLine("Nenhum ovo será dado para nenhuma irmã.");
    if (remainingEggs > 0)
    {
        Console.WriteLine("Dê os ovos ao Duckbear.");
    }

}

if (eggsQuantityForEachSister > 0 && remainingEggs == 0)
{
    Console.WriteLine("Nenhum ovo será dado ao Duckbear. Assim, cada irmã ficará com " + eggsQuantityForEachSister + " ovos.");
}
else if (eggsQuantityForEachSister > 0 && remainingEggs > 0)
{
    Console.WriteLine("Serão dados " + remainingEggs + " ovos ao Duckbear. Assim, cada irmã ficará com " + eggsQuantityForEachSister + " ovos.");
}



