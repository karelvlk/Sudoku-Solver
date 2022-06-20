using System;
using System.Collections.Generic;

namespace SudokuSolverApp
{
    class Generator
    {
        SolverBT solver = new SolverBT();
        PenPaperSolver solverPP = new PenPaperSolver();
        CrooksSolver solverCK = new CrooksSolver();
        Random rnd = new Random();

        private void GenerateDiagonal3x3Box(int[,] board, int idx)
        {
            List<int> values = new List<int>();
            for (int i = 1; i <= 9; i++)
            {
                values.Add(i);
            }

            for (int vals = 8; vals >= 0; vals--)
            {
                int index = rnd.Next(0, vals+1);
                int currValue = values[index];
                values.RemoveAt(index);

                int relativeCol = vals / 3;
                int relativeRow = vals % 3;
                int col = idx * 3 + relativeCol;
                int row = idx * 3 + relativeRow;
                board[row, col] = currValue;
            }
        }

        private void GenerateDiagonal3x3Boxes(int[,] board)
        {
            for (int idx = 0; idx < 3; idx++)
            {
                GenerateDiagonal3x3Box(board, idx);
            }
        }

        private void RemoveValues(int[,] board, int k, int difficulty)
        {
            for (int i = 0; i < k;)
            {
                int index = rnd.Next(81);
                int row = index % 9;
                int col = (int)index / 9;
                int val = board[row, col];
                if (board[row, col] != 0)
                {
                    board[row, col] = 0;
                    if (difficulty == 1)
                    {
                        Tuple<bool, int[,]> res = solverPP.SolvePP(board);
                        if (res.Item1)
                        {
                            i++;
                        }
                        else
                        {
                            board[row, col] = val;
                        }
                    } 
                    else if (difficulty == 2)
                    {
                        Tuple<bool, int[,]> res = solverCK.SolveCK(board);
                        if (res.Item1)
                        {
                            i++;
                        }
                        else
                        {
                            board[row, col] = val;
                        }
                    }
                    else
                    {
                        i++;
                    }
                    
                }
            }
        }

        public Tuple<int[,], int[,]> GenerateSudokuBoard(int numOfEmptySpaces, int difficulty)
        {
            int[,] board = new int[9, 9];
            int[,] filled = new int[9, 9];
            GenerateDiagonal3x3Boxes(board);
            Tuple<bool, int[,]> filledSudoku = solver.SolveBT(board);
            if (filledSudoku.Item1)
            {
                board = filledSudoku.Item2;
                for(int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        filled[i, j] = board[i, j];
                    }
                }
                RemoveValues(filledSudoku.Item2, numOfEmptySpaces, difficulty);
            }
            else
            {
                return GenerateSudokuBoard(numOfEmptySpaces, difficulty); // recursion
            }
            
            return new Tuple<int[,], int[,]>(board, filled);
        }
    }
}
