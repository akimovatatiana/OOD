using Painter.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Color = Painter.Enums.Color;

namespace Painter.Canvases
{
    public interface ICanvas
    {
        void SetColor(Color color);
        void DrawLine(Point from, Point to);
    }
}
