namespace WebApp2.Logic;

public class DiceCup
{
    public List<Dice> Dices { get; private set; }

    public DiceCup(int diceCount = 2) // Standard 2 terninger
    {
        Dices = new List<Dice>();
        for (int i = 0; i < diceCount; i++)
        {
            Dices.Add(new Dice());
        }
    }

    public void Roll()
    {
        foreach (var dice in Dices)
        {
            dice.Roll();
        }
    }
}