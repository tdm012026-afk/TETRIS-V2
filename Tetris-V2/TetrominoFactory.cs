using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Tetris_V2
{
    public class TetrominoFactory
    {
        public readonly Random random = new Random();

        public Tetromino Create()
        {
            int type = random.Next(7);

            switch (type)
            {
                case 0:
                    {
                        int[,] shape =
                        {
                            {1, 1, 1, 1 }
                        };
                        return new Tetromino(shape, Color.Cyan);                     
                    }

                case 1:
                    {
                        int[,] shape =
                        {
                            {1, 1 },
                            {1, 1 }
                        };
                        return new Tetromino(shape, Color.Red);
                    }

                case 2:
                    {
                        int[,] shape =
                        {
                            {1, 1, 1 },
                            {0, 1, 0 }
                        };
                        return new Tetromino(shape, Color.Green);
                    }
                                       
                case 3:
                    {
                        int[,] shape =
                        {
                            {1, 0 },
                            {1, 0 },
                            {1, 1 }
                        };
                        return new Tetromino(shape, Color.Blue);
                    }

                case 4:
                    {
                        int[,] shape =
                        {
                            {0, 1 },
                            {0, 1 },
                            {1, 1 }
                        };
                        return new Tetromino(shape, Color.Orange);
                    }
                        
                case 5:
                    {
                        int[,] shape =
                        {
                            {0, 1, 1 },
                            {1, 1, 0 }
                        };
                        return new Tetromino(shape, Color.Purple);
                    }
                case 6:
                    {
                        int[,] shape =
                        {
                            {1, 1, 0 },
                            {0, 1, 1 }
                        };
                        return new Tetromino(shape, Color.Yellow);
                    } 
            }
            throw new InvalidOperationException("Invalid block type");

        }
    }
}
