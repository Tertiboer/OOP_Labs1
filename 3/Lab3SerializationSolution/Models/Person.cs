namespace SerializationApp.Models
{
    /// <summary>
    /// Base class for all people in the system.
    /// </summary>
    public abstract class Person
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{GetType().Name}: {Name}, Age: {Age}";
        }
    }
}
