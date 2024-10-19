namespace WPFW_Deel_1.codes.ORM;

public class Teacher : User
{
    public string teachingCourse { get; set; }
    public ICollection<Student> students { get; set; } = new List<Student>();

    public Teacher(string teachingCourse, string email) : base(email)
    {
        this.teachingCourse = teachingCourse;
    }
}