using System.Numerics;

public class Game
{
    private List<Player> players = new List<Player>();
    private bool finished = false;
     
    public Game(List<Player> players)
    {
        this.players = players;
    }

    public void start()
    {
        while (!finished)
        {
            for (int i = 0; i < players.Count; i++)
            {
                rollDice(players[i]);

                if (players[i].getScore() == 50)
                {
                    Console.WriteLine(players[i].getName() + " est arrivé sur la case 50 et a gagné !");
                    finished = true;
                    break;
                } else if (players[i].getScore() > 50)
                {
                    players[i].setScore(25);
                }

                Console.WriteLine(players[i].getName() + ", vous êtes sur la case " + players[i].getScore() + "\n");
            }

            if (finished)
                break;
        }
    }

    public static void rollDice(Player player)
    {
        Random random = new Random();
        int dice = random.Next(1, 7);

        Console.WriteLine(player.getName() + " joue... et c'est un " + dice + " !");

        player.setScore(player.getScore() + dice);
    }
}
