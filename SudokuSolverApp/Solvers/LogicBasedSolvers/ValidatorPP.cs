using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverApp
{
    class ValidatorPP
    {
        private bool ValidateRows(int[,] sudoku)
        {
            for (int row = 0; row < 9; row++)
            {
                int checkSum = 0;
                bool[] nums = new bool[] { true, false, false, false, false, false, false, false, false, false };
                for (int col = 0; col < 9; col++)
                {
                    if (nums[sudoku[col, row]])
                    {
                        return false;
                    }
                    else
                    {
                        nums[sudoku[col, row]] = true;
                    }
                    checkSum += sudoku[col, row];
                }

                if (checkSum != 45)
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateCols(int[,] sudoku)
        {
            for (int col = 0; col < 9; col++)
            {
                int checkSum = 0;
                bool[] nums = new bool[] { true, false, false, false, false, false, false, false, false, false };
                for (int row = 0; row < 9; row++)
                {
                    if (nums[sudoku[col, row]])
                    {
                        return false;
                    }
                    else
                    {
                        nums[sudoku[col, row]] = true;
                    }
                    checkSum += sudoku[col, row];
                }

                if (checkSum != 45)
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateBoxes(int[,] sudoku)
        {
            for (int offsetX = 0; offsetX < 3; offsetX++)
            {
                for (int offsetY = 0; offsetY < 3; offsetY++)
                {
                    int checkSum = 0;
                    bool[] nums = new bool[] { true, false, false, false, false, false, false, false, false, false };
                    for (int relX = 0; relX < 3; relX++)
                    {
                        for (int relY = 0; relY < 3; relY++)
                        {
                            if (nums[sudoku[offsetX * 3 + relX, offsetY * 3 + relY]])
                            {
                                return false;
                            }
                            else
                            {
                                nums[sudoku[offsetX * 3 + relX, offsetY * 3 + relY]] = true;
                            }
                            checkSum += sudoku[offsetX * 3 + relX, offsetY * 3 + relY];
                        }
                    }

                    if (checkSum != 45)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public bool ValidateSudoku(int[,] sudoku)
        {
            return (
                ValidateRows(sudoku) &&
                ValidateCols(sudoku) &&
                ValidateBoxes(sudoku)
                );
        }
    }
}
