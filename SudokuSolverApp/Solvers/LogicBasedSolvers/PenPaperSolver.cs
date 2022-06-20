using System;

namespace SudokuSolverApp
{
    class PenPaperSolver
    {
        protected Utils utils = new Utils();
        protected ValidatorPP validator = new ValidatorPP();
        private void IntersectionLine(bool[,,] candidates, int lineNumber, bool[] linePossibilities, int[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    if (board[i, lineNumber] != 0)
                    {
                        candidates[i, lineNumber, j] = false;
                    }
                    else
                    {
                        bool cands = candidates[i, lineNumber, j];
                        bool possibs = linePossibilities[j];

                        candidates[i, lineNumber, j] = cands && possibs;
                    }
                }
            }
        }

        private void IntersectionColumn(bool[,,] candidates, int colNumber, bool[] linePossibilities, int[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    if (board[colNumber, i] != 0)
                    {
                        candidates[colNumber, i, j] = false;
                    }
                    else
                    {
                        bool cands = candidates[colNumber, i, j];
                        bool possibs = linePossibilities[j];

                        candidates[colNumber, i, j] = cands && possibs;
                    }
                }
            }
        }

        private void IntersectionBox(bool[,,] candidates, int boxRow, int BoxCol, bool[] boxPossibilities, int[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int n = 1; n < 10; n++)
                    {
                        if (board[BoxCol * 3 + j, boxRow * 3 + i] != 0)
                        {
                            candidates[BoxCol * 3 + j, boxRow * 3 + i, n] = false;
                        }
                        else
                        {
                            bool cands = candidates[BoxCol * 3 + j, boxRow * 3 + i, n];
                            bool possibs = boxPossibilities[n];

                            candidates[BoxCol * 3 + j, boxRow * 3 + i, n] = cands && possibs;
                        }
                    }
                }
            }
        }

        private void UpdateCandidates_FullRow(int[,] board, bool[,,] candidates)
        {
            bool[] isThereInv; // inverseLogic

            for (int row = 0; row < 9; row++)
            {
                isThereInv = new bool[] { true, true, true, true, true, true, true, true, true, true };
                for (int col = 0; col < 9; col++)
                {
                    int num = board[col, row];
                    if (isThereInv[num])
                    {
                        isThereInv[num] = false;
                    }
                }

                IntersectionLine(candidates, row, isThereInv, board);
            }
        }

        private void UpdateCandidates_FullCol(int[,] board, bool[,,] candidates)
        {
            bool[] isThereInv; // inverseLogic
            for (int col = 0; col < 9; col++)
            {
                isThereInv = new bool[] { true, true, true, true, true, true, true, true, true, true };
                for (int j = 0; j < 9; j++)
                {
                    int num = board[col, j];
                    if (isThereInv[num])
                    {
                        isThereInv[num] = false;
                    }
                }

                IntersectionColumn(candidates, col, isThereInv, board);
            }
        }

        private void UpdateCandidates_Full3x3(int[,] board, bool[,,] candidates)
        {
            bool[] isThereInv; // inverseLogic
            for (int offSetX = 0; offSetX < 3; offSetX++)
            {
                for (int offSetY = 0; offSetY < 3; offSetY++)
                {
                    isThereInv = new bool[] { true, true, true, true, true, true, true, true, true, true };
                    for (int relativeX = 0; relativeX < 3; relativeX++)
                    {
                        for (int relativeY = 0; relativeY < 3; relativeY++)
                        {
                            int num = board[offSetY * 3 + relativeY, offSetX * 3 + relativeX];

                            if (isThereInv[num])
                            {
                                isThereInv[num] = false;
                            }
                        }
                    }

                    IntersectionBox(candidates, offSetX, offSetY, isThereInv, board);
                }
            }
        }

        private bool CheckRowForUnique(bool[,,] candidates, int row, int candidateNumber)
        {
            bool isUnique = false;
            for (int col = 0; col < 9; col++)
            {
                if (candidates[col, row, candidateNumber])
                {
                    if (!isUnique)
                    {
                        isUnique = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool CheckColForUnique(bool[,,] candidates, int col, int candidateNumber)
        {
            bool isUnique = false;
            for (int row = 0; row < 9; row++)
            {
                if (candidates[col, row, candidateNumber])
                {
                    if (!isUnique)
                    {
                        isUnique = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool CheckBoxForUnique(bool[,,] candidates, int row, int col, int candidateNumber)
        {
            int offsetX = row % 3;
            int offsetY = col % 3;

            bool isUnique = false;
            for (int relativeX = 0; relativeX < 3; relativeX++)
            {
                for (int relativeY = 0; relativeY < 3; relativeY++)
                {
                    if (candidates[relativeY + offsetY, relativeX + offsetX, candidateNumber]) //!!!
                    {
                        if (!isUnique)
                        {
                            isUnique = true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        protected bool FillSingletons(int[,] board, bool[,,] candidates)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    for (int candidateNumber = 0; candidateNumber < 9; candidateNumber++)
                    {
                        if (candidates[col, row, candidateNumber])
                        {
                            if (CheckRowForUnique(candidates, row, candidateNumber) &&
                                CheckColForUnique(candidates, col, candidateNumber) &&
                                CheckBoxForUnique(candidates, row, col, candidateNumber))
                            {
                                board[col, row] = candidateNumber;
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        protected void RefreshCandidates(int[,] board, bool[,,] candidates)
        {
            UpdateCandidates_FullRow(board, candidates);
            UpdateCandidates_FullCol(board, candidates);
            UpdateCandidates_Full3x3(board, candidates);
        }

        protected bool[,,] CreateCandidateBoard()
        {
            bool[,,] candidateBoard = new bool[9, 9, 10];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    for (int candidate = 0; candidate < 10; candidate++)
                    {
                        candidateBoard[i, j, candidate] = true;
                    }
                }
            }

            return candidateBoard;
        }

        protected bool FillUniques(int[,] board, bool[,,] candidates)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    bool isOnly1True = false;
                    int val = 0;
                    for (int n = 1; n < 10; n++)
                    {
                        if (candidates[col, row, n])
                        {
                            if (!isOnly1True)
                            {
                                isOnly1True = true;
                                val = n;
                            }
                            else
                            {
                                isOnly1True = false;
                                break;
                            }
                        }
                    }

                    if (isOnly1True)
                    {
                        board[col, row] = val;
                        return true;
                    }
                }
            }

            return false;
        }

        public Tuple<bool, int[,]> SolvePP(int[,] board)
        {
            bool[,,] candidates = CreateCandidateBoard();
            int[,] solvedSudoku = utils.CopyMatrix(board);
            while (true)
            {
                int[,] oldSolved = utils.CopyMatrix(solvedSudoku);
                RefreshCandidates(solvedSudoku, candidates);
                FillUniques(solvedSudoku, candidates);
                RefreshCandidates(solvedSudoku, candidates);
                FillSingletons(solvedSudoku, candidates);

                if (utils.CompareMatrices(oldSolved, solvedSudoku))
                {
                    break;
                }
            }

            if (validator.ValidateSudoku(solvedSudoku))
            {
                return new Tuple<bool, int[,]>(true, solvedSudoku);
            } 
            else
            {
                return new Tuple<bool, int[,]>(false, solvedSudoku);
            }
        }
    }
}
