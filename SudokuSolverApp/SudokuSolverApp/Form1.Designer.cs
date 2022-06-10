
namespace SudokuSolverApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GameBtn = new System.Windows.Forms.Button();
            this.SolverBtn = new System.Windows.Forms.Button();
            this.AboutBtn = new System.Windows.Forms.Button();
            this.EasyOption = new System.Windows.Forms.RadioButton();
            this.MediumOption = new System.Windows.Forms.RadioButton();
            this.HardOption = new System.Windows.Forms.RadioButton();
            this.ExtremeOption = new System.Windows.Forms.RadioButton();
            this.ContinueBtn = new System.Windows.Forms.Button();
            this.HintBtn = new System.Windows.Forms.Button();
            this.CheckBtn = new System.Windows.Forms.Button();
            this.SolveBtn = new System.Windows.Forms.Button();
            this.BackToMenuButton = new System.Windows.Forms.Button();
            this.InfoBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "TEST BUTTON";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Play", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(267, 94);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(50, 50);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "1";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Play", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(0, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1010, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "SUDOKU by Karel Vlk";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameBtn
            // 
            this.GameBtn.BackColor = System.Drawing.Color.Aqua;
            this.GameBtn.Font = new System.Drawing.Font("Play", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GameBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GameBtn.Location = new System.Drawing.Point(412, 200);
            this.GameBtn.Name = "GameBtn";
            this.GameBtn.Size = new System.Drawing.Size(200, 70);
            this.GameBtn.TabIndex = 3;
            this.GameBtn.Text = "Game";
            this.GameBtn.UseVisualStyleBackColor = false;
            this.GameBtn.Click += new System.EventHandler(this.GameBtn_Click);
            // 
            // SolverBtn
            // 
            this.SolverBtn.BackColor = System.Drawing.Color.Aqua;
            this.SolverBtn.Font = new System.Drawing.Font("Play", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SolverBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SolverBtn.Location = new System.Drawing.Point(412, 300);
            this.SolverBtn.Name = "SolverBtn";
            this.SolverBtn.Size = new System.Drawing.Size(200, 70);
            this.SolverBtn.TabIndex = 4;
            this.SolverBtn.Text = "Solver";
            this.SolverBtn.UseVisualStyleBackColor = false;
            this.SolverBtn.Click += new System.EventHandler(this.SolverBtn_Click);
            // 
            // AboutBtn
            // 
            this.AboutBtn.BackColor = System.Drawing.Color.Aqua;
            this.AboutBtn.Font = new System.Drawing.Font("Play", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AboutBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AboutBtn.Location = new System.Drawing.Point(412, 400);
            this.AboutBtn.Name = "AboutBtn";
            this.AboutBtn.Size = new System.Drawing.Size(200, 70);
            this.AboutBtn.TabIndex = 5;
            this.AboutBtn.Text = "About";
            this.AboutBtn.UseVisualStyleBackColor = false;
            // 
            // EasyOption
            // 
            this.EasyOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EasyOption.Checked = true;
            this.EasyOption.Font = new System.Drawing.Font("Play", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EasyOption.ForeColor = System.Drawing.Color.Aqua;
            this.EasyOption.Location = new System.Drawing.Point(447, 220);
            this.EasyOption.Name = "EasyOption";
            this.EasyOption.Size = new System.Drawing.Size(130, 30);
            this.EasyOption.TabIndex = 0;
            this.EasyOption.TabStop = true;
            this.EasyOption.Text = "Easy";
            this.EasyOption.UseVisualStyleBackColor = false;
            this.EasyOption.Visible = false;
            this.EasyOption.CheckedChanged += new System.EventHandler(this.EasyOption_CheckedChanged);
            // 
            // MediumOption
            // 
            this.MediumOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MediumOption.Font = new System.Drawing.Font("Play", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MediumOption.ForeColor = System.Drawing.Color.Aqua;
            this.MediumOption.Location = new System.Drawing.Point(447, 260);
            this.MediumOption.Name = "MediumOption";
            this.MediumOption.Size = new System.Drawing.Size(130, 30);
            this.MediumOption.TabIndex = 7;
            this.MediumOption.TabStop = true;
            this.MediumOption.Text = "Medium";
            this.MediumOption.UseVisualStyleBackColor = false;
            this.MediumOption.Visible = false;
            this.MediumOption.CheckedChanged += new System.EventHandler(this.MediumOption_CheckedChanged);
            // 
            // HardOption
            // 
            this.HardOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.HardOption.Font = new System.Drawing.Font("Play", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HardOption.ForeColor = System.Drawing.Color.Aqua;
            this.HardOption.Location = new System.Drawing.Point(447, 300);
            this.HardOption.Name = "HardOption";
            this.HardOption.Size = new System.Drawing.Size(130, 30);
            this.HardOption.TabIndex = 8;
            this.HardOption.TabStop = true;
            this.HardOption.Text = "Hard";
            this.HardOption.UseVisualStyleBackColor = false;
            this.HardOption.Visible = false;
            this.HardOption.CheckedChanged += new System.EventHandler(this.HardOption_CheckedChanged);
            // 
            // ExtremeOption
            // 
            this.ExtremeOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ExtremeOption.Font = new System.Drawing.Font("Play", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExtremeOption.ForeColor = System.Drawing.Color.Aqua;
            this.ExtremeOption.Location = new System.Drawing.Point(447, 340);
            this.ExtremeOption.Name = "ExtremeOption";
            this.ExtremeOption.Size = new System.Drawing.Size(130, 30);
            this.ExtremeOption.TabIndex = 9;
            this.ExtremeOption.TabStop = true;
            this.ExtremeOption.Text = "Extreme";
            this.ExtremeOption.UseVisualStyleBackColor = false;
            this.ExtremeOption.Visible = false;
            this.ExtremeOption.CheckedChanged += new System.EventHandler(this.ExtremeOption_CheckedChanged);
            // 
            // ContinueBtn
            // 
            this.ContinueBtn.BackColor = System.Drawing.Color.Aqua;
            this.ContinueBtn.Font = new System.Drawing.Font("Play", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ContinueBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ContinueBtn.Location = new System.Drawing.Point(412, 400);
            this.ContinueBtn.Name = "ContinueBtn";
            this.ContinueBtn.Size = new System.Drawing.Size(200, 70);
            this.ContinueBtn.TabIndex = 10;
            this.ContinueBtn.Text = "Continue";
            this.ContinueBtn.UseVisualStyleBackColor = false;
            this.ContinueBtn.Visible = false;
            this.ContinueBtn.Click += new System.EventHandler(this.ContinueBtn_Click);
            // 
            // HintBtn
            // 
            this.HintBtn.BackColor = System.Drawing.Color.Aqua;
            this.HintBtn.Font = new System.Drawing.Font("Play", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HintBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.HintBtn.Location = new System.Drawing.Point(876, 677);
            this.HintBtn.Name = "HintBtn";
            this.HintBtn.Size = new System.Drawing.Size(120, 40);
            this.HintBtn.TabIndex = 11;
            this.HintBtn.Text = "Hint";
            this.HintBtn.UseVisualStyleBackColor = false;
            this.HintBtn.Visible = false;
            this.HintBtn.Click += new System.EventHandler(this.HintBtn_Click);
            // 
            // CheckBtn
            // 
            this.CheckBtn.BackColor = System.Drawing.Color.Aqua;
            this.CheckBtn.Font = new System.Drawing.Font("Play", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CheckBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CheckBtn.Location = new System.Drawing.Point(750, 677);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(120, 40);
            this.CheckBtn.TabIndex = 12;
            this.CheckBtn.Text = "Check";
            this.CheckBtn.UseVisualStyleBackColor = false;
            this.CheckBtn.Visible = false;
            this.CheckBtn.Click += new System.EventHandler(this.CheckBtn_Click);
            // 
            // SolveBtn
            // 
            this.SolveBtn.BackColor = System.Drawing.Color.Aqua;
            this.SolveBtn.Font = new System.Drawing.Font("Play", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SolveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SolveBtn.Location = new System.Drawing.Point(412, 647);
            this.SolveBtn.Name = "SolveBtn";
            this.SolveBtn.Size = new System.Drawing.Size(200, 70);
            this.SolveBtn.TabIndex = 13;
            this.SolveBtn.Text = "Solve";
            this.SolveBtn.UseVisualStyleBackColor = false;
            this.SolveBtn.Visible = false;
            this.SolveBtn.Click += new System.EventHandler(this.SolveBtn_Click);
            // 
            // BackToMenuButton
            // 
            this.BackToMenuButton.BackColor = System.Drawing.Color.Aqua;
            this.BackToMenuButton.Font = new System.Drawing.Font("Play", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BackToMenuButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackToMenuButton.Location = new System.Drawing.Point(12, 677);
            this.BackToMenuButton.Name = "BackToMenuButton";
            this.BackToMenuButton.Size = new System.Drawing.Size(246, 40);
            this.BackToMenuButton.TabIndex = 15;
            this.BackToMenuButton.Text = "Back to menu";
            this.BackToMenuButton.UseVisualStyleBackColor = false;
            this.BackToMenuButton.Click += new System.EventHandler(this.BackToMenuButton_Click);
            // 
            // InfoBox
            // 
            this.InfoBox.Font = new System.Drawing.Font("Play", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InfoBox.ForeColor = System.Drawing.Color.Black;
            this.InfoBox.Location = new System.Drawing.Point(365, 599);
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.Size = new System.Drawing.Size(300, 45);
            this.InfoBox.TabIndex = 16;
            this.InfoBox.Text = "Cannot be solved!";
            this.InfoBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.InfoBox.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.InfoBox);
            this.Controls.Add(this.BackToMenuButton);
            this.Controls.Add(this.HintBtn);
            this.Controls.Add(this.CheckBtn);
            this.Controls.Add(this.SolveBtn);
            this.Controls.Add(this.ContinueBtn);
            this.Controls.Add(this.ExtremeOption);
            this.Controls.Add(this.HardOption);
            this.Controls.Add(this.MediumOption);
            this.Controls.Add(this.EasyOption);
            this.Controls.Add(this.AboutBtn);
            this.Controls.Add(this.SolverBtn);
            this.Controls.Add(this.GameBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GameBtn;
        private System.Windows.Forms.Button SolverBtn;
        private System.Windows.Forms.Button AboutBtn;
        private System.Windows.Forms.RadioButton EasyOption;
        private System.Windows.Forms.RadioButton MediumOption;
        private System.Windows.Forms.RadioButton HardOption;
        private System.Windows.Forms.RadioButton ExtremeOption;
        private System.Windows.Forms.Button ContinueBtn;
        private System.Windows.Forms.Button HintBtn;
        private System.Windows.Forms.Button CheckBtn;
        private System.Windows.Forms.Button SolveBtn;
        private System.Windows.Forms.Button BackToMenuButton;
        private System.Windows.Forms.Label InfoBox;
    }
}

