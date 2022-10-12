class Game
{
    static void Main(string[] args)
    {
        Console.WriteLine("Joueur 1, entrez votre nom :");
        string name1 = Console.ReadLine();

        Console.WriteLine("Joueur 2, entrez votre nom :");
        string name2 = Console.ReadLine();

        int counter1 = 0;
        int counter2 = 0;

        bool finished = false;

        while (!finished)
        {
            Console.WriteLine(name1 + ", appuyez sur Entrée pour lancer le dé.");
            Console.ReadLine();

            Random random = new Random();
            int dice1 = random.Next(1, 7);

            Console.WriteLine("C'est un " + dice1 + "!");

            counter1 += dice1;
            if (counter1 == 50)
            {
                finished = true;
                Console.WriteLine(name1 + " a gagné !");
            } else if (counter1 > 50)
            {
                counter1 = 25;
            }

            Console.WriteLine(name1 + ", vous êtes sur la case " + counter1 + "\n");

            if(counter1 != 50)
            {
                Console.WriteLine(name2 + ", appuyez sur Entrée pour lancer le dé.");
                Console.ReadLine();

                int dice2 = random.Next(1, 7);

                Console.WriteLine("C'est un " + dice2 + "!");

                counter2 += dice2;
                if (counter2 == 50)
                {
                    finished = true;
                    Console.WriteLine(name2 + " a gagné !");
                } else if (counter2 > 50)
                {
                    counter2 = 25;
                }

                Console.WriteLine(name2 + ", vous êtes sur la case " + counter2 + "\n");
            }
        }
    }
}
