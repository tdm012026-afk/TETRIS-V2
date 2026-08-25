using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Tetris_V2
{
    public class Tetromino
    {
        public int[,] Shape {  get; set; }

        public Color Color { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Tetromino(int[,] shape, Color color)
        {
            Shape = shape;
            Color = color;
        } 


    }
}
