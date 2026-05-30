// Модуль: Shapes/Shape.cs
// Базовый абстрактный класс для всех графических фигур

namespace Shapes
{
    /// <summary>
    /// Абстрактный базовый класс для графических фигур.
    /// Определяет общий интерфейс через виртуальные и абстрактные методы.
    /// </summary>
    public abstract class Shape
    {
        // Координаты опорной точки фигуры
        public int X { get; set; }
        public int Y { get; set; }

        // Цвет контура
        public string Color { get; set; }

        protected Shape(int x, int y, string color = "Black")
        {
            X = x;
            Y = y;
            Color = color;
        }

        /// <summary>
        /// Абстрактный метод рисования — каждая фигура реализует по-своему (полиморфизм).
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Виртуальный метод — возвращает описание фигуры.
        /// Может быть переопределён в наследниках.
        /// </summary>
        public virtual string GetInfo()
        {
            return $"[{GetType().Name}] Color={Color}, Position=({X},{Y})";
        }

        /// <summary>
        /// Виртуальный метод вычисления площади.
        /// </summary>
        public virtual double Area() => 0;

        /// <summary>
        /// Виртуальный метод вычисления периметра.
        /// </summary>
        public virtual double Perimeter() => 0;

        public override string ToString() => GetInfo();
    }
}
