using System.Numerics;

public class Game
{
    private List<Player> players = new List<Player>();
    private bool finished = false;
    private List<int> specialTiles = new List<int>();
     
    public Game(List<Player> players, List<int> specialTiles)
    {
        this.players = players;
        this.specialTiles = specialTiles;
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
                    Console.WriteLine(players[i].getName() + " a gagné la partie !");
                    finished = true;
                    break;
                } else if (players[i].getScore() > 50)
                {
                    players[i].setScore(25);
                }

                if (specialTiles.IndexOf(players[i].getScore()) != -1)
                {
                    Console.WriteLine(players[i].getName() + " est tombé sur une case spéciale et peut donc rejouer !");
                    rollDice(players[i]);
                }
                Console.WriteLine("\n");
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

         Console.WriteLine(player.getName() + ", vous êtes sur la case " + player.getScore());
    }
}
