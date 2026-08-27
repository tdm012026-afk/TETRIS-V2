using System.Drawing.Text;
using System.Reflection.Metadata.Ecma335;

namespace Tetris_V2
{
    public partial class GameForm : Form
    {
        private const int GridWidth = 10;
        private const int GridHeight = 20;
        private const int CellSize = 30;

        private Color[,] grid = new Color[GridWidth, GridHeight];
        private Tetromino currentBlock;
        private readonly TetrominoFactory factory = new TetrominoFactory();
        private readonly TetrominoRotation rotation = new TetrominoRotation();
        private readonly System.Windows.Forms.Timer timer = new();


        public GameForm()
        {
            InitializeComponent();

            KeyDown += GameForm_KeyDown;

            timer.Interval = 500;
            timer.Tick += UpdateGame; 



            ClientSize = new Size(
                GridWidth * CellSize,
                GridHeight * CellSize
                );
            CreateNewBlock();

            timer.Start();
   
        }
        private void UpdateGame(object? sender, EventArgs e)
        {
            if (CanMoveDown())
            {
                currentBlock.Y++;
            }
            else
            {
                LockBlock();
                ClearCompletedLines();
                CreateNewBlock();
            }

            Invalidate();
        }
        private void LockBlock()
        {
            for (int row = 0; row < currentBlock.Shape.GetLength(0); row++)
            {
                for (int col = 0; col < currentBlock.Shape.GetLength(1); col++)
                {
                    if (currentBlock.Shape[row, col]== 1)
                    {
                        int gridX = currentBlock.X + col;
                        int gridY = currentBlock.Y + row;

                        grid[gridX, gridY] = currentBlock.Color;
                    }
                }
            }
        }
        private void ClearCompletedLines()
        {
            for (int y = 0; y < GridHeight; y++)
            {
                bool isFull = true;

                for (int x = 0; x < GridWidth; x++)
                {
                    if (grid[x, y] == Color.Empty)
                    {
                        isFull = false;
                        break;
                    }
                }
                if (isFull)
                {
                    for (int x = 0; x < GridWidth; x++)
                    {
                        grid[x, y] = Color.Empty;
                    }
                    for (int moveY = y; moveY < 0; moveY--)
                    {
                        for (int x = 0; x < GridWidth; x++)
                        {
                            grid[x, moveY] = grid[x, moveY - 1];
                        }
                    }
                }
            }
        }
        private void CreateNewBlock()
        {
            currentBlock = factory.Create();

            currentBlock.X = 4;
            currentBlock.Y = 0;
        }
        private bool CanMoveDown()
        {
            for (int row = 0; row < currentBlock.Shape.GetLength(0); row++)
            {
                for (int col = 0; col < currentBlock.Shape.GetLength(1); col++)
                {
                    if (currentBlock.Shape[row, col] == 1)
                    {
                        int gridX = currentBlock.X + col;
                        int gridY = currentBlock.Y + row + 1;

                        if (gridY >= GridHeight)
                        {
                            return false;
                        }
                        if (grid[gridX,gridY] != Color.Empty)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        private void GameForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && CanMoveLeft())
            {
                currentBlock.X--;
                Invalidate();
            }
            if (e.KeyCode == Keys.Right && CanMoveRight())
            {
                currentBlock.X++;
                Invalidate();
            }
            if (e.KeyCode == Keys.Down && CanMoveDown())
            {
                currentBlock.Y++;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            for(int x = 0; x < GridWidth; x++)
            {
                for (int y = 0; y < GridHeight; y++)
                {
                    Rectangle rect = new Rectangle(
                        x * CellSize,
                        y * CellSize,
                        CellSize,
                        CellSize);

                    g.FillRectangle(Brushes.Black, rect);
                    g.DrawRectangle(Pens.White, rect);
                    
                }
            }
            for (int row = 0; row < currentBlock.Shape.GetLength(0); row++)
            {
                for (int col = 0; col < currentBlock.Shape.GetLength(1); col++)
                {
                    if (currentBlock.Shape[row, col] == 1)
                    {
                        int drawX = (currentBlock.X + col) * CellSize;
                        int drawY = (currentBlock.Y + row) * CellSize;

                        g.FillRectangle(
                            new SolidBrush(currentBlock.Color),
                            drawX,
                            drawY,
                            CellSize,
                            CellSize);
                        
                        g.DrawRectangle(
                            Pens.White,
                            drawX,
                            drawY,
                            CellSize,
                            CellSize);

                    } 
                }
            }
            for (int x = 0; x < GridWidth; x++)
            {
                for (int y = 0; y < GridHeight; y++)
                {
                    if (grid[x, y] != Color.Empty)
                    {
                        int drawX = x * CellSize;
                        int drawY = y * CellSize;

                        using (Brush brush = new SolidBrush(grid[x, y]))

                            g.FillRectangle(
                                brush,
                                drawX,
                                drawY,
                                CellSize,
                                CellSize);
                    }
                }
            }
        }
        private bool CanMoveLeft()
        {
            for (int row = 0; row < currentBlock.Shape.GetLength(0); row++)
            {
                for (int col = 0; col < currentBlock.Shape.GetLength(1); col++)
                {
                    if (currentBlock.Shape[row, col] == 1)
                    {
                        int gridX = currentBlock.X + col - 1;
                        int gridY = currentBlock.Y + row;

                        if (gridX < 0)
                        {
                            return false;
                        }
                        if (grid[gridX,gridY] != Color.Empty)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        private bool CanMoveRight()
        {
            for (int row = 0; row < currentBlock.Shape.GetLength(0); row++)
            {
                for (int col = 0; col < currentBlock.Shape.GetLength(1); col++)
                {
                    if (currentBlock.Shape[row, col] == 1)
                    {
                        int gridX = currentBlock.X + col + 1;
                        int gridY = currentBlock.Y + row;

                        if(gridX >= GridWidth)
                        {
                            return false;
                        }
                        if (grid[gridX, gridY] != Color.Empty)
                        {
                            return false;
                        }


                    }
                }
            }
            return true;
        }
       




    }
}
