/* Reproduce without loops:
     for (int x = 10; x > 0; x--)
     Console.WriteLine(x); 
*/

void Countdown(int number)
{
    Console.WriteLine(number);
    if (number == 1) return;
    Countdown(number - 1);

}

Countdown(15);