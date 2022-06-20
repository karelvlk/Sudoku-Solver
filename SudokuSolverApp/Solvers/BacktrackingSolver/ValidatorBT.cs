using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverApp
{
    class ValidatorBT
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
                    if (board[line + startLine, column + startColumn] == number)
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

        public bool AreVerticalLinesValid(int[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                bool[] isNumUsed = new bool[] { false, false, false, false, false, false, false, false, false, false };
                for (int j = 0; j < 9; j++)
                {
                    int number = board[j, i];
                    if (!isNumUsed[number])
                    {
                        isNumUsed[number] = true;
                    }
                    else if (isNumUsed[number] && number != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool AreHorizontalLinesValid(int[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                bool[] isNumUsed = new bool[] { false, false, false, false, false, false, false, false, false, false };
                for (int j = 0; j < 9; j++)
                {
                    int number = board[i, j];
                    if (!isNumUsed[number])
                    {
                        isNumUsed[number] = true;
                    }
                    else if (isNumUsed[number] && number != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Are3x3BoxesValid(int[,] board)
        {
            for (int startRow = 0; startRow < 9; startRow += 3)
            {
                for (int startCol = 0; startCol < 9; startCol += 3)
                {
                    bool[] isNumUsed = new bool[] { false, false, false, false, false, false, false, false, false, false };
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            int number = board[startRow + i, startCol + j];
                            if (!isNumUsed[number])
                            {
                                isNumUsed[number] = true;
                            }
                            else if (isNumUsed[number] && number != 0)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool IsBoardValid(int[,] board)
        {
            return (
                AreVerticalLinesValid(board) &&
                AreHorizontalLinesValid(board) &&
                Are3x3BoxesValid(board)
            );
        }
    }
}
