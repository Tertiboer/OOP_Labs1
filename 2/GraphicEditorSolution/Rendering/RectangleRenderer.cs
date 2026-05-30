using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GraphicEditor.Models;

namespace GraphicEditor.Rendering
{
    public class RectangleRenderer : IShapeRenderer
    {
        public void Render(Canvas canvas, ShapeBase shape)
        {
            RectangleShape rectangle = (RectangleShape)shape;

            Rectangle rect = new Rectangle
            {
                Width = rectangle.Width,
                Height = rectangle.Height,
                Stroke = Brushes.Black,
                Fill = Brushes.LightBlue,
                StrokeThickness = 2
            };

            Canvas.SetLeft(rect, rectangle.X);
            Canvas.SetTop(rect, rectangle.Y);

            canvas.Children.Add(rect);
        }
    }
}
