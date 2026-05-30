using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GraphicEditor.Models;

namespace GraphicEditor.Factory
{
    public static class ShapeFactory
    {
        private static readonly Dictionary<string, Type> Shapes;

        static ShapeFactory()
        {
            Shapes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(ShapeBase)))
                .ToDictionary(t => t.Name, t => t);
        }

        public static List<string> GetAvailableShapes()
        {
            return Shapes.Keys.ToList();
        }

        public static ShapeBase Create(string shapeName)
        {
            return (ShapeBase)Activator.CreateInstance(Shapes[shapeName])!;
        }
    }
}
