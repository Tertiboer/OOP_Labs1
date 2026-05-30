// Модуль: Main/Program.cs
// Главный модуль: статическая инициализация списка фигур и запуск рисования

using System;
using Shapes;
using ShapeList;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // ── Статическая инициализация списка фигур ─────────────────────
            var collection = new ShapeCollection();

            collection.AddRange(new Shape[]
            {
                //            x    y   x2   y2
                new Line        ( 10,  10,  120,  80, "Gray"),

                //            x    y   w    h
                new Rectangle   ( 20,  30,  150, 100, "Blue"),

                //            x    y   rx   ry
                new Ellipse     (200,  80,   90,  50,                "Green"  ),

                //            cx   cy   r
                new Circle      (300, 200,   60,                     "Red"    ),

                //            x    y   side
                new Square      ( 50, 150,   80,                     "Purple" ),

                //            x1  y1   x2  y2   x3   y3
                new Triangle    ( 10, 200,  90, 200,  50,  120,      "Orange" ),

                //            x    y   w    h   radius
                new RoundedRectangle(100, 250, 180,  90,  20,        "Teal"   ),

                // Ещё несколько для демонстрации
                new Circle      (400,  50,   30,                     "Magenta"),
                new Line        (  0,   0,  400, 300,                "Black"  ),
                new Ellipse     (250, 300,   70,  30,                "Brown"  ),
            });

            // ── Рисование всех фигур (полиморфизм) ─────────────────────────
            collection.DrawAll();

            // ── Подробная информация + статистика ──────────────────────────
            collection.PrintInfo();

            // ── Демонстрация полиморфизма явно ─────────────────────────────
            Console.WriteLine("\n──────────────────────────────────────────────");
            Console.WriteLine("  Демонстрация полиморфизма (базовый тип Shape):");
            Console.WriteLine("──────────────────────────────────────────────");

            Shape baseRef;

            baseRef = new Circle(10, 10, 40, "Cyan");
            baseRef.Draw();   // вызовет Circle.Draw()

            baseRef = new Triangle(0,0, 50,0, 25,40, "Pink");
            baseRef.Draw();   // вызовет Triangle.Draw()

            baseRef = new Square(5, 5, 60, "Yellow");
            baseRef.Draw();   // вызовет Square.Draw()

            Console.WriteLine("\nГотово. Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
