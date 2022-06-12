using System;

namespace SudokuSolverApp
{
    class SolverMode
    {
        Form1 form;
        Board board;
        Solver solver = new Solver();

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

        public void Solve()
        {
            Tuple<bool, int[,]> result = solver.SolveAllStepsByBT(board.GetBoard());
            if (result.Item1)
            {
                board.SetBoard(result.Item2);
                form.SetInfoBoxMessageGreen("Successfully solved!");
            }
            else
            {
                form.SetInfoBoxMessageRed("Cannot be solved!");
                board.RedAll(true);
            }
        }

        public void Reset()
        {
            InitializeBoard();
        }
    }
}
