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
            int vertexCount = 3;
            var color = Color.Red;

            var regularPolygon = new RegularPolygon(center, radius, vertexCount, color);

            var shape = (RegularPolygon)shapeFactory.CreateShape($"RegularPolygon red {center.X} {center.Y} {radius} {vertexCount}");
            Assert.AreEqual(regularPolygon.GetColor(), shape.GetColor());
            Assert.AreEqual(regularPolygon.GetCenter().X, shape.GetCenter().X);
            Assert.AreEqual(regularPolygon.GetCenter().Y, shape.GetCenter().Y);
            Assert.AreEqual(regularPolygon.GetRadius(), shape.GetRadius());
            Assert.AreEqual(regularPolygon.GetVertexCount(), shape.GetVertexCount());
        }
    }
}
