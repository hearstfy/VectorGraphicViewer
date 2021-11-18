using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphicViewer.UI.Drawers;
using Xunit;

namespace VectorGraphicViewer.UnitTest.UI.DrawersTests
{
    public class DrawerFactoryTests
    {
        [Theory]
        [InlineData("line")]
        [InlineData("circle")]
        [InlineData("triangle")]
        public void ShapeTypeWithImplementedShapeReturnsDrawer(string shapeType)
        {
            var shapeDrawer = DrawerFactory.GetDrawer(shapeType);

            Assert.NotNull(shapeDrawer);
            Assert.IsAssignableFrom<IDrawer>(shapeDrawer);
        }

        [Theory]
        [InlineData("ellipse")]
        [InlineData("hexagon")]
        [InlineData("tree")]
        public void ShapeTypeWithNotImplementedShapeReturnsNotImplementedError(string shapeType)
        {
            Assert.Throws<NotImplementedException>(() => DrawerFactory.GetDrawer(shapeType));
        }
    }
}
