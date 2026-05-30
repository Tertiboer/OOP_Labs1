using SerializationApp.Models;

namespace SerializationApp.Serialization
{
    /// <summary>
    /// DTO class for serialization.
    /// </summary>
    public class PersonData
    {
        public string Type { get; set; } = "";
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public double GPA { get; set; }
        public string Subject { get; set; } = "";
        public string Department { get; set; } = "";
        public string ThesisTopic { get; set; } = "";
        public int ExperienceYears { get; set; }

        public static PersonData FromPerson(Person person)
        {
            PersonData data = new()
            {
                Type = person.GetType().Name,
                Name = person.Name,
                Age = person.Age
            };

            switch (person)
            {
                case GraduateStudent g:
                    data.GPA = g.GPA;
                    data.ThesisTopic = g.ThesisTopic;
                    break;

                case AssistantTeacher at:
                    data.Subject = at.Subject;
                    data.ExperienceYears = at.ExperienceYears;
                    break;

                case Student s:
                    data.GPA = s.GPA;
                    break;

                case Teacher t:
                    data.Subject = t.Subject;
                    break;

                case Administrator a:
                    data.Department = a.Department;
                    break;
            }

            return data;
        }

        public Person ToPerson()
        {
            return Type switch
            {
                nameof(Student) => new Student
                {
                    Name = Name,
                    Age = Age,
                    GPA = GPA
                },

                nameof(Teacher) => new Teacher
                {
                    Name = Name,
                    Age = Age,
                    Subject = Subject
                },

                nameof(Administrator) => new Administrator
                {
                    Name = Name,
                    Age = Age,
                    Department = Department
                },

                nameof(GraduateStudent) => new GraduateStudent
                {
                    Name = Name,
                    Age = Age,
                    GPA = GPA,
                    ThesisTopic = ThesisTopic
                },

                nameof(AssistantTeacher) => new AssistantTeacher
                {
                    Name = Name,
                    Age = Age,
                    Subject = Subject,
                    ExperienceYears = ExperienceYears
                },

                _ => new Student
                {
                    Name = Name,
                    Age = Age,
                    GPA = GPA
                }
            };
        }
    }
}
