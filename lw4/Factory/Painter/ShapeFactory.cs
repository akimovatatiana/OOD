using Painter.Enums;
using Painter.Shapes;
using System;

namespace Painter
{
    public class ShapeFactory : IShapeFactory
    {
        public Shape CreateShape(string description)
        {
            var args = description.Split();
            return (args[0].ToLower()) switch
            {
                "rectangle" => CreateRectangle(args),
                "triangle" => CreateTriangle(args),
                "ellipse" => CreateEllipse(args),
                "regularpolygon" => CreateRegularPolygon(args),
                _ => throw new ArgumentException($"Failed to create shape named {args[1]}."),
            };
        }

        private Shape CreateRegularPolygon(string[] args)
        {
            if (args.Length == 6)
            {
                Color color = ToColor(args[1]);
                Point center = new Point(Convert.ToDouble(args[2]), Convert.ToDouble(args[3]));
                double radius = Convert.ToDouble(args[4]);
                int vertexCount = Convert.ToInt32(args[5]);
           
                return new RegularPolygon(center, radius, vertexCount, color);
            }
            else
            {
                throw new ArgumentException("Failed to create a regular polygon.\nUsage: RegularPolygon <color> <center> <radius> <vertexCount>");
            }
        }

        private Shape CreateTriangle(string[] args)
        {
            if (args.Length == 8)
            {
                Color color = ToColor(args[1]);
                Point vertex1 = new Point(Convert.ToDouble(args[2]), Convert.ToDouble(args[3]));
                Point vertex2 = new Point(Convert.ToDouble(args[4]), Convert.ToDouble(args[5]));
                Point vertex3 = new Point(Convert.ToDouble(args[6]), Convert.ToDouble(args[7]));
                
                return new Triangle(vertex1, vertex2, vertex3, color);
            }
            else
            {
                throw new ArgumentException("Failed to create a triangle.\nUsage: Triangle <color> <vertex1> <vertex2> <vertex3>");
            }
        }

        private Shape CreateRectangle(string[] args)
        {
            if (args.Length == 6)
            {
                Color color = ToColor(args[1]);
                Point leftTop = new Point(Convert.ToDouble(args[2]), Convert.ToDouble(args[3]));
                Point rightBottom = new Point(Convert.ToDouble(args[4]), Convert.ToDouble(args[5]));
                
                return new Rectangle(leftTop, rightBottom, color);
            }
            else
            {
                throw new ArgumentException("Failed to create a rectangle.\nUsage: Rectangle <color> <leftTop> <rightBottom>");
            }
        }

        private Shape CreateEllipse(string[] args)
        {
            if (args.Length == 6)
            {
                Color color = ToColor(args[1]);
                Point center = new Point(Convert.ToDouble(args[2]), Convert.ToDouble(args[3]));
                double horizontalRadius = Convert.ToDouble(args[4]);
                double verticalRadius = Convert.ToDouble(args[5]);

                return new Ellipse(center, horizontalRadius, verticalRadius, color);
            }
            else
            {
                throw new ArgumentException("Failed to create an ellipse.\nUsage: Ellipse <color> <center> <horisontalRadius> <verticalRadius>");
            }
        }

        private Color ToColor(string arg)
        {
            return arg.ToLower() switch
            {
                "green" => Color.Green,
                "red" => Color.Red,
                "blue" => Color.Blue,
                "yellow" => Color.Yellow,
                "pink" => Color.Pink,
                "black" => Color.Black,
                _ => throw new Exception("Incorrect color. You can choose color from [green, red, blue, yellow, pink, black]"),
            };
        }
    }
}
