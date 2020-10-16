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
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void CreateShape_WithInvalidArgs_ShouldThrowsException()
        {
            var shapeFactory = new ShapeFactory();
            shapeFactory.CreateShape("Ellipse red 5 5 10 h");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateShape_WithInvalidColor_ShouldThrowsException()
        {
            var shapeFactory = new ShapeFactory();
            shapeFactory.CreateShape("Ellipse brown 5 5 10 5");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateShape_RegularPolygon_WithInvalidArgsCount_ShouldThrowsException()
        {
            var shapeFactory = new ShapeFactory();
            shapeFactory.CreateShape("RegularPolygon red 3 3 10");
            shapeFactory.CreateShape("RegularPolygon red 3 3 10 10 10");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateShape_Rectangle_WithInvalidArgsCount_ShouldThrowsException()
        {
            var shapeFactory = new ShapeFactory();
            shapeFactory.CreateShape("Rectangle red 5 3 3 10");
            shapeFactory.CreateShape("Rectangle red 5 3 3 10 10");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateShape_Triangle_WithInvalidArgsCount_ShouldThrowsException()
        {
            var shapeFactory = new ShapeFactory();
            shapeFactory.CreateShape("Triangle red 5 3 3 10");
            shapeFactory.CreateShape("Triangle red 5 3 2 5 8 9 1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateShape_Ellipse_WithInvalidArgsCount_ShouldThrowsException()
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
            Assert.AreEqual(regularPolygon.GetColor(), shape.GetColor());
            Assert.AreEqual(regularPolygon.GetCenter().X, shape.GetCenter().X);
            Assert.AreEqual(regularPolygon.GetCenter().Y, shape.GetCenter().Y);
            Assert.AreEqual(regularPolygon.GetRadius(), shape.GetRadius());
            Assert.AreEqual(regularPolygon.GetVertexCount(), shape.GetVertexCount());
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
            Assert.AreEqual(triangle.GetColor(), shape.GetColor());
            Assert.AreEqual(triangle.GetVertex1().X, shape.GetVertex1().X);
            Assert.AreEqual(triangle.GetVertex1().Y, shape.GetVertex1().Y);
            Assert.AreEqual(triangle.GetVertex2().X, shape.GetVertex2().X);
            Assert.AreEqual(triangle.GetVertex2().Y, shape.GetVertex2().Y);
            Assert.AreEqual(triangle.GetVertex3().X, shape.GetVertex3().X);
            Assert.AreEqual(triangle.GetVertex3().Y, shape.GetVertex3().Y);
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
            Assert.AreEqual(rectangle.GetColor(), shape.GetColor());
            Assert.AreEqual(rectangle.GetLeftTop().X, shape.GetLeftTop().X);
            Assert.AreEqual(rectangle.GetLeftTop().Y, shape.GetLeftTop().Y);
            Assert.AreEqual(rectangle.GetRightBottom().X, shape.GetRightBottom().X);
            Assert.AreEqual(rectangle.GetRightBottom().Y, shape.GetRightBottom().Y);
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
            Assert.AreEqual(ellipse.GetColor(), shape.GetColor());
            Assert.AreEqual(ellipse.GetCenter().X, shape.GetCenter().X);
            Assert.AreEqual(ellipse.GetCenter().Y, shape.GetCenter().Y);
            Assert.AreEqual(ellipse.GetHorizontalRadius(), shape.GetHorizontalRadius());
            Assert.AreEqual(ellipse.GetVerticalRadius(), shape.GetVerticalRadius());
        }
    }
}
