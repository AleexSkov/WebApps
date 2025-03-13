namespace WebApp2.Logic;

public class Dice
{
    private int eyes;
    private readonly int size;
    private readonly Random r;

    public Dice(int size = 6)
    {
        this.size = size;
        r = new Random();
        Roll();
    }

    public void Roll()
    {
        eyes = r.Next(1, size + 1);
    }

    public int Value => eyes; // Tilføj denne for at få direkte adgang til værdien
}