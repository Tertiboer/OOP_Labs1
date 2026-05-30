// Модуль: Shapes/BasicShapes.cs
// Содержит: Отрезок, Прямоугольник, Эллипс

using System;

namespace Shapes
{
    /// <summary>
    /// Отрезок — задаётся двумя точками (x1,y1) и (x2,y2).
    /// </summary>
    public class Line : Shape
    {
        public int X2 { get; set; }
        public int Y2 { get; set; }

        public Line(int x1, int y1, int x2, int y2, string color = "Black")
            : base(x1, y1, color)
        {
            X2 = x2;
            Y2 = y2;
        }

        public override void Draw()
        {
            Console.WriteLine($"Line({X}, {Y}, {X2}, {Y2})  color={Color}");
        }

        public override double Perimeter()
        {
            int dx = X2 - X, dy = Y2 - Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public override string GetInfo()
            => $"[Line] ({X},{Y}) -> ({X2},{Y2}), Color={Color}, Length={Perimeter():F2}";
    }

    // ─────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Прямоугольник — задаётся левым верхним углом, шириной и высотой.
    /// </summary>
    public class Rectangle : Shape
    {
        public int Width  { get; set; }
        public int Height { get; set; }

        public Rectangle(int x, int y, int width, int height, string color = "Black")
            : base(x, y, color)
        {
            Width  = width;
            Height = height;
        }

        public override void Draw()
        {
            Console.WriteLine($"Rectangle({X}, {Y}, {Width}, {Height})  color={Color}");
        }

        public override double Area()      => Width * Height;
        public override double Perimeter() => 2.0 * (Width + Height);

        public override string GetInfo()
            => $"[Rectangle] ({X},{Y}) {Width}x{Height}, Color={Color}, " +
               $"Area={Area():F2}, Perimeter={Perimeter():F2}";
    }

    // ─────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Эллипс — задаётся центром и полуосями a (по X) и b (по Y).
    /// </summary>
    public class Ellipse : Shape
    {
        public int RadiusX { get; set; }
        public int RadiusY { get; set; }

        public Ellipse(int cx, int cy, int rx, int ry, string color = "Black")
            : base(cx, cy, color)
        {
            RadiusX = rx;
            RadiusY = ry;
        }

        public override void Draw()
        {
            Console.WriteLine($"Ellipse({X}, {Y}, {RadiusX}, {RadiusY})  color={Color}");
        }

        public override double Area() => Math.PI * RadiusX * RadiusY;

        // Приближённая формула Рамануджана
        public override double Perimeter()
        {
            double h = Math.Pow(RadiusX - RadiusY, 2) / Math.Pow(RadiusX + RadiusY, 2);
            return Math.PI * (RadiusX + RadiusY) * (1 + 3 * h / (10 + Math.Sqrt(4 - 3 * h)));
        }

        public override string GetInfo()
            => $"[Ellipse] center=({X},{Y}) rx={RadiusX} ry={RadiusY}, Color={Color}, " +
               $"Area={Area():F2}, Perimeter={Perimeter():F2}";
    }
}
