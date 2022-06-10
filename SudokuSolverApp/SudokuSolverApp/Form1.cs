using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolverApp
{
    public partial class Form1 : Form
    {
        SolverMode solverMode;
        GameMode gameMode;
        Board board;
        Solver solver;
        public Form1()
        {
            InitializeComponent();
        }

        public void SetSolveButtonVisible()
        {
            this.SolveBtn.Visible = true;
        }

        public void SetModeButtonsVisible()
        {
            this.EasyOption.Visible = true;
            this.MediumOption.Visible = true;
            this.HardOption.Visible = true;
            this.ExtremeOption.Visible = true;
        }

        public void SetContinueButtonVisible()
        {
            this.ContinueBtn.Visible = true;
        }

        public void Test2()
        {
            Generator generator = new Generator();
            Tuple<int[,], int[,]> generated = generator.GenerateSudokuBoard(60);
            int[,] board = generated.Item1;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i, j]);
                    Console.Write(" ");
                }

                Console.Write("\n");
            }

            Console.WriteLine("=======");

            int[,] board2 = generated.Item2;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board2[i, j]);
                    Console.Write(" ");
                }

                Console.Write("\n");
            }
        }

        public void Test()
        {
            Solver solver = new Solver();
            /*int[,] board1 = new int[,]
            {
                { 3, 0, 6, 5, 0, 8, 4, 0, 0 },
                { 5, 2, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 8, 7, 0, 0, 0, 0, 3, 1 },
                { 0, 0, 3, 0, 1, 0, 0, 8, 0 },
                { 9, 0, 0, 8, 6, 3, 0, 0, 5 },
                { 0, 5, 0, 0, 9, 0, 6, 0, 0 },
                { 1, 3, 0, 0, 0, 0, 2, 5, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 7, 4 },
                { 0, 0, 5, 2, 0, 6, 3, 0, 0 }
            };*/

            int[,] board1= new int[,]
            {
                { 5, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 }

            };
            Console.WriteLine("POSSIBILITIES:");
            Tuple<bool, int[,]> result = solver.SolveAllStepsByBT(board1);
            int[,] board = result.Item2;
            Console.WriteLine(result.Item1);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i, j]);
                    Console.Write(" ");
                }

                Console.Write("\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            board = new Board(this);
            solver = new Solver();
            board.GenerateBoard();
            solverMode = new SolverMode(this, board);
            gameMode = new GameMode(this, board);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test();
        }

        private void HideMenuPage()
        {
            this.SolverBtn.Visible = false;
            this.GameBtn.Visible = false;
            this.AboutBtn.Visible = false;
        }

        private void SolverBtn_Click(object sender, EventArgs e)
        {
            HideMenuPage();
            solverMode.Start();
        }

        private void GameBtn_Click(object sender, EventArgs e)
        {
            HideMenuPage();
            gameMode.Start();
        }

        private void SolveBtn_Click(object sender, EventArgs e)
        {
            Tuple<bool, int[,]> result = solver.SolveAllStepsByBT(board.GetBoard());
            if (result.Item1)
            {
                board.SetBoard(result.Item2);
            }
        }
    }
}
