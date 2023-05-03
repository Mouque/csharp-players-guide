CavernGameTable game = new();
Player player = new Player();
game.DisplayTableWithPlayer(player);
player.MoveSouth();
Console.WriteLine("");
game.DisplayTableWithPlayer(player);


public class GameInput
{
    
}

public class Player
{
    public int Row { get; private set; } = 0;
    public int Column { get; private set; } = 0;

    public void MoveNorth() { if (Row > 0) Row--; }

    public void MoveSouth() { if (Row < 4) Row++; }

    public void MoveEast() { if (Column < 4) Column++; }

    public void MoveWest() { if (Column > 4) Column--; }


}

public class CavernGameTable
{
    private RoomContents[,] tableRoomPositions;

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