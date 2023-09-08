using System;

namespace SudokuApp
{
    class Program
    {
        static int[,] sudokuBoard = new int[9, 9];

        static void Main(string[] args)
        {
            InitializeBoard();
            PrintBoard();

            while (!IsSudokuSolved())
            {
                Console.Write("Ingresa la fila (0-8): ");
                int row = int.Parse(Console.ReadLine());

                Console.Write("Ingresa la columna (0-8): ");
                int col = int.Parse(Console.ReadLine());

                Console.Write("Ingresa el número (1-9): ");
                int num = int.Parse(Console.ReadLine());

                if (IsValidMove(row, col, num))
                {
                    sudokuBoard[row, col] = num;
                }
                else
                {
                    Console.WriteLine("Movimiento inválido. Intenta de nuevo.");
                }

                PrintBoard();
            }

            Console.WriteLine("¡Felicidades! ¡Has resuelto el Sudoku!");
        }

        static void InitializeBoard()
        {
            
            int[,] initialValues = {
                {5, 3, 0, 0, 7, 0, 0, 0, 0},
                {6, 0, 0, 1, 9, 5, 0, 0, 0},
                {0, 9, 8, 0, 0, 0, 0, 6, 0},
                {8, 0, 0, 0, 6, 0, 0, 0, 3},
                {4, 0, 0, 8, 0, 3, 0, 0, 1},
                {7, 0, 0, 0, 2, 0, 0, 0, 6},
                {0, 6, 0, 0, 0, 0, 2, 8, 0},
                {0, 0, 0, 4, 1, 9, 0, 0, 5},
                {0, 0, 0, 0, 8, 0, 0, 7, 9}
            };

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    sudokuBoard[row, col] = initialValues[row, col];
                }
            }
        }

        static void PrintBoard()
        {
            Console.WriteLine("-------------");
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Console.Write(sudokuBoard[row, col] + " ");
                    if (col == 2 || col == 5)
                    {
                        Console.Write("| ");
                    }
                }
                Console.WriteLine();
                if (row == 2 || row == 5)
                {
                    Console.WriteLine("-------------");
                }
            }
            Console.WriteLine("-------------");
        }

        static bool IsValidMove(int row, int col, int num)
        {
            
            for (int i = 0; i < 9; i++)
            {
                if (sudokuBoard[row, i] == num || sudokuBoard[i, col] == num)
                {
                    return false;
                }
            }

           
            int startRow = row - row % 3;
            int startCol = col - col % 3;
            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    if (sudokuBoard[i, j] == num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static bool IsSudokuSolved()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (sudokuBoard[row, col] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
