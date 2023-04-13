CreateDeck();


void CreateDeck()
{
    int cardCount = 0;
    for (int colorNum = 1; colorNum <= 4; colorNum++)
    {
        for (int rankNum = 1; rankNum <= 14; rankNum++)
        {
            Card card = new(rankNum, colorNum);
            cardCount++;
            Console.WriteLine($"{cardCount} - The {card.Color} {card.Rank}");
        }
    }
}

class Card
{
    private CardRank _rank;
    private CardColor _color;

    public string Rank 
    {
        get
        {
            return _rank.ToString();
        }
    }

    public string Color
    { 
        get
        {
            return _color.ToString();
        }
    }

    public Card(int cardRank, int cardColor)
    {
        _rank = (CardRank)cardRank;
        _color = (CardColor)cardColor;
    }
    enum CardRank
    {
        One = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        DollarSign,
        PercentSign,
        Caret,
        Ampersand,
    }

    enum CardColor
    {
        Red = 1,
        Green,
        Blue,
        Yellow,
    }
}