using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverApp
{
    class CrooksSolver : PenPaperSolver
    {
        private void ProcessRowSet(bool[,,] candidates, Tuple<bool, bool[]> res, int row, int col)
        {
            if (!res.Item1)
            {
                return;
            }

            for (int colPos = 0; colPos < 9; colPos++)
            {
                if (res.Item2[colPos]) // superSets cumulation
                {
                    for (int num = 1; num < 10; num++)
                    {
                        candidates[colPos, row, num] = candidates[col, row, num];
                    }
                }
                else
                {
                    for (int n = 1; n < 10; n++) // remove superSet Cands from other
                    {
                        if (candidates[colPos, row, n] && candidates[col, row, n])
                        {
                            candidates[colPos, row, n] = false;
                        }
                    }
                }
            }
        }

        private Tuple<bool, bool[]> FindSetRow(bool[,,] candidates, int row, int col)
        {
            int numOfCands = 0;
            bool[] superSetPos = new bool[] { false, false, false, false, false, false, false, false, false };
            for (int i = 1; i < 10; i++)
            {
                if (candidates[col, row, i])
                {
                    numOfCands++;
                }
            }

            if (numOfCands <= 1)
            {
                return new Tuple<bool, bool[]>(false, superSetPos);
            }

            for (int c = 0; c < 9; c++)
            {
                bool hasSameCands = true;
                for (int cand = 1; cand < 10; cand++)
                {
                    if (candidates[col, row, cand])
                    {
                        if (!candidates[c, row, cand])
                        {
                            hasSameCands = false;
                            break;
                        }
                    }
                }

                if (!hasSameCands)
                {
                    superSetPos[c] = true;
                    numOfCands--;
                }
            }

            bool isSuperSet = false;
            if (numOfCands == 0)
            {
                isSuperSet = true;
            }

            return new Tuple<bool, bool[]>(isSuperSet, superSetPos);
        }

        private void ProcessColSet(bool[,,] candidates, Tuple<bool, bool[]> res, int row, int col)
        {
            if (!res.Item1)
            {
                return;
            }

            for (int rowPos = 0; rowPos < 9; rowPos++)
            {
                if (res.Item2[rowPos]) // superSets cumulation
                {
                    for (int num = 1; num < 10; num++)
                    {
                        candidates[col, rowPos, num] = candidates[col, row, num];
                    }
                }
                else
                {
                    for (int n = 1; n < 10; n++) // remove superSet Cands from other
                    {
                        if (candidates[col, rowPos, n] && candidates[col, row, n])
                        {
                            candidates[col, rowPos, n] = false;
                        }
                    }
                }
            }
        }

        private Tuple<bool, bool[]> FindSetCol(bool[,,] candidates, int row, int col)
        {
            int numOfCands = 0;
            bool[] superSetPos = new bool[] { false, false, false, false, false, false, false, false, false, false };
            for (int i = 1; i < 10; i++)
            {
                if (candidates[col, row, i])
                {
                    numOfCands++;
                }
            }

            if (numOfCands <= 1)
            {
                return new Tuple<bool, bool[]>(false, superSetPos);
            }

            for (int r = 0; r < 9; r++)
            {
                bool hasSameCands = true;
                for (int cand = 1; cand < 10; cand++)
                {
                    if (candidates[col, row, cand])
                    {
                        if (!candidates[col, r, cand])
                        {
                            hasSameCands = false;
                            break;
                        }
                    }
                }

                if (!hasSameCands)
                {
                    superSetPos[r] = true;
                    numOfCands--;
                }
            }

            bool isSuperSet = false;
            if (numOfCands == 0)
            {
                isSuperSet = true;
            }

            return new Tuple<bool, bool[]>(isSuperSet, superSetPos);
        }

        private void ProcessBoxSet(bool[,,] candidates, Tuple<bool, bool[]> res, int row, int col)
        {
            if (!res.Item1)
            {
                return;
            }

            int offSetX = row % 3;
            int offSetY = col % 3;

            for (int relX = 0; relX < 3; relX++)
            {
                for (int relY = 0; relY < 3; relY++)
                {
                    int idx = relY * 3 + relX;
                    if (res.Item2[idx]) // superSets cumulation
                    {
                        for (int num = 1; num < 10; num++)
                        {
                            candidates[offSetY * 3 + relY, offSetX * 3 + relX, num] = candidates[col, row, num];
                        }
                    }
                    else
                    {
                        for (int n = 1; n < 10; n++) // remove superSet Cands from other
                        {
                            if (candidates[offSetY * 3 + relY, offSetX * 3 + relX, n] && candidates[col, row, n])
                            {
                                candidates[offSetY * 3 + relY, offSetX * 3 + relX, n] = false;
                            }
                        }
                    }
                }
            }
        }

        private Tuple<bool, bool[]> FindSetBox(bool[,,] candidates, int row, int col)
        {
            int numOfCands = 0;
            bool[] superSetPos = new bool[] { false, false, false, false, false, false, false, false, false };
            for (int i = 1; i < 10; i++)
            {
                if (candidates[col, row, i])
                {
                    numOfCands++;
                }
            }

            if (numOfCands <= 1)
            {
                return new Tuple<bool, bool[]>(false, superSetPos);
            }

            int offsetX = row % 3;
            int offsetY = col % 3;

            for (int relX = 0; relX < 3; relX++)
            {
                for (int relY = 0; relY < 3; relY++)
                {
                    bool hasSameCands = true;
                    for (int cand = 1; cand < 10; cand++)
                    {
                        if (candidates[offsetY * 3 + relY, offsetX * 3 + relX, cand])
                        {
                            if (!candidates[offsetY * 3 + relY, offsetX * 3 + relX, cand])
                            {
                                hasSameCands = false;
                                break;
                            }
                        }
                    }
                    int idx = relY * 3 + relX;
                    if (!hasSameCands)
                    {
                        superSetPos[idx] = true;
                        numOfCands--;
                    }
                }
            }

            bool isSuperSet = false;
            if (numOfCands == 0)
            {
                isSuperSet = true;
            }

            return new Tuple<bool, bool[]>(isSuperSet, superSetPos);
        }

        private void ProcessSet(bool[,,] candidates, int row, int col)
        {
            Tuple<bool, bool[]> rowSet = FindSetRow(candidates, row, col);
            ProcessRowSet(candidates, rowSet, row, col);

            if (rowSet.Item1)
            {
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(rowSet.Item2[i]);
                    Console.Write(" ");
                }
                Console.Write("\n");
            }

            Tuple<bool, bool[]> colSet = FindSetCol(candidates, row, col);
            ProcessColSet(candidates, colSet, row, col);

            Tuple<bool, bool[]> boxSet = FindSetBox(candidates, row, col);
            ProcessBoxSet(candidates, boxSet, row, col);
        }

        private void ProcessSuperSets(bool[,,] candidates)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    ProcessSet(candidates, row, col);
                }
            }
        }

        public Tuple<bool, int[,]> SolveCK(int[,] board)
        {
            bool[,,] candidates = base.CreateCandidateBoard();
            int[,] solvedSudoku = utils.CopyMatrix(board);
            while (true)
            {
                int[,] oldSolved = utils.CopyMatrix(solvedSudoku);
                base.RefreshCandidates(solvedSudoku, candidates);
                base.FillUniques(solvedSudoku, candidates);
                ProcessSuperSets(candidates);
                base.RefreshCandidates(solvedSudoku, candidates);
                base.FillSingletons(solvedSudoku, candidates);


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
