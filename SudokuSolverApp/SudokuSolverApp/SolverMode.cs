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
            board.InitializeBoard();
        }
        public void Start()
        {
            this.form.SetSolveButtonVisible();
            this.form.SetVisibilityResetBtn(true);
            this.form.SetVisibilityBackToMenu(true);
            InitializeBoard();
            
        }

        public void Reset()
        {
            InitializeBoard();
        }
    }
}
