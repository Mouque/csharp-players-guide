Console.Title = "Defense of Consolas";

Console.Write("Target Row Number? ");
int targetRowNumber = Convert.ToInt32(Console.ReadLine());
Console.Write("Target Column Number? ");
int targetColumnNumber = Convert.ToInt32(Console.ReadLine());

int leftColumnNumber = targetColumnNumber - 1;
int rightColumnNumber = targetColumnNumber + 1;

int topRowNumber = targetRowNumber + 1;
int bottomRowNumber = targetRowNumber - 1;

string leftDeployCoordinate = $"{leftColumnNumber}, {targetRowNumber}";
string rightDeployCoordinate = $"{rightColumnNumber}, {targetRowNumber}";
string topDeployCoordinate = $"{targetColumnNumber}, {topRowNumber}";
string bottomDeployCoordinate = $"{targetColumnNumber}, {bottomRowNumber}";

Console.BackgroundColor = ConsoleColor.Red;
Console.ForegroundColor = ConsoleColor.Black;

Console.Beep();
Console.WriteLine("Deploy to:");
Console.WriteLine(leftDeployCoordinate);
Console.WriteLine(rightDeployCoordinate);
Console.WriteLine(topDeployCoordinate);
Console.WriteLine(bottomDeployCoordinate);

Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White;