MainMethod();

void MainMethod()
{
    ColoredItem<Sword> sword = new(new Sword(), ConsoleColor.Blue);
    sword.Display();
    ColoredItem<Bow> bow = new(new Bow(), ConsoleColor.Red);
    bow.Display();
    ColoredItem<Axe> axe = new(new Axe(), ConsoleColor.Green);
    axe.Display();
}


public class Sword { }
public class Bow { }
public class Axe { }

public class ColoredItem<T>
{
    public T Item { get; }
    public ConsoleColor Color { get; }

    public ColoredItem(T item, ConsoleColor color)
    {
        Item = item;
        Color = color;
    }

    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(Item.ToString());
    }
}