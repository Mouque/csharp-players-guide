
CavernGame game = new();
game.RunGame();


public class CavernGame
{
    CavernGameTable gameTable = new();
    Player player = new();

    public void RunGame()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("You have entered on the cavern of the Fountain of Objects!\nFind the fountain, " +
            "turn it on and return to the entrance! " +
            "You can type \"Help\" to see the list of commands.");
        Console.ForegroundColor = ConsoleColor.White;

        while (true)
        {
            Console.WriteLine("-------------------------------------------------------");

            if (IsGameWin(player, gameTable))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You have turned on the fountain and returned to the entrance! You won!");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            }

            TextHandler.DisplayAndDescribePlayerLocation(player, gameTable);
            GameInput.AskForCommand(player, gameTable);

            
        }
    }

    private bool IsGameWin(Player player, CavernGameTable gameTable)
    {
        if (gameTable.GetEntrancePosition() == (player.Row, player.Column) && gameTable.GetIsFountainOn())
        {
            return true;
        }
        return false;
    }
}

public static class TextHandler
{


    public static void DisplayAndDescribePlayerLocation(Player player, CavernGameTable gameTable)
    {
        Console.WriteLine($"You are in the room at (Row = {player.Row}, Column = {player.Column})");

        

        if (gameTable.GetEntrancePosition() == (player.Row, player.Column))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        if (gameTable.GetFountainPosition() == (player.Row, player.Column))
        {
            if (!gameTable.GetIsFountainOn())
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
        }

        
    }
}

public class GameInput
{
    public static void AskForCommand(Player player, CavernGameTable gameTable)
    {
        Console.Write("What do you want to do? ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string input = Console.ReadLine() ?? "null";
        Console.ForegroundColor = ConsoleColor.White;

        Commands command = input.ToLower() switch
        {
            "move north" => new MoveNorth(),
            "move south" => new MoveSouth(),
            "move east" => new MoveEast(),
            "move west" => new MoveWest(),
            "turn on fountain" => new TurnOnFountain(),
            "help" => new Help(),
            "null" => new InvalidCommand(),
            _ => new InvalidCommand(),
        };

        command.Run(player, gameTable);
    }

}

public interface Commands
{
    public void Run(Player player, CavernGameTable gameTable);

}

public class MoveNorth : Commands
{
    public void Run(Player player, CavernGameTable gameTable) => player.MoveNorth();
}

public class MoveSouth : Commands
{
    public void Run(Player player, CavernGameTable gameTable) => player.MoveSouth();
}

public class MoveEast : Commands
{
    public void Run(Player player, CavernGameTable gameTable) => player.MoveEast();
}

public class MoveWest : Commands
{
    public void Run(Player player, CavernGameTable gameTable) => player.MoveWest();
}

public class TurnOnFountain : Commands
{
    
    public void Run(Player player, CavernGameTable gameTable)
    {
        if (gameTable.GetFountainPosition() == (player.Row, player.Column))
        {
            gameTable.TurnOnFountain();
        }
    }
}

public class Help : Commands
{
    public void Run(Player player, CavernGameTable gameTable)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Here is the list of possible commands:");
        Console.WriteLine("Move North");
        Console.WriteLine("Move South");
        Console.WriteLine("Move East");
        Console.WriteLine("Move West");
        Console.WriteLine("Turn on Fountain");
        Console.WriteLine("Help");
        Console.ForegroundColor = ConsoleColor.White;
    }
}

public class InvalidCommand : Commands
{
    public void Run(Player player, CavernGameTable gameTable) => Console.WriteLine("Invalid command");
}

public class Player
{
    public int Row { get; private set; } = 0;
    public int Column { get; private set; } = 0;

    public void MoveNorth() { if (Row > 0) Row--; }

    public void MoveSouth() { if (Row < 4) Row++; }

    public void MoveEast() { if (Column < 4) Column++; }

    public void MoveWest() { if (Column > 0) Column--; }


}

public class CavernGameTable
{
    private RoomContents[,] tableRoomPositions;
    private bool isFountainOn = false;

    public CavernGameTable()
    {
        tableRoomPositions = new RoomContents[4, 4];
        for (int row = 0; row < tableRoomPositions.GetLength(0); row++)
        {
            for (int column = 0; column < tableRoomPositions.GetLength(1); column++)
            {
                tableRoomPositions[row, column] = RoomContents.Empty;
            }
        }

        tableRoomPositions[0, 0] = RoomContents.Entrance;
        tableRoomPositions[3, 2] = RoomContents.Fountain;
    }

    public (int, int) GetEntrancePosition()
    {
        int entranceRowPosition = 0;
        int entranceColumnPosition = 0;

        for (int row = 0; row < tableRoomPositions.GetLength(0); row++)
        {
            for (int column = 0; column < tableRoomPositions.GetLength(1); column++)
            {
                if (tableRoomPositions[row, column] == RoomContents.Entrance)
                {
                    entranceRowPosition = row;
                    entranceColumnPosition = column;
                }
            }
        }

        return (entranceRowPosition, entranceColumnPosition);
    }

    public (int, int) GetFountainPosition()
    {
        int fountainRowPosition = 0;
        int fountainColumnPosition = 0;

        for (int row = 0; row < tableRoomPositions.GetLength(0); row++)
        {
            for (int column = 0; column < tableRoomPositions.GetLength(1); column++)
            {
                if (tableRoomPositions[row, column] == RoomContents.Fountain)
                {
                    fountainRowPosition = row;
                    fountainColumnPosition = column;
                }
            }
        }

        return (fountainRowPosition, fountainColumnPosition);
    }

    public bool GetIsFountainOn() => isFountainOn;

    public void TurnOnFountain() => isFountainOn = true;

    public void DisplayTableWithPlayer(Player player)
    {
        for (int row = 0; row < 4; row++)
        {
            Console.Write("| ");
            for (int column = 0; column < 4; column++)
            {
                if (player.Row == row && player.Column == column)
                {
                    Console.Write(tableRoomPositions[row, column] + " with Player ");
                    Console.Write(" | ");
                }
                else
                {
                    Console.Write(tableRoomPositions[row, column]);
                    Console.Write(" | ");
                }
            }
            Console.WriteLine("");
        }
        

    }

    enum RoomContents 
    { 
        Empty,
        Entrance,
        Fountain,
    }

}