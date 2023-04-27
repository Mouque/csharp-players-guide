MainMethod();

void MainMethod()
{
    Sword basicSword = new(SwordMaterials.Iron, GemstoneTypes.None, 1, 3);
    Sword eliteSword = basicSword with { GemstoneType = GemstoneTypes.Sapphire };
    Sword mythicalSword = basicSword with { SwordMaterial = SwordMaterials.Binarium, GemstoneType = GemstoneTypes.Bitstone };

    Console.WriteLine(basicSword);
    Console.WriteLine(eliteSword);
    Console.WriteLine(mythicalSword);
}

public record Sword(SwordMaterials SwordMaterial, GemstoneTypes GemstoneType, int Length, int CrossguardWidth);

public enum SwordMaterials
{
    Wood,
    Bronze,
    Iron,
    Steel,
    Binarium,
}

public enum GemstoneTypes
{
    None,
    Emerald,
    Amber,
    Sapphire,
    Diamond,
    Bitstone,
}
