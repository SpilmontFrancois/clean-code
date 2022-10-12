class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Joueur 1, entrez votre nom :");
        string name1 = Console.ReadLine();

        Console.WriteLine("Joueur 2, entrez votre nom :");
        string name2 = Console.ReadLine();

        List<Player> players = new List<Player>();
        players.Add(new Player(name1, 0));
        players.Add(new Player(name2, 0));

        List<int> specialTiles = new List<int>();
        specialTiles.Add(10);
        specialTiles.Add(20);
        specialTiles.Add(30);
        specialTiles.Add(40);
        specialTiles.Add(42);

        Game game = new Game(players, specialTiles);
        game.start();
    }
}