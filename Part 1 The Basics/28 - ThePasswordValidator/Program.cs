CheckPasswordLoop();
static string AskForPassword()
{
    Console.Write("Insert a password to validate: ");
    string password = Console.ReadLine();
    while (password is null)
    {
        Console.Write("Please, insert a valid password to validate: ");
        password = Console.ReadLine();
    }
    return password;
}

static void CheckPasswordLoop()
{
    PasswordValidator passwordValidator = new();
    while (true)
    {
        string password = AskForPassword();
        string result = passwordValidator.IsPasswordValid(password) ? "Valid password!" : "Invalid password!";
        Console.WriteLine(result);
    }
}


class PasswordValidator
{

    public bool IsPasswordValid(string password)
    {
        bool hasUppercase = false;
        bool hasLowercase = false;
        bool hasNumber = false;

        if (password == null) return false;
        if (password.Length < 6 || password.Length > 13) return false;

        foreach (char letter in password)
        {
            if (letter == 'T' || letter == '&')
            {
                return false;
            }

            if (Char.IsUpper(letter)) hasUppercase = true;
            if (Char.IsLower(letter)) hasLowercase = true;
            if (Char.IsNumber(letter)) hasNumber = true;
        }

        if (hasUppercase && hasLowercase && hasNumber) return true;

        return false;
    }
}