using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameManager
    {

        public GameManager()
        {
            
        }


        public bool CheckWinCondition(TicTacToePanel[,] ticTacToePanels, out char winner)
        {
            bool win = true;
            char chosenCharacter;
            winner = ' ';
            PrintBoard(ticTacToePanels);

            chosenCharacter = ticTacToePanels[0, 0].CharacterInPanel;
            int row;
            for (row = 0; row < ticTacToePanels.GetLength(1);)
            {
                // Check Each Row
                Debug.Write($"Checking row {row + 1}: ");
                for (int col = 0; col < ticTacToePanels.GetLength(0); col++)
                {
                    if (chosenCharacter != ticTacToePanels[row, col].CharacterInPanel)
                        win = false;
                }
                if (win == true && 
                    chosenCharacter != 0 && 
                    chosenCharacter != 32)
                {
                    winner = chosenCharacter;
                    return win;
                }
                win = true;
                if (row < ticTacToePanels.GetLength(1) - 1)
                    chosenCharacter = ticTacToePanels[++row, 0].CharacterInPanel;
                else
                    row++;
            }
            Debug.WriteLine("");


            // Check Each Column
            chosenCharacter = ticTacToePanels[0, 0].CharacterInPanel;
            for (int col = 0; col < ticTacToePanels.GetLength(1);)
            {
                // Check Each Row
                for (row = 0; row < ticTacToePanels.GetLength(0); row++)
                {
                    if (chosenCharacter != ticTacToePanels[row, col].CharacterInPanel)
                        win = false;

                }
                if (win == true && 
                    chosenCharacter != 0 && 
                    chosenCharacter != 32)
                {
                    winner = chosenCharacter;
                    return win;
                }

                win = true;
                if (col < ticTacToePanels.GetLength(1) - 1)
                    chosenCharacter = ticTacToePanels[0, ++col].CharacterInPanel;
                else
                    col++;
            }

            chosenCharacter = ticTacToePanels[0, 0].CharacterInPanel;

            win = true;
            // Check Diagonals
            for (int i = 0, j = 0; i < ticTacToePanels.GetLength(1) && j < ticTacToePanels.GetLength(1);)
            {
                if (ticTacToePanels[i++, j++].CharacterInPanel != chosenCharacter && 
                    chosenCharacter != 0 && 
                    chosenCharacter != 32)
                    win = false;
            }

            if(win && chosenCharacter != 0 && chosenCharacter != 32)
            {
                winner = chosenCharacter;
                return win;
            }

            chosenCharacter = ticTacToePanels[2, 0].CharacterInPanel;

            win = true;
            // Check Diagonals
            for (int i = 2, j = 0; i >= 0 && j < ticTacToePanels.GetLength(1);)
            {
                if (ticTacToePanels[i--, j++].CharacterInPanel != chosenCharacter && chosenCharacter != 0 && chosenCharacter != 32)
                    win = false;
            }
            if (win && chosenCharacter != 0 && chosenCharacter != 32)
            {
                winner = chosenCharacter;
                return true;
            }
            return false;
        }

        public void PrintBoard(TicTacToePanel[,] ticTacToePanels)
        {
            Debug.WriteLine("====================================");
            
            for (int i = 0; i < ticTacToePanels.GetLength(0); i++)
            {
                Debug.Write("|");
                for (int j = 0; j < ticTacToePanels.GetLength(1); j++)
                {
                    if(ticTacToePanels[i, j].CharacterInPanel != '\0')
                        Debug.Write($" {ticTacToePanels[i, j].CharacterInPanel} ");
                    else
                        Debug.Write($"   ");
                }
                Debug.WriteLine("|");
            }
            Debug.WriteLine("====================================");
        }
    }


    
}
