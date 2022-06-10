using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolverApp
{
    class Board
    {
        int[,] board = new int[9, 9];
        Entity[,] entityBoard = new Entity[9,9];
        Form1 form;

        public Board(Form1 form)
        {
            this.form = form;
        }

        public void GenerateBoard()
        {

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    entityBoard[i, j] = new Entity(form, i * 55, j * 55, this, i, j);
                }
            }
        }

        public void SetValue(int val, int x, int y)
        {
            board[x, y] = val;
            entityBoard[x, y].SetValue(val);
            entityBoard[x, y].SetVisibility(true);
        }

        public void SetValueFromTextChange(int val, int x, int y)
        {
            board[x, y] = val;
        }

        public int[,] GetBoard()
        {
            return board;
        }

        public void SetBoard(int[,] board)
        {
            this.board = board;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    entityBoard[i, j].SetValue(board[i, j]);
                }
            }
        }

        public Entity GetEntity(int x, int y)
        {
            return entityBoard[x, y];
        }
    }

    class Entity
    {
        TextBox textBox1;
        Board board;
        int i;
        int j;
        public Entity(Form form, int offsetX, int offsetY, Board board, int i, int j)
        {
            this.i = i;
            this.j = j;
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.board = board;
            CreateFormElement(form, offsetX, offsetY);
        }
        public void CreateFormElement(Form form, int offsetX, int offsetY)
        {
            this.textBox1.Font = new System.Drawing.Font("Play", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(267+offsetX, 94+offsetY);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(50, 50);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.ProcessTextChange);
            form.Controls.Add(this.textBox1);
        }

        void ProcessTextChange(object sender, System.EventArgs e)
        {
            if (
                textBox1.Text == "1" ||
                textBox1.Text == "2" ||
                textBox1.Text == "3" ||
                textBox1.Text == "4" ||
                textBox1.Text == "5" ||
                textBox1.Text == "6" ||
                textBox1.Text == "7" ||
                textBox1.Text == "8" ||
                textBox1.Text == "9"
            ) {
                this.board.SetValueFromTextChange(Convert.ToInt32(textBox1.Text), this.i, this.j);
            } 
            else
            {
                this.board.SetValueFromTextChange(0, this.i, this.j);
                SetValue(0);
            }
        }

        public void SetVisibility(bool isVisible)
        {
            this.textBox1.Visible = isVisible;
        }

        public void SetValue(int value)
        {
            if (value == 0)
            {
                this.textBox1.Text = "";
            }
            else
            {
                this.textBox1.Text = Convert.ToString(value);
            }
            
        }
    }
}
