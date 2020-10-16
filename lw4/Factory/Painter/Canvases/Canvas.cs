﻿using Painter.Enums;
using Painter.Shapes;
using System;

namespace Painter.Canvases
{
    public class Canvas : ICanvas
    {
        private Color _color;

        public void SetColor(Color color)
        {
            _color = color;
        }

        public void DrawLine(Point from, Point to)
        {
            Console.WriteLine($"{ColorToString()} line from {from}, to {to}");
        }

        public void DrawEllipse(Point center, double w, double h)
        {
            Console.WriteLine($"{ColorToString()} ellipse with center: {center}; width: {w}; height: {h}");
        }

        private string ColorToString()
        {
            return _color switch
            {
                Color.Green => "Green",
                Color.Red => "Red",
                Color.Blue => "Blue",
                Color.Yellow => "Yellow",
                Color.Pink => "Pink",
                Color.Black => "Black",
                _ => "Black",
            };
        }
    }
}
