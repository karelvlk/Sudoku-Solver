using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverApp
{
    class Utils
    {
        public bool CompareMatrices(int[,] m1, int[,] m2)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (m1[i, j] != m2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public int[,] CopyMatrix(int[,] m)
        {
            int[,] newMatrix = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    newMatrix[i, j] = m[i, j];
                }
            }

            return newMatrix;
        }
    }
}
