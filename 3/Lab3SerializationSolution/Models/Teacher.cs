namespace SerializationApp.Models
{
    public class Teacher : Person
    {
        public string Subject { get; set; } = "";

        public override string ToString()
        {
            return base.ToString() + $", Subject: {Subject}";
        }
    }
}
