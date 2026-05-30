using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Win32;
using SerializationApp.Models;
using SerializationApp.Serialization;

namespace SerializationApp
{
    public partial class MainWindow : Window
    {
        private readonly List<Person> people = new();

        private readonly Dictionary<string, Func<Person>> creators;

        public MainWindow()
        {
            InitializeComponent();

            creators = new Dictionary<string, Func<Person>>
            {
                { "Student", () => new Student { GPA = 8.5 } },
                { "Teacher", () => new Teacher { Subject = "Math" } },
                { "Administrator", () => new Administrator { Department = "Office" } },
                { "GraduateStudent", () => new GraduateStudent { GPA = 9.0, ThesisTopic = "AI" } },
                { "AssistantTeacher", () => new AssistantTeacher { Subject = "Physics", ExperienceYears = 2 } }
            };

            TypeComboBox.ItemsSource = creators.Keys;
            TypeComboBox.SelectedIndex = 0;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string type = TypeComboBox.SelectedItem.ToString()!;

                Person person = creators[type]();

                person.Name = NameTextBox.Text;
                person.Age = int.Parse(AgeTextBox.Text);

                people.Add(person);

                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (PeopleListBox.SelectedItem is Person person)
            {
                people.Remove(person);

                RefreshList();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json"
            };

            if (dialog.ShowDialog() == true)
            {
                JsonStorage.Save(people, dialog.FileName);

                MessageBox.Show("Data saved.");
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json"
            };

            if (dialog.ShowDialog() == true)
            {
                people.Clear();

                people.AddRange(JsonStorage.Load(dialog.FileName));

                RefreshList();

                MessageBox.Show("Data loaded.");
            }
        }

        private void RefreshList()
        {
            PeopleListBox.ItemsSource = null;
            PeopleListBox.ItemsSource = people;
        }
    }
}
