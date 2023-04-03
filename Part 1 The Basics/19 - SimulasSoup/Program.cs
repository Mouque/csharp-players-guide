int typeChoice;
int mainIngredientChoice;
int seasoningChoice;

(Type soupType, MainIngredient mainIngredient, Seasoning seasoning) soupCombination;

SelectSoupIngredients();
DisplaySoup();

int AskForNumber()
{
    Console.Write("Number: ");
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}

Type GetSoupType()
{
    Console.WriteLine("Pick a soup type:");
    Console.WriteLine($"1: {Type.Soup}");
    Console.WriteLine($"2: {Type.Stew}");
    Console.WriteLine($"3: {Type.Gumbo}");
    typeChoice = AskForNumber();
    return (Type)typeChoice;
}

MainIngredient GetMainIngredient()
{
    Console.WriteLine("Pick a main ingredient:");
    Console.WriteLine($"1: {MainIngredient.Mushrooms}");
    Console.WriteLine($"2: {MainIngredient.Chicken}");
    Console.WriteLine($"3: {MainIngredient.Carrots}");
    Console.WriteLine($"4: {MainIngredient.Potatoes}");
    mainIngredientChoice = AskForNumber();
    return (MainIngredient)mainIngredientChoice;
}

Seasoning GetSeasoning()
{
    Console.WriteLine("Pick a seasoning:");
    Console.WriteLine($"1: {Seasoning.Spicy}");
    Console.WriteLine($"2: {Seasoning.Salty}");
    Console.WriteLine($"3: {Seasoning.Sweet}");
    seasoningChoice = AskForNumber();
    return (Seasoning)seasoningChoice;
}

void SelectSoupIngredients()
{
    soupCombination.soupType = GetSoupType();
    Console.WriteLine("---------------------------------");
    soupCombination.mainIngredient = GetMainIngredient();
    Console.WriteLine("---------------------------------");
    soupCombination.seasoning = GetSeasoning();

}

void DisplaySoup()
{
    Console.WriteLine($"The soup is a {soupCombination.seasoning} {soupCombination.mainIngredient} {soupCombination.soupType}!");
}

enum Type
{
    Soup = 1,
    Stew,
    Gumbo,
}

enum MainIngredient
{
    Mushrooms = 1,
    Chicken,
    Carrots,
    Potatoes,
}

enum Seasoning
{
    Spicy = 1,
    Salty,
    Sweet,
}