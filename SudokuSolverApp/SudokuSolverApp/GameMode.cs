using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverApp
{
    class GameMode
    {
        Solver solver = new Solver();
        Form1 form;
        Board board;
        int difficulty = 1;
        Generator generator = new Generator();
        Random rnd = new Random();

        public GameMode(Form1 form, Board board)
        {
            this.form = form;
            this.board = board;
        }

        public void StartGame()
        {
            this.form.HideGameMenuPage();
            this.form.ShowGameModeButtons();
            int emptySpaces = 0;
            switch (difficulty)
            {
                case 1:
                    emptySpaces = rnd.Next(20, 35);
                    break;
                case 2:
                    emptySpaces = rnd.Next(35, 45);
                    break;
                case 3:
                    emptySpaces = rnd.Next(45, 54);
                    break;
                case 4:
                    emptySpaces = rnd.Next(55, 63);
                    break;
                default:
                    break;
            }
            Tuple<int[,], int[,]> result = generator.GenerateSudokuBoard(emptySpaces);
            board.SetBoardInit(result.Item1);
            board.SetFilledBoard(result.Item2);

        }

        public void SetDifficulty(int difficulty)
        {
            this.difficulty = difficulty;
        }

        public void Start()
        {
            this.form.SetModeButtonsVisible();
            this.form.SetContinueButtonVisible();
        }

        public void Check()
        {
            Tuple<bool, int[,]> result = solver.SolveAllStepsByBT(board.GetBoard());
            if (result.Item1)
            {
                board.GreenAll(false);
            } 
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (board.GetBoard()[i, j] == board.GetFilledBoard()[i, j])
                        {
                            board.GreenEntity(i, j, false);
                        } 
                        else
                        {
                            board.RedEntity(i, j, false);
                        }
                    }
                }
            }
        }

        public void DoHint()
        {
            Tuple<bool, int[,]> result = solver.SolveAllStepsByBT(board.GetBoard());
            int[,] comparedTo;
            if (result.Item1)
            {
                comparedTo = result.Item2;
            }
            else
            {
                comparedTo = board.GetFilledBoard();
            }

            List<int[]> possibleChanges = new List<int[]>();


            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board.GetBoard()[i, j] != comparedTo[i, j])
                    {
                        possibleChanges.Add(new int[] { i, j });
                    }
                    
                }
            }

            if (possibleChanges.Count > 0)
            {
                int index = rnd.Next(0, possibleChanges.Count);
                int row = possibleChanges[index][0];
                int col = possibleChanges[index][1];

                board.SetValue(comparedTo[row, col], row, col);
                board.BlueEntity(row, col);
            }
        }
    }
}
