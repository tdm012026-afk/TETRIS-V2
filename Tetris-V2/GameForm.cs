namespace Tetris_V2
{
    public partial class GameForm : Form
    {
        private const int GridWidth = 10;
        private const int GridHeight = 20;
        private const int Cellsize = 30;

        private int[,] grid = new int[GridWidth, GridHeight];
        public GameForm()
        {
            InitializeComponent();
        }
    }
}
