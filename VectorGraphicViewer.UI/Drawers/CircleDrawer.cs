using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicViewer.Core.Models;

namespace VectorGraphicViewer.UI.Drawers
{
    internal class CircleDrawer : IDrawer
    {
        public void Draw(Canvas canvas, Shape shape)
        {
            canvas.Children.Add(this.GetCircle(shape));
        }

        private System.Windows.Shapes.Ellipse GetCircle(Shape shape)
        {
            var circle = shape as Circle;
            var circleToDraw = new System.Windows.Shapes.Ellipse();

            var brush = new SolidColorBrush(circle.Color);
            circleToDraw.Stroke = brush;
            circleToDraw.StrokeThickness = 1;
            if (circle.Filled) circleToDraw.Fill = brush;
            circleToDraw.Width = circle.Radius * 2;
            circleToDraw.Height = circle.Radius * 2;
            circleToDraw.RenderTransform = new TranslateTransform(circle.Center.X - circle.Radius, circle.Center.Y - circle.Radius);

            return circleToDraw;
        }
    }
}
