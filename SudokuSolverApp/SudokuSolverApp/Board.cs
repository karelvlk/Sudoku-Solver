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
        int[,] filledBoard = new int[9, 9];
        Entity[,] entityBoard = new Entity[9,9];
        Form1 form;
        public bool isColored = false;

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
            form.HideInfoBox();
            board[x, y] = val;
        }

        public int[,] GetBoard()
        {
            return board;
        }

        public void SetBoardInit(int[,] board)
        {
            this.board = board;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] != 0)
                    {
                        entityBoard[i, j].SetIsDefault(true);
                    }
                    entityBoard[i, j].SetValue(board[i, j]);
                    entityBoard[i, j].SetVisibility(true);
                }
            }
        }

        public void SetBoard(int[,] board)
        {
            this.board = board;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    entityBoard[i, j].SetValue(board[i, j]);
                    entityBoard[i, j].SetVisibility(true);
                }
            }
        }

        public void SetFilledBoard(int[,] board)
        {
            this.filledBoard = board;
        }

        public int[,] GetFilledBoard()
        {
            return filledBoard;
        }
        public void HideAndResetBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    entityBoard[i, j].SetIsDefault(false);
                    entityBoard[i, j].SetValue(0);
                    entityBoard[i, j].SetVisibility(false);
                }
            }
        }

        public Entity GetEntity(int x, int y)
        {
            return entityBoard[x, y];
        }

        public void GreenAll(bool zerosIncluded)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    GreenEntity(i, j, zerosIncluded);
                }
            }
        }

        public void RedAll(bool zerosIncluded)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    RedEntity(i, j, zerosIncluded);
                }
            }
        }

        public void SetDefaultColorForAll()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    GreyEntity(i, j);
                }
            }
        }

        public void GreyEntity(int i, int j)
        {
            isColored = false;
            entityBoard[i, j].SetDefaultColor();
         
        }

        public void GreenEntity(int i, int j, bool zerosIncluded)
        {
            isColored = true;
            if (zerosIncluded || board[i, j] != 0)
            {
                entityBoard[i, j].SetGreenColor();
            }
        }

        public void RedEntity(int i, int j, bool zerosIncluded)
        {
            isColored = true;
            if (zerosIncluded || board[i, j] != 0)
            {
                entityBoard[i, j].SetRedColor();
            }
        }

        public void BlueEntity(int i, int j)
        {
            isColored = true;
            entityBoard[i, j].SetBlueColor();
        }
    }

    class Entity
    {
        TextBox textBox1;
        Board board;
        int i;
        int j;
        int color;
        bool isDefault = false;
        public Entity(Form form, int offsetX, int offsetY, Board board, int i, int j)
        {
            this.i = i;
            this.j = j;
            this.color = GetColor(i, j);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.board = board;
            CreateFormElement(form, offsetX, offsetY);
        }

        int GetColor(int x, int y)
        {
            int row = x / 3;
            int col = y / 3;
            if (col == 0 || col == 2)
            {
                if (row == 1)
                {
                    return 1;
                } 
                else
                {
                    return 0;
                }
            } 
            else
            {
                if (row == 1)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
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
            SetDefaultColor();
        }

        public void SetIsDefault(bool isDefault)
        {
            this.isDefault = isDefault;
            this.textBox1.ReadOnly = isDefault;
            if (isDefault)
            {
                this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            }
            else
            {
                this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            }
            
        }

        void ProcessTextChange(object sender, System.EventArgs e)
        {
            if (board.isColored)
            {
                board.SetDefaultColorForAll();
            }
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
            )
            {
                this.board.SetValueFromTextChange(Convert.ToInt32(textBox1.Text), this.i, this.j);
            }
            else
            {
                this.board.SetValueFromTextChange(0, this.i, this.j);
                SetValue(0);
            }
            
        }

        public void SetRedColor()
        {
            if (color == 0)
            {
                this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            }
            else
            {
                this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            }
        }

        public void SetBlueColor()
        {
            if (color == 0)
            {
                this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            }
            else
            {
                this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            }
        }

        public void SetGreenColor()
        {
            if (color == 0)
            {
                this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(0)))));
            }
            else
            {
                this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            }
        }

        public void SetDefaultColor()
        {
            if (color == 0)
            {
                this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            }
            else
            {
                this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
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
