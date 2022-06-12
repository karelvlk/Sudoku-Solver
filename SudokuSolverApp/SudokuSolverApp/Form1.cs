using System;
using System.Windows.Forms;

namespace SudokuSolverApp
{
    public partial class Form1 : Form
    {
        SolverMode solverMode;
        GameMode gameMode;
        Board board;

        public Form1()
        {
            InitializeComponent();
        }

        public void SetEasyOptionCheck(bool isChecked)
        {
            this.EasyOption.Checked = isChecked;
            gameMode.SetDifficulty(1);
        } 

        public void SetVisibilityResetBtn(bool isVisible)
        {
            this.ResetBtn.Visible = isVisible;
        }

        public void SetVisibilityBackToMenu(bool isVisible)
        {
            this.BackToMenuButton.Visible = isVisible;
        }

        public void HideInfoBox()
        {
            this.InfoBox.Visible = false;
        }

        public void SetSolveButtonVisible()
        {
            this.SolveBtn.Visible = true;
        }

        public void SetModeButtonsVisible()
        {
            this.DifficultyLabel.Visible = true;
            this.EasyOption.Visible = true;
            this.MediumOption.Visible = true;
            this.HardOption.Visible = true;
            this.ExtremeOption.Visible = true;
        }

        public void HideGameMenuPage()
        {
            this.DifficultyLabel.Visible = false;
            this.EasyOption.Visible = false;
            this.MediumOption.Visible = false;
            this.HardOption.Visible = false;
            this.ExtremeOption.Visible = false;
            this.ContinueBtn.Visible = false;
        }

        public void ShowGameModeButtons()
        {
            this.HintBtn.Visible = true;
            this.CheckBtn.Visible = true;
        }

        public void SetContinueButtonVisible()
        {
            this.ContinueBtn.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            board = new Board(this);
            board.GenerateBoard();
            solverMode = new SolverMode(this, board);
            gameMode = new GameMode(this, board);
            
        }

        private void HideMenuPage()
        {
            this.SolverBtn.Visible = false;
            this.GameBtn.Visible = false;
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

        public void SetInfoBoxMessageRed(string text)
        {
            this.InfoBox.ForeColor = System.Drawing.Color.Red;
            this.InfoBox.Text = text;
            this.InfoBox.Visible = true;
        }

        public void SetInfoBoxMessageGreen(string text)
        {
            this.InfoBox.ForeColor = System.Drawing.Color.Green;
            this.InfoBox.Text = text;
            this.InfoBox.Visible = true;
        }

        private void SolveBtn_Click(object sender, EventArgs e)
        {
            solverMode.Solve();
        }

        private void EasyOption_CheckedChanged(object sender, EventArgs e)
        {
            gameMode.SetDifficulty(1);
        }

        private void MediumOption_CheckedChanged(object sender, EventArgs e)
        {
            gameMode.SetDifficulty(2);
        }

        private void HardOption_CheckedChanged(object sender, EventArgs e)
        {
            gameMode.SetDifficulty(3);
        }

        private void ExtremeOption_CheckedChanged(object sender, EventArgs e)
        {
            gameMode.SetDifficulty(4);
        }

        private void ContinueBtn_Click(object sender, EventArgs e)
        {
            gameMode.StartGame();
        }

        private void BackToMenuButton_Click(object sender, EventArgs e)
        {
            this.GameBtn.Visible = true;
            this.SolverBtn.Visible = true;
            this.EasyOption.Visible = false;
            this.DifficultyLabel.Visible = false;
            this.MediumOption.Visible = false;
            this.HardOption.Visible = false;
            this.ExtremeOption.Visible = false;
            this.HintBtn.Visible = false;
            this.CheckBtn.Visible = false;
            this.ContinueBtn.Visible = false;
            this.SolveBtn.Visible = false;
            this.InfoBox.Visible = false;
            this.ResetBtn.Visible = false;
            this.BackToMenuButton.Visible = false;
            board.HideAndResetBoard();
        }

        private void CheckBtn_Click(object sender, EventArgs e)
        {
            gameMode.Check();
        }

        private void HintBtn_Click(object sender, EventArgs e)
        {
            gameMode.DoHint();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            solverMode.Reset();
        }
    }
}
