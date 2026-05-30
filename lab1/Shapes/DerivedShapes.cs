// Модуль: Shapes/DerivedShapes.cs
// Содержит: Окружность (наследует Ellipse), Квадрат (наследует Rectangle),
//           Треугольник, Скруглённый прямоугольник (наследует Rectangle)

using System;

namespace Shapes
{
    /// <summary>
    /// Окружность — частный случай эллипса (RadiusX == RadiusY).
    /// Демонстрирует наследование от Ellipse.
    /// </summary>
    public class Circle : Ellipse
    {
        public int Radius => RadiusX;

        public Circle(int cx, int cy, int radius, string color = "Black")
            : base(cx, cy, radius, radius, color) { }

        public override void Draw()
        {
            Console.WriteLine($"Circle({X}, {Y}, {Radius})  color={Color}");
        }

        public override double Area()      => Math.PI * Radius * Radius;
        public override double Perimeter() => 2 * Math.PI * Radius;

        public override string GetInfo()
            => $"[Circle] center=({X},{Y}) r={Radius}, Color={Color}, " +
               $"Area={Area():F2}, Perimeter={Perimeter():F2}";
    }

    // ─────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Квадрат — частный случай прямоугольника (Width == Height).
    /// Демонстрирует наследование от Rectangle.
    /// </summary>
    public class Square : Rectangle
    {
        public int Side => Width;

        public Square(int x, int y, int side, string color = "Black")
            : base(x, y, side, side, color) { }

        public override void Draw()
        {
            Console.WriteLine($"Square({X}, {Y}, {Side})  color={Color}");
        }

        public override string GetInfo()
            => $"[Square] ({X},{Y}) side={Side}, Color={Color}, " +
               $"Area={Area():F2}, Perimeter={Perimeter():F2}";
    }

    // ─────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Треугольник — задаётся тремя вершинами.
    /// </summary>
    public class Triangle : Shape
    {
        public (int X, int Y) P1 { get; }
        public (int X, int Y) P2 { get; }
        public (int X, int Y) P3 { get; }

        public Triangle(int x1, int y1, int x2, int y2, int x3, int y3,
                        string color = "Black")
            : base(x1, y1, color)
        {
            P1 = (x1, y1);
            P2 = (x2, y2);
            P3 = (x3, y3);
        }

        private static double Dist((int X, int Y) a, (int X, int Y) b)
        {
            int dx = b.X - a.X, dy = b.Y - a.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public override void Draw()
        {
            Console.WriteLine($"Triangle({P1.X},{P1.Y}, {P2.X},{P2.Y}, {P3.X},{P3.Y})" +
                              $"  color={Color}");
        }

        public override double Perimeter()
            => Dist(P1, P2) + Dist(P2, P3) + Dist(P3, P1);

        // Формула Герона
        public override double Area()
        {
            double a = Dist(P1, P2), b = Dist(P2, P3), c = Dist(P3, P1);
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        public override string GetInfo()
            => $"[Triangle] ({P1.X},{P1.Y})-({P2.X},{P2.Y})-({P3.X},{P3.Y}), " +
               $"Color={Color}, Area={Area():F2}, Perimeter={Perimeter():F2}";
    }

    // ─────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Скруглённый прямоугольник — прямоугольник с радиусом скругления углов.
    /// Демонстрирует наследование от Rectangle с расширением.
    /// </summary>
    public class RoundedRectangle : Rectangle
    {
        public int CornerRadius { get; set; }

        public RoundedRectangle(int x, int y, int width, int height,
                                int cornerRadius, string color = "Black")
            : base(x, y, width, height, color)
        {
            CornerRadius = Math.Min(cornerRadius, Math.Min(width, height) / 2);
        }

        public override void Draw()
        {
            Console.WriteLine($"RoundedRectangle({X}, {Y}, {Width}, {Height}, r={CornerRadius})" +
                              $"  color={Color}");
        }

        public override string GetInfo()
            => $"[RoundedRect] ({X},{Y}) {Width}x{Height} r={CornerRadius}, Color={Color}, " +
               $"Area={Area():F2}";
    }
}
