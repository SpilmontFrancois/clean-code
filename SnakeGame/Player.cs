public class Player
{
    public string Name { get; }
    public int score { get; set; }

    public Player(string name, int score)
    {
        this.Name = name;
        this.score = score;
    }
}