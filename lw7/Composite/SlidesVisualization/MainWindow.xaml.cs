using Slides;
using Slides.Groups;
using Slides.Shapes;
using Slides.Styles;
using System.Windows;

namespace SlidesVisualization
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
            var wpfCanvas = (System.Windows.Controls.Canvas)FindName("canvas");
            var canvas = new Canvas(wpfCanvas);
            var slide = new Slide(1000, 700, new RGBAColor(137, 196, 244, 50));

            var grassFrame = new Rect<double>(0, 500, 1000, 200);
            var grassFillStyle = new Slides.Styles.Style(new RGBAColor(135, 211, 124, 255), true);
            var grass = new Rectangle(grassFrame, null, grassFillStyle);

            var lakeFrame = new Rect<double>(600, 500, 300, 100);
            var lakeFillStyle = new Slides.Styles.Style(new RGBAColor(44, 130, 201, 255), true);
            var lakeOutlineStyle = new OutlineStyle(new RGBAColor(1, 50, 67, 255), true, 2);
            var lake = new Ellipse(lakeFrame, lakeOutlineStyle, lakeFillStyle);

            var house = new GroupShape();

            var baseFrame = new Rect<double>(100, 400, 300, 200);
            var baseFillStyle = new Slides.Styles.Style(new RGBAColor(205, 133, 63, 255), true);
            var baseOutlineStyle = new OutlineStyle(new RGBAColor(139, 69, 19, 255), true, 2);
            var baseShape = new Rectangle(baseFrame, baseOutlineStyle, baseFillStyle);

            var roofFrame = new Rect<double>(50, 300, 400, 100);
            var roofFillStyle = new Slides.Styles.Style(new RGBAColor(46, 49, 49, 255), true);
            var roof = new Triangle(roofFrame, null, roofFillStyle);

            var pipeFrame = new Rect<double>(330, 300, 50, 90);
            var pipeFillStyle = new Slides.Styles.Style(new RGBAColor(128, 0, 0, 255), true);
            var pipeOutlineStyle = new OutlineStyle(new RGBAColor(255, 222, 173, 255), true, 2);
            var pipe = new Rectangle(pipeFrame, pipeOutlineStyle, pipeFillStyle);

            house.InsertShape(baseShape, 0);
            house.InsertShape(pipe, 1);
            house.InsertShape(roof, 2);

            slide.InsertShape(grass);
            slide.InsertShape(lake, 1);
            slide.InsertShape(house, 2);
            slide.Draw(canvas);
        }
    }
}
