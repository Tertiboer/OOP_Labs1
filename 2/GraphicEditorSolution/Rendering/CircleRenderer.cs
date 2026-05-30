using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GraphicEditor.Models;

namespace GraphicEditor.Rendering
{
    public class CircleRenderer : IShapeRenderer
    {
        public void Render(Canvas canvas, ShapeBase shape)
        {
            CircleShape circle = (CircleShape)shape;

            Ellipse ellipse = new Ellipse
            {
                Width = circle.Radius * 2,
                Height = circle.Radius * 2,
                Stroke = Brushes.Black,
                Fill = Brushes.LightGreen,
                StrokeThickness = 2
            };

            Canvas.SetLeft(ellipse, circle.X);
            Canvas.SetTop(ellipse, circle.Y);

            canvas.Children.Add(ellipse);
        }
    }
}
