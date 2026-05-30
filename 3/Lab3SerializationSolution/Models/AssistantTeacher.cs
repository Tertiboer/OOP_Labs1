namespace SerializationApp.Models
{
    public class AssistantTeacher : Teacher
    {
        public int ExperienceYears { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Experience: {ExperienceYears}";
        }
    }
}
