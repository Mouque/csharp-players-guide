Console.WriteLine("Welcome.");

Pack pack = new(5, 8f, 5f);

Console.WriteLine("Pack created.");
while (true)
{
    Console.WriteLine("-------------------------------------");
    Console.WriteLine(
    $"Items Slots: {pack.CurrentItemSlots}/{pack.ItemSlotsLimit} | " +
    $"Weight Capacity: {pack.CurrentWeight}/{pack.WeightLimit} | " +
    $"Volume Capacity: {pack.CurrentVolume}/{pack.VolumeLimit}"
                 );
    Console.WriteLine("Which item do you want to add?");
    Console.WriteLine("1: Arrow (Weight: 0.1 Volume: 0.05");
    Console.WriteLine("2: Bow (Weight: 1 Volume: 4");
    Console.WriteLine("3: Rope (Weight: 1 Volume: 1.5");
    Console.WriteLine("4: Water (Weight: 2 Volume: 3");
    Console.WriteLine("5: Food (Weight: 1 Volume: 0.5");
    Console.WriteLine("6: Sword (Weight: 5 Volume: 3");
    Console.Write("Number: ");
    string input = Console.ReadLine();
    while (input == null)
    {
        Console.Write("Not a number, try again: ");
        input = Console.ReadLine();
    }
    switch (Convert.ToInt32(input))
    {
        default:
            Console.WriteLine("Not a valid option");
            break;
        case 1:
            Arrow arrow = new();
            string attempt = pack.Add(arrow) ? "Arrow added" : "Arrow couldn't be added";
            Console.WriteLine(attempt);
            break;
        case 2:
            Bow bow = new();
            attempt = pack.Add(bow) ? "Bow added" : "Bow couldn't be added";
            Console.WriteLine(attempt);
            break;
        case 3:
            Rope rope = new();
            attempt = pack.Add(rope) ? "Rope added" : "Rope couldn't be added";
            Console.WriteLine(attempt);
            break;
        case 4:
            Water water = new();
            attempt = pack.Add(water) ? "Water added" : "Water couldn't be added";
            Console.WriteLine(attempt);
            break;
        case 5:
            Food food = new();
            attempt = pack.Add(food) ? "Food added" : "Food couldn't be added";
            Console.WriteLine(attempt);
            break;
        case 6:
            Sword sword = new();
            attempt = pack.Add(sword) ? "Sword added" : "Sword couldn't be added";
            Console.WriteLine(attempt);
            break;
    }
}






class Pack
{
    public int ItemSlotsLimit { get; private set; }
    public float WeightLimit { get; private set; }
    public float VolumeLimit { get; private set; }
    public int CurrentItemSlots { get; private set; }
    public float CurrentWeight { get; private set; }
    public float CurrentVolume { get; private set; }

    public InventoryItem[] ItemList { get; private set; }

    public Pack(int itemSlotsLimit, float weightLimit, float volumeLimit)
    {
        ItemSlotsLimit = itemSlotsLimit;
        WeightLimit = weightLimit;
        VolumeLimit = volumeLimit;
        ItemList = new InventoryItem[itemSlotsLimit];
    }

    public bool Add(InventoryItem item)
    {
        if (CurrentWeight + item.Weight > WeightLimit)
        {
            Console.WriteLine("Too much weight");
            return false;
        }

        if (CurrentVolume + item.Volume > VolumeLimit)
        {
            Console.WriteLine("Too much volume");
            return false;
        }
        if (CurrentItemSlots == ItemSlotsLimit)
        {
            Console.WriteLine("Pack is full");
            return false;
        }

        CurrentWeight += item.Weight;
        CurrentVolume += item.Volume;
        for (int i = 0; i < ItemList.Length; i++)
        {
            if (ItemList[i] == null)
            {
                ItemList[i] = item;
                CurrentItemSlots++;
                break;
            }
            else continue;
        }
        return true;
    }
}

class Sword : InventoryItem { public Sword() : base(5f, 3f) { } }
class Food : InventoryItem { public Food() : base(1f, 0.5f) { } }
class Water : InventoryItem { public Water() : base(2f, 3f) { } }
class Rope : InventoryItem { public Rope() : base(1f, 1.5f) { } }
class Bow : InventoryItem { public Bow() : base(1f, 4f) { } }
class Arrow : InventoryItem { public Arrow() : base(0.1f, 0.05f) { } }
class InventoryItem
{

    public float Weight { get; private set; }
    public float Volume { get; private set; }

    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}