using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverApp
{
    class SolverMode
    {
        Form1 form;
        Board board;

        public SolverMode(Form1 form, Board board)
        {
            this.form = form;
            this.board = board;
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board.SetValue(0, i, j);
                    board.GetEntity(i, j).SetVisibility(true);
                }
            }
        }
        public void Start()
        {
            this.form.SetSolveButtonVisible();
            InitializeBoard();
            
        }
    }
}
