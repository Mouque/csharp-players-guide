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
    Console.WriteLine("Valid commands: on, off, north, south, west, east, stop.");

    Robot robot = new Robot();

    while (true)
    { 
        Console.Write("Command: ");

        string input = AskForCommand();

        if (input == "stop") break;

        IRobotCommand newCommand = input.ToLower() switch
        {
            "on" => new OnCommand(),
            "off" => new OffCommand(),
            "north" => new NorthCommand(),
            "south" => new SouthCommand(),
            "west" => new WestCommand(),
            "east" => new EastCommand(),
            _ => new InvalidCommand(input),
        };
        robot.Commands.Add(newCommand);
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

public class InvalidCommand : IRobotCommand
{
    private string commandToDisplay;

    public InvalidCommand(string command)
    {
        commandToDisplay = command;
    }

    public void Run(Robot robot)
    {
        Console.WriteLine($"Invalid command \"{commandToDisplay}\"");
    }
}

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public List<IRobotCommand> Commands = new List<IRobotCommand>();
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            if (command is InvalidCommand) continue;
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}
