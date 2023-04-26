MainMethod();

string AskForCommand()
{
    string command = Console.ReadLine();
    while (command == null)
    {
        Console.Write("Invalid command, try again: ");
        command = Console.ReadLine();
    }
    return command;
}

void MainMethod()
{
    Console.WriteLine("Valid commands: on, off, north, south, west, east.");

    Robot robot = new Robot();

    for (int index = 0; index < robot.Commands.Length; index++)
    {
        switch (index)
        {
            case 0:
                Console.Write("First command: ");
                break;
            case 1:
                Console.Write("Second command: ");
                break;
            case 2:
                Console.Write("Third command: ");
                break;
        }

        string input = AskForCommand();
        IRobotCommand newCommand = input switch
        {
            "on" => new OnCommand(),
            "off" => new OffCommand(),
            "north" => new NorthCommand(),
            "south" => new SouthCommand(),
            "west" => new WestCommand(),
            "east" => new EastCommand(),
        };
        robot.Commands[index] = newCommand;
    }

    robot.Run();
}

public interface IRobotCommand
{
    public void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y++;
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y--;
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X--;
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X++;
    }
}

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}
