using System;

namespace SnakeGameTDDTests
{
    internal class Player
    {
        public int score = 0;
        public string Name { get; }

        public Player(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new EmptyOrNullNameException("The name cannot be empty or null");
            this.Name = name;
        }

        internal class EmptyOrNullNameException : Exception
        {
            public EmptyOrNullNameException(string message) : base(message) { }
        }
    }
}