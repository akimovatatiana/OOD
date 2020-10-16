using Painter;
using System;
using System.Windows;

namespace PainterVisualization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Drawing();
        }

        private void Drawing()
        {
            var factory = new ShapeFactory();
            var designer = new Designer(factory);
            var wpfCanvas = (System.Windows.Controls.Canvas)FindName("canvas");
            var canvas = new Canvas(wpfCanvas);
            var painter = new Painter.Painter();

            Console.WriteLine("Enter commands to draw shapes. Enter 'exit' to see the result");
            Console.WriteLine("Usage: RegularPolygon <color> <center> <radius> <vertexCount>");
            Console.WriteLine("Usage: Triangle <color> <vertex1> <vertex2> <vertex3>");
            Console.WriteLine("Usage: Rectangle <color> <leftTop> <rightBottom>");
            Console.WriteLine("Usage: Ellipse <color> <center> <horisontalRadius> <verticalRadius>");
            
            var draft = designer.CreateDraft(Console.In);
            painter.DrawPicture(draft, canvas);
        }
    }
}
