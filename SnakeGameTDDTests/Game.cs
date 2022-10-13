using System;
using System.Collections.Generic;

namespace SnakeGameTDDTests
{
    internal class Game
    {
        public bool started = false;
        public int boardSize;
        public List<Player> players;
        internal List<int> bonusTiles;

        public Game(List<Player> players, int boardSize, List<int> bonusTiles)
        {
            this.players = players;
            this.boardSize = boardSize;
            this.bonusTiles = bonusTiles;
        }

        internal void start()
        {
            started = true;

            while (started)
            {
                playPlayersTurns();

                if (!started)
                    break;
            }

        }

        public void playPlayersTurns()
        {
            for (int i = 0; i < players.Count; i++)
            {
                rollDice(players[i]);

                if (players[i].score == boardSize)
                {
                    started = false;
                    break;
                }
                else if (players[i].score > boardSize)
                    players[i].score = 25;

                if (IsPlayerOnBonusTile(players[i].score))
                    rollDice(players[i]);
            }
        }

        public bool IsPlayerOnBonusTile(int tile)
        {
            return bonusTiles.IndexOf(tile) != -1;
        }

        public static int rollDice(Player player)
        {
            Random random = new Random();
            int dice = random.Next(1, 7);

            player.score = player.score + dice;
            return dice;
        }
    }
}