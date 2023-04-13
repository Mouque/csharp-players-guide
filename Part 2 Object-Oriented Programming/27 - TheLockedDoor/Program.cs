Door door = CreateDoor();
while (true)
{
    Console.WriteLine($"The door is {door.CurrentState}.");
    Console.WriteLine("Valid actions: \"open\", \"close\", \"unlock\", \"lock\", and \"set a new password\".");
    Console.Write("What do you want to do? ");
    string input = Console.ReadLine()?.ToLower();

    switch (input)
    {
        default:
            Console.WriteLine("Please, inset a valid action.");
            break;
        case "open":
            door.Open();
            break;
        case "close":
            door.Close();
            break;
        case "unlock":
            door.Unlock();
            break;
        case "lock":
            door.Lock();
            break;
        case "set a new password":
            door.ChangePassword();
            break;

    }
}


Door CreateDoor()
{
    Console.Write("Create a password for the door: ");
    string input = Console.ReadLine();
    
    while (input == null)
    {
        Console.Write("Please, create a password: ");
        input = Console.ReadLine();
    }

    Console.WriteLine("Door created!");
    return new(input);

}

class Door
{
    private string password;
    private State state;
    public string CurrentState
    {
        get
        {
            return state.ToString().ToLower();
        }
    }


    public Door(string doorPassword)
    {
        password = doorPassword;
        state = State.Locked;
    }

    string AskForPassword()
    {
        Console.Write("Insert the door password: ");
        string input = Console.ReadLine();
        if (input != password)
        {
            Console.WriteLine("Wrong password.");
            return "failed";
        }
        return "success";

    }

    public void ChangePassword()
    {
        string verification = AskForPassword();
        if (verification == "success") 
        {
            Console.Write("Create a new password for the door: ");
            string newPassword = Console.ReadLine();
            while (newPassword == null)
            {
                Console.Write("Please, create a password: ");
                newPassword = Console.ReadLine();
            }
            password = newPassword;
            Console.WriteLine("Password successfully changed!");
        }
        else
        {
            Console.WriteLine("Wrong password!");
            ChangePassword();
        }
    }

    public void Open()
    {
        if (state == State.Closed) 
        {
            state = State.Open;
        }
        else
        {
            Console.WriteLine("The door must be closed and unlock to be opened");
        }
    }

    public void Close()
    {
        if (state == State.Open)
        {
            state = State.Closed;
        }
        else
        {
            Console.WriteLine("The door must be open to be closed.");
        }
    }

    public void Unlock()
    {
        if (state == State.Locked)
        {
            string input = AskForPassword();
            if (input == "success")
            {
                state = State.Closed;
            }
        }
    }

    public void Lock()
    {
        if (state == State.Closed)
        {
            state = State.Locked;
        }
        else
        {
            Console.WriteLine("The door must be unlocked and closed to be locked");
        }
    }

    enum State
    {
        Open,
        Closed,
        Locked,
    }
}