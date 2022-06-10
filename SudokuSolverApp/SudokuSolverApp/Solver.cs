using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverApp
{
    class Solver
    {
        private bool CanBePlacedInHorizontalLine(int[,] board, int[] position, int number)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[position[0], i] == number)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CanBePlacedInVerticalLine(int[,] board, int[] position, int number)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, position[1]] == number)
                {
                    return false;
                }
            }
            return true;
        }

        private int GetStartLine(int[] pos)
        {
            if (pos[0] < 3)
            {
                return 0;
            }
            else if (pos[0] < 6)
            {
                return 3;
            }
            else
            {
                return 6;
            }
        }

        private int GetStartColumn(int[] pos)
        {
            if (pos[1] < 3)
            {
                return 0;
            }
            else if (pos[1] < 6)
            {
                return 3;
            }
            else
            {
                return 6;
            }
        }

        private bool CanBePlacedIn3x3Box(int[,] board, int[] position, int number)
        {
            int startLine = GetStartLine(position);
            int startColumn = GetStartColumn(position);

            for (int line = 0; line < 3; line++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (board[line+startLine, column+startColumn] == number)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CanTheNumberBePlaced(int[,] board, int[] currentChangedPosition, int num)
        {
            if (
                CanBePlacedInHorizontalLine(board, currentChangedPosition, num) &&
                CanBePlacedInVerticalLine(board, currentChangedPosition, num) &&
                CanBePlacedIn3x3Box(board, currentChangedPosition, num)
            )
            {
                return true;
            } 
            else
            {
                return false;
            }
        }
   
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
                    if (CanTheNumberBePlaced(board, new int[] { row, col }, num))
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
