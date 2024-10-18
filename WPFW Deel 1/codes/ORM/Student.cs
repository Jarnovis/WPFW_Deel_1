namespace WPFW_Deel_1.codes.ORM;

public class Student : User
{
    public string name { get; set; }
    
    public ICollection<Grade> grades { get; set; } = new List<Grade>();
    
    public ICollection<Teacher> teachers { get; set; } = new List<Teacher>();

    public Student(string name, string email) : base(email)
    {
        this.name = name;
    }
}