using NUnit.Framework;
using System;
using System.Diagnostics;
using TicTacToe;

namespace TicTacToeTesting
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        [TestCase(" |O|X|O|X|O|X| | |", 'X', true)]
        [TestCase(" | |O| | |X| |X| |", ' ', false)]
        [TestCase("O|X|O| |X|O|X|X| |", 'X', true)]
        [TestCase(" |O|X|X| |X|X|X| |", ' ', false)]
        [TestCase("O|X|O| |O|O|X|X|X|", 'X', true)]
        [TestCase("X| |O|O| |O|O|O|O|", 'O', true)]
        [TestCase("O|O|O|O| | |O| | |", 'O', true)]
        [TestCase(" |O| | |X| |X|O| |", ' ', false)]
        [TestCase("O|O|O|X|O| |X| |X|", 'O', true)]
        [TestCase("X| | | | | | | | |", ' ', false)]
        [TestCase(" |X|X|O|O|O| |O| |", 'O', true)]
        public void WinCondition(string board, char winner, bool result)
        {
            // Setup condition
            string[] characters = board.Split('|');
            int counter = 0;
            TicTacToePanel[,] panels = new TicTacToePanel[3,3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    panels[i,j] = new TicTacToePanel();
                    panels[i, j].CharacterInPanel = characters[counter++][0];
                }
            }
            
            // Test condition
            GameManager g = new GameManager();
            Debug.WriteLine("");
            g.PrintBoard(panels);
            Debug.WriteLine("");
            char trueWinner;
            bool trueWinCondition = g.CheckWinCondition(panels, out trueWinner);
            Assert.AreEqual(trueWinner, winner);
            Assert.AreEqual(result, trueWinCondition);
        }

        [Test]
        public void PrintRandomBoards()
        {
            Random random = new Random();
            Debug.WriteLine("====================================");
            
            for (int j = 0; j < 50; j++)
            {
                string DebugString = "";
                for (int i = 0; i < 9; i++)
                {
                    int number = random.Next(1, 4);
                    if (number == 1)
                        DebugString += "X|";
                    else if (number == 2)
                        DebugString += "O|";
                    else
                        DebugString += " |";
                }

                Debug.WriteLine($"[TestCase(\"{DebugString}\")]");


                string[] characters = DebugString.Split('|');
                int counter = 0;
                TicTacToePanel[,] panels = new TicTacToePanel[3, 3];
                for (int l = 0; l < 3; l++)
                {
                    for (int m = 0; m < 3; m++)
                    {
                        panels[l, m] = new TicTacToePanel();
                        // Debug.WriteLine(characters.Length);
                        panels[l, m].CharacterInPanel = characters[counter][0];
                        counter++;
                    }
                }

                GameManager g = new GameManager();
                 g.PrintBoard(panels);

            }
            
           
            Debug.WriteLine("====================================");


            
        }
    }
}
