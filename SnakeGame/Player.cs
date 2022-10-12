public class Player
{
    private string name;
    private int score;

    public Player(string name, int score)
    {
        this.name = name;
        this.score = score;
    }

    public string getName()
    {
        return name;
    }

    public int getScore()
    {
        return score;
    }

    public void setScore(int newScore)
    {
        score = newScore;
    }
}