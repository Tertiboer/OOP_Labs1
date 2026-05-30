using CoreApp.Models;

namespace TeacherPlugin
{
    /// <summary>
    /// Plugin class added dynamically.
    /// </summary>
    public class Teacher : Person
    {
        public string Subject { get; set; } = "Math";

        public override string ToString()
        {
            return base.ToString() + $", Subject: {Subject}";
        }
    }
}
