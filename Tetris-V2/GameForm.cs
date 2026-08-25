namespace Tetris_V2
{
    public partial class GameForm : Form
    {
        private const int GridWidth = 10;
        private const int GridHeight = 20;
        private const int CellSize = 30;

        private int[,] grid = new int[GridWidth, GridHeight];
        public GameForm()
        {
            InitializeComponent();

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
        }
        

    }
}
