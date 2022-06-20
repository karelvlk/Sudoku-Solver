using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverApp
{
    class SolverBT
    {
        private ValidatorBT validator = new ValidatorBT();

        public int[] GetEmptyPosition(int[,] board)
        {
            int row = -1;
            int col = -1;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        return new int[] { row, col }; ;
                    }
                }
            }

            return new int[] { row, col };
        }

        public Tuple<bool, int[,]> SolveBT(int[,] board)
        {
            int[,] solvedBoard = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    solvedBoard[i, j] = board[i, j];
                }
            }
            
            if (validator.IsBoardValid(board) && SolveByBacktracking(solvedBoard))
            {
                return new Tuple<bool, int[,]>(true, solvedBoard);
            } 
            else
            {
                return new Tuple<bool, int[,]>(false, solvedBoard);
            }
        }

        public bool SolveByBacktracking(int[,] board)
        {
            int[] emptyPosition = GetEmptyPosition(board);
            if (emptyPosition[0] == -1 && emptyPosition[1] == -1)
            {
                return true;
            } 
            else
            {
                // Backtrack
                int row = emptyPosition[0];
                int col = emptyPosition[1];

                for (int num = 1; num <= 9; num++)
                {
                    if (validator.CanTheNumberBePlaced(board, new int[] { row, col }, num))
                    {
                        board[row, col] = num;
                        if (SolveByBacktracking(board))
                        {
                            return true;
                        }
                        else
                        {
                            // Replace wrong value by no value
                            board[row, col] = 0;
                        }
                    }
                }
                return false;
            }
        }
    }
}
