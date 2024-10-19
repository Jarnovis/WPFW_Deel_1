namespace WPFW_Deel_1.codes.ORM;

public class Student : User
{
    public int Id { get; set; }
    public string name { get; set; }
    
    public List<Grade> grades { get; set; } = new List<Grade>();
    public ICollection<Teacher> teachers { get; set; } = new List<Teacher>();

    public Student(string name, string email) : base(email)
    {
        this.name = name;
    }
}