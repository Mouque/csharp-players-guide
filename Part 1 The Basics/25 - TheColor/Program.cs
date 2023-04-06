CreateColors();

void CreateColors()
{
    Color color1 = new(192, 22, 0);
    Color color2 = Color.Purple;
    Console.WriteLine($"color1: ({color1.R}, {color1.G}, {color1.B}). color2: ({color2.R}, {color2.G}, {color2.B}).");
}


class Color
{
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }

    public static Color White { get; } = new(255,255,255);

    public static Color Black { get; } = new(0, 0, 0);

    public static Color Red { get; } = new(255, 0, 0);

    public static Color Green { get; } = new(0, 128, 0);

    public static Color Blue { get; } = new(0, 0, 255);

    public static Color Yellow { get; } = new(255, 255, 0);

    public static Color Orange { get; } = new(255, 165, 0);

    public static Color Purple { get; } = new(128, 0, 128);

    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }
}