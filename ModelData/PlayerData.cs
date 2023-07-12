namespace MooGameCleanCode2023.ModelData;
public class PlayerData
{
    public string Name { get; private set; }
    public int NGames { get; private set; }

    private int totalGuesses;

    public PlayerData(string name, int guesses)
    {
        Name = name;
        NGames = 1;
        totalGuesses = guesses;
    }

    public void Update(int guesses)
    {
        totalGuesses += guesses;
        NGames++;
    }

    public double Average()
    {
        return (double)totalGuesses / NGames;
    }

    public override bool Equals(object? obj)
    {
        if (obj is PlayerData pd)
        {
            return Name.Equals(pd.Name);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
