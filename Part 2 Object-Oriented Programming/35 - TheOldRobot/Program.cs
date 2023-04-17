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

    for (int index = 0; index < robot.Commands.Length;  index++)
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
        RobotCommand newCommand = input switch
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

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot) 
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand 
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y++;
    }
}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y--;
    }
}

public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X--;
    }
}
    
public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X++;
    }
}

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}
