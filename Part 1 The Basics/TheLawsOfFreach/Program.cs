int[] array = new int[5] {5, 5, 5, 5, 5};

int currentSmallest = int.MaxValue;
foreach (int number in array)
{
    if (number < currentSmallest)
    currentSmallest = number;
}
Console.WriteLine($"O menor número da array é {currentSmallest}");

float totalSum = 0f;
foreach (int number in array)
{
    totalSum += number;
}

float average =  (float)(totalSum / (float)array.Length);
Console.WriteLine($"A média de todos os números da array é {average}");