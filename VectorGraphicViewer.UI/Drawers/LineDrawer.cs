using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicViewer.Core.Models;

namespace VectorGraphicViewer.UI.Drawers
{
    internal class LineDrawer : IDrawer
    {
        public void Draw(Canvas canvas, Shape shape)
        {
            canvas.Children.Add(this.GetLine(shape));
        }

        private System.Windows.Shapes.Line GetLine(Shape shape)
        {
            var line = shape as Line;
            var lineToDraw = new System.Windows.Shapes.Line();

            lineToDraw.Stroke = new SolidColorBrush(line.Color);
            lineToDraw.StrokeThickness = 1;
            lineToDraw.X1 = line.Coordinates.ElementAt(0).X;
            lineToDraw.Y1 = line.Coordinates.ElementAt(0).Y;
            lineToDraw.X2 = line.Coordinates.ElementAt(1).X;
            lineToDraw.Y2 = line.Coordinates.ElementAt(1).Y;

            return lineToDraw;
        }
    }
}
