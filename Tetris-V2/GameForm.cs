namespace Tetris_V2
{
    public partial class GameForm : Form
    {
        private const int GridWidth = 10;
        private const int GridHeight = 20;
        private const int CellSize = 30;

        private int[,] grid = new int[GridWidth, GridHeight];
        private Tetromino currentBlock; 
        public GameForm()
        {
            InitializeComponent();

            int[,] shape =
            {
                {0, 1, 0 },
                {1, 1, 1 },
                {0, 0, 0 }
            };
            currentBlock = new Tetromino(shape, Color.Red);

            ClientSize = new Size(
                GridWidth * CellSize,
                GridHeight * CellSize
                );
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
        }
        

    }
}
