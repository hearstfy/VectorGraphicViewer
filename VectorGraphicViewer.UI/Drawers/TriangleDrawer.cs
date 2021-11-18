using System;
using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicViewer.Core.Models;

namespace VectorGraphicViewer.UI.Drawers
{
    internal class TriangleDrawer : IDrawer
    {
        public void Draw(Canvas canvas, Shape shape)
        {
            canvas.Children.Add(GetTriangle(shape));
        }

        private System.Windows.Shapes.Polygon GetTriangle(Shape shape)
        {
            var triangle = shape as Triangle;
            var triangleToDraw = new System.Windows.Shapes.Polygon();

            var brush = new SolidColorBrush(triangle.Color);
            triangleToDraw.Stroke = brush;
            triangleToDraw.StrokeThickness = 1;
            triangleToDraw.Points = triangle.Coordinates;
            if(triangle.Filled) triangleToDraw.Fill = brush;

            return triangleToDraw;
        }

    }
}
