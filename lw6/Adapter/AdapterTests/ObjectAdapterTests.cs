using Adapter.Adapters;
using Adapter.ModernGraphicsLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace AdapterTests
{
    [TestClass]
    public class ObjetAdapterTests
    {
        [TestMethod]
        public void LineTo_WithParameters_WithoutSetColor_ShouldDrawLineFromStartPoint()
        {
            var sw = new StringWriter();
            var point = new Point(5, 10);
            var renderer = new ModernGraphicsRenderer(sw);
            var adapter = new ObjectAdapter(renderer);

            renderer.BeginDraw();
            adapter.LineTo(point.X, point.Y);
            renderer.EndDraw();

            var expected = new StringWriter();
            expected.WriteLine("<draw>");
            expected.WriteLine($"  <line fromX=0 fromY=0 toX={point.X} toY={point.Y}>");
            expected.WriteLine("    <color r=0 g=0 b=0 a=1/>");
            expected.WriteLine("  </line>");
            expected.WriteLine("</draw>");

            Assert.AreEqual(expected.ToString(), sw.ToString());
        }

        [TestMethod]
        public void SetColor_And_LineTo_WithParameters_ShouldDrawTwoLines()
        {
            var sw = new StringWriter();
            var point1 = new Point(5, 10);
            var point2 = new Point(15, 10);
            var renderer = new ModernGraphicsRenderer(sw);
            var adapter = new ObjectAdapter(renderer);

            renderer.BeginDraw();
            adapter.SetColor(0x00FF00);
            adapter.MoveTo(point1.X, point1.Y);
            adapter.LineTo(point2.X, point2.Y);
            adapter.LineTo(point1.X, point1.Y);
            renderer.EndDraw();

            var expected = new StringWriter();
            expected.WriteLine("<draw>");
            expected.WriteLine($"  <line fromX={point1.X} fromY={point1.Y} toX={point2.X} toY={point2.Y}>");
            expected.WriteLine("    <color r=0 g=1 b=0 a=1/>");
            expected.WriteLine("  </line>");
            expected.WriteLine($"  <line fromX={point2.X} fromY={point2.Y} toX={point1.X} toY={point1.Y}>");
            expected.WriteLine("    <color r=0 g=1 b=0 a=1/>");
            expected.WriteLine("  </line>");
            expected.WriteLine("</draw>");

            Assert.AreEqual(expected.ToString(), sw.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void LineTo_WithoutBeginDraw_ShouldThrowException()
        {
            var sw = new StringWriter();
            var point = new Point(5, 10);
            var renderer = new ModernGraphicsRenderer(sw);
            var adapter = new ObjectAdapter(renderer);

            adapter.LineTo(point.X, point.Y);
        }
    }
}
