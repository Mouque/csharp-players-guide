MainMethod();
void MainMethod()
{
    Coordinate point1 = new(1, 2);
    Coordinate point2 = new(3, 4);
    Coordinate point3 = new(2, 2);

    Console.WriteLine(IsAdjacent(point1, point2));
    Console.WriteLine(IsAdjacent(point1, point3));
}

bool IsAdjacent(Coordinate point1, Coordinate point2)
{
    if ((point1.X + 1 == point2.X || point1.X - 1 == point2.X) && point1.Y == point2.Y) return true;
    if ((point1.Y + 1 == point2.Y || point1.Y - 1 == point2.Y) && point1.X == point2.X) return true;

    return false;
    
}

public struct Coordinate
{
    public readonly int X;
    public readonly int Y;

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
}