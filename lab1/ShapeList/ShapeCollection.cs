// Модуль: ShapeList/ShapeList.cs
// Класс-список фигур с методами управления и рисования

using System;
using System.Collections;
using System.Collections.Generic;
using Shapes;

namespace ShapeList
{
    /// <summary>
    /// Список графических фигур.
    /// Поддерживает добавление, удаление, перебор и групповое рисование.
    /// Реализует IEnumerable для поддержки foreach.
    /// </summary>
    public class ShapeCollection : IEnumerable<Shape>
    {
        private readonly List<Shape> _shapes = new List<Shape>();

        // Количество фигур в списке
        public int Count => _shapes.Count;

        /// <summary>Добавить фигуру в список.</summary>
        public void Add(Shape shape)
        {
            if (shape == null) throw new ArgumentNullException(nameof(shape));
            _shapes.Add(shape);
        }

        /// <summary>Добавить несколько фигур сразу.</summary>
        public void AddRange(IEnumerable<Shape> shapes)
        {
            foreach (var s in shapes) Add(s);
        }

        /// <summary>Удалить фигуру по индексу.</summary>
        public void RemoveAt(int index) => _shapes.RemoveAt(index);

        /// <summary>Очистить список.</summary>
        public void Clear() => _shapes.Clear();

        /// <summary>
        /// Нарисовать все фигуры в списке — ключевой метод, демонстрирующий полиморфизм:
        /// один вызов Draw() — разное поведение для каждого типа фигуры.
        /// </summary>
        public void DrawAll()
        {
            Console.WriteLine("╔══════════════════════════════════════════════╗");
            Console.WriteLine("║          Рисование списка фигур              ║");
            Console.WriteLine("╚══════════════════════════════════════════════╝");

            if (_shapes.Count == 0)
            {
                Console.WriteLine("  (список пуст)");
                return;
            }

            for (int i = 0; i < _shapes.Count; i++)
            {
                Console.Write($"  {i + 1,2}. ");
                _shapes[i].Draw();          // ← полиморфный вызов
            }

            Console.WriteLine($"\n  Итого фигур: {_shapes.Count}");
        }

        /// <summary>Вывести подробную информацию о всех фигурах.</summary>
        public void PrintInfo()
        {
            Console.WriteLine("\n──────────────────────────────────────────────");
            Console.WriteLine("  Детальная информация о фигурах:");
            Console.WriteLine("──────────────────────────────────────────────");

            foreach (var shape in _shapes)
                Console.WriteLine("  " + shape.GetInfo());   // ← виртуальный метод

            // Суммарная статистика
            double totalArea      = 0;
            double totalPerimeter = 0;
            foreach (var s in _shapes)
            {
                totalArea      += s.Area();
                totalPerimeter += s.Perimeter();
            }

            Console.WriteLine("──────────────────────────────────────────────");
            Console.WriteLine($"  Суммарная площадь:    {totalArea:F2}");
            Console.WriteLine($"  Суммарный периметр:   {totalPerimeter:F2}");
        }

        // Реализация IEnumerable<Shape> — поддержка foreach снаружи
        public IEnumerator<Shape> GetEnumerator() => _shapes.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()   => GetEnumerator();

        // Доступ по индексу
        public Shape this[int index] => _shapes[index];
    }
}
