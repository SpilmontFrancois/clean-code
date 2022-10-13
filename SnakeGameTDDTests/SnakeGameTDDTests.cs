using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;

namespace SnakeGameTDDTests
{
    [TestClass]
    public class SnakeGameTDDTests
    {
        private Player _player1 = new Player("Jean");
        private Player _player2 = new Player("Marc");
        private List<Player> _players = new List<Player>();
        private List<int> _bonusTiles = new List<int>();
        private int _boardSize = 50;
        private Game _game;

        public SnakeGameTDDTests()
        {
            _players.Add(_player1);
            _players.Add(_player2);
            _bonusTiles.Add(10);
            _bonusTiles.Add(20);
            _bonusTiles.Add(30);
            _bonusTiles.Add(40);
            _bonusTiles.Add(42);
            _game = new Game(_players, _boardSize, _bonusTiles);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow()]
        public void PlayersNamesCanNotBeEmptyOrNull(string name)
        {
            Assert.ThrowsException<Player.EmptyOrNullNameException>(() => new Player(name));
        }

        [TestMethod]
        public void GameIsCreatedWithTwoPlayers()
        {
            Assert.AreEqual(2, _game.players.Count);
        }

        [TestMethod]
        public void GameIsCreatedWithFiveBonusTiles()
        {
            Assert.AreEqual(5, _game.bonusTiles.Count);
        }

        [TestMethod]
        public void GameIsCreatedWith50Tiles()
        {
            Assert.AreEqual(50, _game.boardSize);
        }

        [TestMethod]
        public void PlayerIsOnABonusTile()
        {
            _player1.score = 10;
            Assert.IsTrue(_game.IsPlayerOnBonusTile(_player1.score));
        }

        [TestMethod]
        public void PlayerIsNoLongerOnABonusTile_AfterPlayingAgain()
        {
            _player1.score = 10;
            _game.playPlayersTurns();
            Assert.IsFalse(_game.IsPlayerOnBonusTile(_player1.score));
        }

        [TestMethod]
        public void PlayersDefaultScoreIsZero()
        {
            Assert.AreEqual(0, _player1.score);
            Assert.AreEqual(0, _player2.score);
        }

        [TestMethod]
        public void GeneratedDiceIsBetweenOneAndSix()
        {
            int dice = Game.rollDice(_player1);
            Assert.IsTrue(dice >= 1 && dice <= 6);
        }

        [TestMethod]
        public void PlayersCanPlayTheirTurnsAndRollDice_ScoreIsIncremented()
        {
            _game.playPlayersTurns();
            Assert.AreNotEqual(0, _player1.score);
            Assert.AreNotEqual(0, _player2.score);
        }

        [TestMethod]
        public void PlayerCanRollDice_PlayerIsOnGoodTileAfterFirstRoll()
        {
            int dice = Game.rollDice(_player1);
            Assert.AreEqual(dice, _player1.score);
        }

        [TestMethod]
        public void PlayerCanRollDice_PlayerIsOnGoodTileAfterSecondRoll()
        {
            int dice = Game.rollDice(_player1);
            dice += Game.rollDice(_player1);
            Assert.AreEqual(dice, _player1.score);
        }

        [TestMethod]
        public void PlayersCanPlayTheirTurnsAndRollDice_ScoreReturnTo25WhenHigherThan50()
        {
            _player1.score = 50;
            _game.playPlayersTurns();
            Assert.AreEqual(25, _player1.score);
        }

        [TestMethod]
        public void GameStopsWhenAPlayerReachesScore50_GameRunsNormally()
        {
            _player1.score = 50;
            _game.start();
            Assert.IsFalse(_game.started);
        }
    }
}
