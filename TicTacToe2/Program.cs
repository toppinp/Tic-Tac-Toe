using System;
using System.Security.Cryptography.X509Certificates;

namespace TicTacToe2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[3,3]
            { { '-', '-', '-' }, { '-', '-', '-' }, { '-', '-', '-' } };

            char player = 'x';

            printBoard(board);

            for (int i = 1; i < 10; i++)
            {
                if (i%2 == 0)
                {
                    player = 'x';
                }
                else
                {
                    player = 'o';
                }

                makeMove(board, player);
                printBoard(board);
                if (checkVictory(board, player))
                {
                    Console.WriteLine($"Congradulations Player {player}!");
                    return;
                }
            }

        }



        static void printBoard(char[,] board)
        {
            Console.WriteLine("  1 2 3 ");
            Console.WriteLine($"1 {board[0, 0]} {board[0, 1]} {board[0, 2]}");
            Console.WriteLine($"2 {board[1, 0]} {board[1, 1]} {board[1, 2]}");
            Console.WriteLine($"3 {board[2, 0]} {board[2, 1]} {board[2, 2]}");
        }

        static void makeMove(char[,] board, char player)
        {
            bool spaceSelected = false;
            int row = 0;
            int col = 0;
            do
            {
                Console.Write("Select a row: ");
                row = int.Parse(Console.ReadLine()) -1;

                Console.Write("Select a column: ");
                col = int.Parse(Console.ReadLine()) -1;

                if ((row < 3 && row > -1) && (col < 3 && col > -1))
                {
                    if (board[row, col] == '-')
                    {
                        board[row, col] = player;
                        spaceSelected = true;
                    }
                    else
                    {
                        Console.WriteLine("That space is already taken.  Please select again.");

                    }
                }
                else
                {
                    Console.WriteLine("That is not a valid move.  Try again.");
                }
            } while (spaceSelected == false);

        }

        public static bool checkVictory(char[,] array, char player)
        {
            for (int r = 0; r < array.GetUpperBound(1); r++)
            {
                if (array[r, 0] == player && array[r, 1] == player && array[r, 2] == player)
                {
                    Console.WriteLine("Player " + player + " wins!");
                    return true;
                }
            }
            for (int c = 0; c < array.GetUpperBound(0); c++)
            {
                if (array[0, c] == player && array[1, c] == player && array[2, c] == player)
                {
                    Console.WriteLine("Player " + player + " wins!");
                    return true;
                }
            }
            if (array[0, 0] == player && array[1, 1] == player && array[2, 2] == player)
            {
                Console.WriteLine("Player " + player + " wins!");
                return true;
            }
            if (array[2, 0] == player && array[1, 1] == player && array[0, 2] == player)
            {
                Console.WriteLine("Player " + player + " wins!");
                return true;
            }
            return false;
        }
    }

}
