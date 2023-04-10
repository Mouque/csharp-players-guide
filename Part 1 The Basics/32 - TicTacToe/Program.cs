TicTacToeGame game = new();

game.StartGame();

class TicTacToeGame
{
    RoundHandler roundHandler = new();
    Table table = new();
    int round;

    public void StartGame()
    {
        Console.WriteLine("Let's play Tic-Tac-Toe!");
        Console.WriteLine("Remember the square positions below, you will use their numbers to draw the crosses and circles!\n");
        Console.WriteLine(" 7 | 8 | 9 ");
        Console.WriteLine("---+---+---");
        Console.WriteLine(" 4 | 5 | 6 ");
        Console.WriteLine("---+---+---");
        Console.WriteLine(" 1 | 2 | 3 \n");
        Console.WriteLine("-------------------------\n");
        Console.WriteLine("Let's Begin!");

        while (true)
        {
            Console.WriteLine($"\nIt's {roundHandler.CurrentTurn} turn!");

            Console.WriteLine($" {table.Position7} | {table.Position8} | {table.Position9} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {table.Position4} | {table.Position5} | {table.Position6} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {table.Position1} | {table.Position2} | {table.Position3} \n");

            if (roundHandler.CurrentTurn == "Cross")
            {
                int desiredSquare = RoundHandler.ReceivePlayerDesiredSquare();
                while (!table.TryDrawCross(desiredSquare))
                {
                    Console.WriteLine("Square occupied! Try again!");
                    desiredSquare = RoundHandler.ReceivePlayerDesiredSquare();
                }
            }
            if (roundHandler.CurrentTurn == "Circle")
            {
                int desiredSquare = RoundHandler.ReceivePlayerDesiredSquare();
                while (!table.TryDrawCircle(desiredSquare))
                {
                    Console.WriteLine("Square occupied! Try again!");
                    desiredSquare = RoundHandler.ReceivePlayerDesiredSquare();
                }
            }
            bool gameState = table.CheckGameEnd();
            if (gameState)
            {
                Console.WriteLine($"\n{table.Winner} won!\n");
                Console.WriteLine($" {table.Position7} | {table.Position8} | {table.Position9} ");
                Console.WriteLine("---+---+---");
                Console.WriteLine($" {table.Position4} | {table.Position5} | {table.Position6} ");
                Console.WriteLine("---+---+---");
                Console.WriteLine($" {table.Position1} | {table.Position2} | {table.Position3} \n");
                break;
            }
            roundHandler.ChangeTurn();

        }
    }
}

class RoundHandler
{
    Turn _turn;
    public string CurrentTurn
    {
        get
        {
            return Convert.ToString(_turn);
        }
    }

    public RoundHandler()
    {
        _turn = Turn.Cross;
    }

    public void ChangeTurn()
    {
        _turn = _turn == Turn.Cross ? Turn.Circle : Turn.Cross;
    }

    public static int ReceivePlayerDesiredSquare()
    {
        Console.Write("What square do you want to play in? ");
        string input = Console.ReadLine() ?? "10";
        int square = Convert.ToInt32(input);

        while (square < 1 || square > 9)
        {
            Console.Write("Insert a valid square, between 1 and 9: ");
            input = Console.ReadLine() ?? "10";
            square = Convert.ToInt32(input);
        }

        return square;
    }

    enum Turn { Cross, Circle, }
}

class Table
{
    private bool[] isPositionOccupied = new bool[9];
    private char[] positions = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

    string _winner;

    public string Winner
    {
        get
        {
            return _winner;
        }
    }

    public char Position1 { get => positions[0]; }
    public char Position2 { get => positions[1]; }
    public char Position3 { get => positions[2]; }
    public char Position4 { get => positions[3]; }
    public char Position5 { get => positions[4]; }
    public char Position6 { get => positions[5]; }
    public char Position7 { get => positions[6]; }
    public char Position8 { get => positions[7]; }
    public char Position9 { get => positions[8]; }

    public bool TryDrawCross(int position)
    {
        if (isPositionOccupied[position - 1])
        {
            return false;
        }
        else
        {
            positions[position - 1] = 'X';
            isPositionOccupied[position - 1] = true;
            return true;
        }
    }
    public bool TryDrawCircle(int position)
    {
        if (isPositionOccupied[position - 1])
        {
            return false;
        }
        else
        {
            positions[position - 1] = 'O';
            isPositionOccupied[position - 1] = true;
            return true;
        }
    }


    public bool CheckGameEnd()
    {
        if
            (
            (Position7.Equals('X') && Position8.Equals('X') && Position9.Equals('X')) ||

            (Position4.Equals('X') && Position5.Equals('X') && Position6.Equals('X')) ||

            (Position1.Equals('X') && Position2.Equals('X') && Position3.Equals('X')) ||

            (Position7.Equals('X') && Position4.Equals('X') && Position1.Equals('X')) ||

            (Position8.Equals('X') && Position5.Equals('X') && Position2.Equals('X')) ||

            (Position8.Equals('X') && Position5.Equals('X') && Position2.Equals('X')) ||

            (Position9.Equals('X') && Position6.Equals('X') && Position3.Equals('X')) ||

            (Position7.Equals('X') && Position5.Equals('X') && Position3.Equals('X')) ||

            (Position9.Equals('X') && Position5.Equals('X') && Position1.Equals('X'))
            )
        {
            _winner = "Cross";
            return true;
        }

        if (
            (Position7.Equals('O') && Position8.Equals('O') && Position9.Equals('O')) ||

            (Position4.Equals('O') && Position5.Equals('O') && Position6.Equals('O')) ||

            (Position1.Equals('O') && Position2.Equals('O') && Position3.Equals('O')) ||

            (Position7.Equals('O') && Position4.Equals('O') && Position1.Equals('O')) ||

            (Position8.Equals('O') && Position5.Equals('O') && Position2.Equals('O')) ||

            (Position8.Equals('O') && Position5.Equals('O') && Position2.Equals('O')) ||

            (Position9.Equals('O') && Position6.Equals('O') && Position3.Equals('O')) ||

            (Position7.Equals('O') && Position5.Equals('O') && Position3.Equals('O')) ||

            (Position9.Equals('O') && Position5.Equals('O') && Position1.Equals('O'))
            )
        {
            _winner = "Circle";
            return true;
        }

        return false;

    }
}

