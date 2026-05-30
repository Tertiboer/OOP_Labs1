using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SerializationApp.Models;

namespace SerializationApp.Serialization
{
    /// <summary>
    /// Handles serialization and deserialization.
    /// </summary>
    public static class JsonStorage
    {
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        };

        public static void Save(List<Person> people, string path)
        {
            List<PersonData> data = new();

            foreach (Person person in people)
            {
                data.Add(PersonData.FromPerson(person));
            }

            string json = JsonSerializer.Serialize(data, Options);

            File.WriteAllText(path, json);
        }

        public static List<Person> Load(string path)
        {
            string json = File.ReadAllText(path);

            List<PersonData>? data = JsonSerializer.Deserialize<List<PersonData>>(json, Options);

            List<Person> result = new();

            if (data != null)
            {
                foreach (PersonData item in data)
                {
                    result.Add(item.ToPerson());
                }
            }

            return result;
        }
    }
}
