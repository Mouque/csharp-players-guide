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
        tableRoomPositions[0, 2] = RoomContents.Fountain;
    }

    public void DisplayTable()
    {

    }

    enum RoomContents 
    { 
        Empty,
        Entrance,
        Fountain,
    }

}