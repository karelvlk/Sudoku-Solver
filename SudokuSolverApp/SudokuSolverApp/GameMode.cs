using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverApp
{
    class GameMode
    {
        Form1 form;
        Board board;

        public GameMode(Form1 form, Board board)
        {
            this.form = form;
            this.board = board;
        }

        public void Start()
        {
            this.form.SetModeButtonsVisible();
            this.form.SetContinueButtonVisible();
        }
    }
}
