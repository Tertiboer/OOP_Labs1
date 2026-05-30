namespace SerializationApp.Models
{
    public class Administrator : Person
    {
        public string Department { get; set; } = "";

        public override string ToString()
        {
            return base.ToString() + $", Department: {Department}";
        }
    }
}
