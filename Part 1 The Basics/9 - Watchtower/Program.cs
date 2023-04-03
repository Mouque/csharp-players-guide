Console.WriteLine
    ("Enter the X position value of the enemy relative to the watchtower: ");
float enemyXPosition = Convert.ToSingle(Console.ReadLine());

Console.WriteLine
    ("Enter the Y position value of the enemy relative to the watchtower: ");
float enemyYPosition = Convert.ToSingle(Console.ReadLine());

bool isEnemyToTheNorth = enemyYPosition > 0f;
bool isEnemyToTheSouth = enemyYPosition < 0f;
bool isEnemyToTheEast = enemyXPosition > 0f;
bool isEnemyToTheWest = enemyXPosition < 0f;

if (isEnemyToTheNorth)
{
    if (isEnemyToTheEast) // Check if it is Northeast
    {
        Console.WriteLine("The enemy is to the Northeast!");
    }
    else if (isEnemyToTheWest) // Check if it is Northwest
    {
        Console.WriteLine("The enemy is to the Northwest!");
    }
    else // It is to the North
    {
        Console.WriteLine("The enemy is to the North!");
    }
}
else if (isEnemyToTheSouth)
{
    if (isEnemyToTheEast) // Check if it is Southeast
    {
        Console.WriteLine("The enemy is to the Southeast!");
    }
    else if (isEnemyToTheWest) // Check if it is Southwest
    {
        Console.WriteLine("The enemy is to the Southwest!");
    }
    else // It is to the South
    {
        Console.WriteLine("The enemy is to the South!");
    }
}
else // It is here
{
    Console.WriteLine("The enemy is here!!");
}