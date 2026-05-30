using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GraphicEditor.Models;

namespace GraphicEditor.Rendering
{
    public class LineRenderer : IShapeRenderer
    {
        public void Render(Canvas canvas, ShapeBase shape)
        {
            LineShape lineShape = (LineShape)shape;

            Line line = new Line
            {
                X1 = lineShape.X,
                Y1 = lineShape.Y,
                X2 = lineShape.X2,
                Y2 = lineShape.Y2,
                Stroke = Brushes.Red,
                StrokeThickness = 2
            };

            canvas.Children.Add(line);
        }
    }
}
