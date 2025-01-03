int number;
do
{
    Console.Write( "Enter an integer: " );
} while ( !int.TryParse( Console.ReadLine(), out number ) );
Console.WriteLine( number );