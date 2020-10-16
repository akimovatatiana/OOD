using Microsoft.VisualStudio.TestTools.UnitTesting;
using Painter;
using Painter.Enums;
using Painter.Shapes;
using System;

namespace PainterTests
{
    [TestClass]
    public class ShapeFactoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateShape_WithInvalidShapeType_ShouldThrowException()
        {
            var shapeFactory = new ShapeFactory();
            shapeFactory.CreateShape("rectang red 5 3 3 10");
            shapeFactory.CreateShape("rectangler red 5 3 3 10");
            shapeFactory.CreateShape("red 5 3 3 10");
            shapeFactory.CreateShape("rectangle red 5 3 3");
            shapeFactory.CreateShape("rectangle red 5 3 3 3 10");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void CreateShape_WithInvalidArgs_ShouldThrowException()
        {
            var shapeFactory = new ShapeFactory();
            shapeFactory.CreateShape("Ellipse red 5 5 10 h");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateShape_WithInvalidColor_ShouldThrowException()
        {
            var shapeFactory = new ShapeFactory();
            shapeFactory.CreateShape("Ellipse brown 5 5 10 5");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateShape_RegularPolygon_WithInvalidArgsCount_ShouldThrowException()
        {
            var shapeFactory = new ShapeFactory();
            shapeFactory.CreateShape("RegularPolygon red 3 3 10");
            shapeFactory.CreateShape("RegularPolygon red 3 3 10 10 10");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateShape_Rectangle_WithInvalidArgsCount_ShouldThrowException()
        {
            var shapeFactory = new ShapeFactory();
            shapeFactory.CreateShape("Rectangle red 5 3 3 10");
            shapeFactory.CreateShape("Rectangle red 5 3 3 10 10");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateShape_Triangle_WithInvalidArgsCount_ShouldThrowException()
        {
            var shapeFactory = new ShapeFactory();
            shapeFactory.CreateShape("Triangle red 5 3 3 10");
            shapeFactory.CreateShape("Triangle red 5 3 2 5 8 9 1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateShape_Ellipse_WithInvalidArgsCount_ShouldThrowException()
        {
            var shapeFactory = new ShapeFactory();
            shapeFactory.CreateShape("Ellipse red 5 5 10");
            shapeFactory.CreateShape("Ellipse red 5 5 10 5 10");
        }

        [TestMethod]
        public void CreateShape_RegularPolygon_WithValidArgs()
        {
            var shapeFactory = new ShapeFactory();

            var center = new Point(5, 5);
            double radius = 5;
            int vertexCount = 6;
            var color = Color.Red;

            var regularPolygon = new RegularPolygon(center, radius, vertexCount, color);

            var shape = (RegularPolygon)shapeFactory.CreateShape($"RegularPolygon red {center.X} {center.Y} {radius} {vertexCount}");
            Assert.AreEqual(regularPolygon.Color, shape.Color);
            Assert.AreEqual(regularPolygon.Center.X, shape.Center.X);
            Assert.AreEqual(regularPolygon.Center.Y, shape.Center.Y);
            Assert.AreEqual(regularPolygon.Radius, shape.Radius);
            Assert.AreEqual(regularPolygon.VertexCount, shape.VertexCount);
        }

        [TestMethod]
        public void CreateShape_Triangle_WithValidArgs()
        {
            var shapeFactory = new ShapeFactory();
            
            var vertex1 = new Point(-2, 3);
            var vertex2 = new Point(4, 3);
            var vertex3 = new Point(2, 5);
            var color = Color.Red;

            var triangle = new Triangle(vertex1, vertex2, vertex3, color);

            var shape = (Triangle)shapeFactory.CreateShape($"Triangle red {vertex1.X} {vertex1.Y} {vertex2.X} {vertex2.Y} {vertex3.X} {vertex3.Y}");
            Assert.AreEqual(triangle.Color, shape.Color);
            Assert.AreEqual(triangle.Vertex1.X, shape.Vertex1.X);
            Assert.AreEqual(triangle.Vertex1.Y, shape.Vertex1.Y);
            Assert.AreEqual(triangle.Vertex2.X, shape.Vertex2.X);
            Assert.AreEqual(triangle.Vertex2.Y, shape.Vertex2.Y);
            Assert.AreEqual(triangle.Vertex3.X, shape.Vertex3.X);
            Assert.AreEqual(triangle.Vertex3.Y, shape.Vertex3.Y);
        }

        [TestMethod]
        public void CreateShape_Rectangle_WithValidArgs()
        {
            var shapeFactory = new ShapeFactory();

            var leftTop = new Point(3, 5);
            var rightBottom = new Point(3, 7.5);
            var color = Color.Red;

            var rectangle = new Rectangle(leftTop, rightBottom, color);

            var shape = (Rectangle)shapeFactory.CreateShape($"Rectangle red {leftTop.X} {leftTop.Y} {rightBottom.X} {rightBottom.Y}");
            Assert.AreEqual(rectangle.Color, shape.Color);
            Assert.AreEqual(rectangle.LeftTop.X, shape.LeftTop.X);
            Assert.AreEqual(rectangle.LeftTop.Y, shape.LeftTop.Y);
            Assert.AreEqual(rectangle.RightBottom.X, shape.RightBottom.X);
            Assert.AreEqual(rectangle.RightBottom.Y, shape.RightBottom.Y);
        }

        [TestMethod]
        public void CreateShape_Ellipse_WithValidArgs()
        {
            var shapeFactory = new ShapeFactory();

            var center = new Point(5, 5);
            double horizontalRadius = 10;
            double verticalRadius = 5.6;
            var color = Color.Red;

            var ellipse = new Ellipse(center, horizontalRadius, verticalRadius, color);

            var shape = (Ellipse)shapeFactory.CreateShape($"Ellipse red {center.X} {center.Y} {horizontalRadius} {verticalRadius}");
            Assert.AreEqual(ellipse.Color, shape.Color);
            Assert.AreEqual(ellipse.Center.X, shape.Center.X);
            Assert.AreEqual(ellipse.Center.Y, shape.Center.Y);
            Assert.AreEqual(ellipse.HorizontalRadius, shape.HorizontalRadius);
            Assert.AreEqual(ellipse.VerticalRadius, shape.VerticalRadius);
        }
    }
}
