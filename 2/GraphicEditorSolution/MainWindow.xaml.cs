using System;
using System.Collections.Generic;
using System.Windows;
using GraphicEditor.Factory;
using GraphicEditor.Models;
using GraphicEditor.Rendering;

namespace GraphicEditor
{
    public partial class MainWindow : Window
    {
        private readonly Dictionary<Type, IShapeRenderer> renderers;

        public MainWindow()
        {
            InitializeComponent();

            ShapeComboBox.ItemsSource = ShapeFactory.GetAvailableShapes();
            ShapeComboBox.SelectedIndex = 0;

            renderers = new Dictionary<Type, IShapeRenderer>
            {
                { typeof(RectangleShape), new RectangleRenderer() },
                { typeof(CircleShape), new CircleRenderer() },
                { typeof(LineShape), new LineRenderer() }
            };
        }

        private void CreateShape_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedShape = ShapeComboBox.SelectedItem.ToString()!;

                ShapeBase shape = ShapeFactory.Create(selectedShape);

                shape.X = double.Parse(XTextBox.Text);
                shape.Y = double.Parse(YTextBox.Text);

                InitializeShape(shape);

                RenderShape(shape);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitializeShape(ShapeBase shape)
        {
            if (shape is RectangleShape rectangle)
            {
                rectangle.Width = 120;
                rectangle.Height = 80;
            }
            else if (shape is CircleShape circle)
            {
                circle.Radius = 50;
            }
            else if (shape is LineShape line)
            {
                line.X2 = line.X + 100;
                line.Y2 = line.Y + 100;
            }
        }

        private void RenderShape(ShapeBase shape)
        {
            Type shapeType = shape.GetType();

            if (renderers.ContainsKey(shapeType))
            {
                renderers[shapeType].Render(DrawingCanvas, shape);
            }
        }
    }
}
