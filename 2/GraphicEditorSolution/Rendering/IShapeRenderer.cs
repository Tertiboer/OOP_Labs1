using System.Windows.Controls;
using GraphicEditor.Models;

namespace GraphicEditor.Rendering
{
    public interface IShapeRenderer
    {
        void Render(Canvas canvas, ShapeBase shape);
    }
}
