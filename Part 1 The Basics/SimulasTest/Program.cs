State current = State.Locked;
string stateString = "locked";

void Open()
{
    if (current == State.Closed)
    {
        current = State.Open;
    }
    else
    {
        Console.WriteLine("Chest must be closed and unlocked to be open.");
    }
}

void Close()
{
    if (current == State.Open)
    {
        current = State.Closed;
    }
    else
    {
        Console.WriteLine("Chest must be open to be closed.");
    }
}

void Lock()
{
    if (current == State.Closed)
    {
        current = State.Locked;
    }
    else
    {
        Console.WriteLine("Chest must be closed to be locked.");
    }

}

void Unlock()
{
    if (current == State.Locked)
    {
        current = State.Closed;
    }
    else
    {
        Console.WriteLine("Chest must be locked to be unlocked.");
    }

}

while (true)
{
    switch (current)
    {
        case State.Open:
            stateString = "open";
            break;
        case State.Closed:
            stateString = "unlocked";
            break;
        case State.Locked:
            stateString = "locked";
            break;
    }
    Console.Write($"The chest is {stateString}. What do you want to do? ");
    string action = Console.ReadLine().ToLower();

    switch (action)
    {
        default:
            Console.WriteLine("Invalid action.");
            break;
        case "open":
            Open();
            break;
        case "unlock":
            Unlock();
            break;
        case "lock":
            Lock();
            break;
        case "close":
            Close();
            break;
    }
}

enum State
{
    Open,
    Closed,
    Locked,
}