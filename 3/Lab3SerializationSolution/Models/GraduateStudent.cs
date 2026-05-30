namespace SerializationApp.Models
{
    public class GraduateStudent : Student
    {
        public string ThesisTopic { get; set; } = "";

        public override string ToString()
        {
            return base.ToString() + $", Thesis: {ThesisTopic}";
        }
    }
}
