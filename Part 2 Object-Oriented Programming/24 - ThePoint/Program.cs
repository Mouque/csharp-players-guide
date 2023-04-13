CreatePoints();

void CreatePoints()
{
    Point point1 = new Point(2,3);
    Point point2 = new Point(-4,0);

    Console.WriteLine($"O primeiro ponto foi criado em ({point1.X},{point1.Y}), e o segundo em ({point2.X},{point2.Y})");
}

class Point
{
    public float X { get; }
    public float Y { get; }
    public Point(float CoordX, float CoordY)
    {
        X = CoordX;
        Y = CoordY;
    }

    public Point() : this(0, 0) { }
}