using Adapter.Adapters;
using Adapter.GraphicsLib;
using Adapter.ModernGraphicsLib;
using Adapter.ShapeDrawingLib;
using System;
using Point = Adapter.ShapeDrawingLib.Point;

namespace Adapter.App
{
    public class App
    {
        public static void PaintPicture(CanvasPainter painter)
        {
            Triangle triangle = new Triangle(new Point(10, 15), new Point(100, 200), new Point(150, 250));
            Rectangle rectangle = new Rectangle(new Point(30, 40), 18, 24, 0x6B8E23);

            Console.WriteLine("Triangle:");
            painter.Draw(triangle);
            Console.WriteLine("Rectangle:");
            painter.Draw(rectangle);
        }

        public static void PaintPictureOnCanvas()
        {
            Canvas simpleCanvas = new Canvas();
            CanvasPainter painter = new CanvasPainter(simpleCanvas);
            PaintPicture(painter);
        }

        public static void PaintPictureOnMGRObjectAdapter()
        {
            ModernGraphicsRenderer renderer = new ModernGraphicsRenderer(Console.Out);
            ObjectAdapter objectAdapter = new ObjectAdapter(renderer);
            CanvasPainter painter = new CanvasPainter(objectAdapter);

            try
            {
                renderer.BeginDraw();
                PaintPicture(painter);
                renderer.EndDraw();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void PaintPictureOnMGRClassAdapter()
        {
            ClassAdapter classAdapter = new ClassAdapter(Console.Out);
            CanvasPainter painter = new CanvasPainter(classAdapter);

            try
            {
                classAdapter.BeginDraw();
                PaintPicture(painter);
                classAdapter.EndDraw();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
