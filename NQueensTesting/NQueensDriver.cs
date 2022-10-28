using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace NQueensTesting
{
    internal class NQueensDriver
    {
        static void Main(string[] args)
        { 
            int numQueens = -1;
            while (numQueens < 0)
            {
                Console.Write("How big should the board be? (1 integer): ");
                Int32.TryParse(Console.ReadLine(), out numQueens);
                if (numQueens < 0)
                    Console.WriteLine("Argument must be positive");
            }
            int[,] board = new int[numQueens, numQueens];
            int[,] boardResult = new int[numQueens, numQueens];
            Console.WriteLine("Starting Board");
            Console.WriteLine("===========================");
            PrintBoard(board);
            Console.WriteLine("===========================");
            bool succeeded = false;
            succeeded = NextConfiguration(board, numQueens, 0, out boardResult);
            if(succeeded)
            {
                Console.WriteLine("===========================");
                Console.WriteLine("Solution: ");
                PrintBoard(boardResult);
                Console.WriteLine("===========================");
            }
            else
            {
                Console.WriteLine("===========================");
                Console.WriteLine("No solution found");
                Console.WriteLine("===========================");
            }

        }

        static bool NextConfiguration(int[,] board, int numQueens, int column, out int[,] boardResult)
        {
            boardResult = new int[numQueens, numQueens];
            if (column >= board.GetLength(0))
                return true;

            for (int i = 0; i < numQueens; i++)
            {
          
                if (IsSafe(board, i, column))
                {
                    board[i, column] = 1;
                    if (NextConfiguration(board, numQueens, column + 1, out boardResult))
                    {
                        boardResult = CopyBoard(board);
                        return true;
                    }
                    board[i, column] = 0;
                }
                
            }
            return false;

        }

        private static int[,] CopyBoard(int[,] board)
        {
            int[,] boardReturn = new int[board.GetLength(0), board.GetLength(1)];

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    boardReturn[i, j] = board[i, j];
                }
            }

            return boardReturn;

        }

        static bool IsSafe(int[,] board, int row, int column)
            
        {
            board[row, column] = 1;
            bool result = false;
            result = CheckColumn(board, column) && CheckRow(board, row) && CheckDiagonals(board, row, column);
            if(!result)
                board[row, column] = 0;
            return result;
        }


        // row will be zero indexed
        static bool CheckDiagonals(int[,] board, int row, int column)
        {

            int counter = 0;

            // Down Right
            for (int i = row + 1, j = column + 1; i < board.GetLength(0) && j < board.GetLength(1); i++, j++)
            {
                if (board[i, j] == 1)
                    counter++;
            }

            // Down Left
            for (int i = row + 1, j = column - 1; i < board.GetLength(0) && j >= 0; i++, j--)
            {
                if (board[i, j] == 1)
                    counter++;
            }

            // Top Right
            for (int i = row - 1, j = column + 1; i >= 0 && j < board.GetLength(1); i--, j++)
            {
                if (board[i, j] == 1)
                    counter++;
            }

            // Top Left
            for (int i = row-1, j = column-1; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1)
                    counter++;
            }

            if (counter > 0)
                return false;

            return true;
        }


        // row will be zero indexed
        static bool CheckRow(int[,] board, int row)
        {
            int counter = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[row, i] == 1)
                    counter++;
            }
            if (counter > 1)
                return false;
            return true;
        }

        // column will be zero indexed
        static bool CheckColumn(int[,] board, int column)
        {
            int counter = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, column] == 1)
                    counter++;
            }
            if (counter > 1)
                return false;
            return true;
        }

        static void PrintBoard(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if(j == 0)
                        Console.Write('{');
                    Console.Write($" {board[i,j]} ");
                    if (j == board.GetLength(0) - 1)
                        Console.WriteLine('}');
                }
            }
            Console.WriteLine("\n");
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0)
                    Console.Write("{ ");
                Console.Write($" {array[i]} ");
                if (i == array.Length - 1)
                    Console.Write("}");
            }
            Console.WriteLine(); 
        }
    }
}