using System.Data.Common;
using WPFW_Deel_1.codes.ORM;
namespace WPFW_Deel_1.codes.LINQ;
public class ORMLINQ
{
    private DataBaseContext dataBaseContext = new DataBaseContext();

    public void studentenMetCijfers()
    {
        dataBaseContext.Student.Where(s => s.grades.Count > 1).ToList().ForEach(s => Console.WriteLine(s.name));
        Console.WriteLine("====================");
    }

    public void aantalTeachers()
    {
        Console.WriteLine(dataBaseContext.Teacher.Count());
        Console.WriteLine("====================");
    }

    public void studentGeenDocent()
    {
        dataBaseContext.Student.Where(s => s.teachers.Count() == 0).ToList().ForEach(s => Console.WriteLine(s.name));
        Console.WriteLine("====================");
    }

    public void studentSorted()
    {
        dataBaseContext.Student.OrderBy(s => s.name).ToList().ForEach(s => Console.WriteLine(s.name));
        Console.WriteLine("====================");
    }

    public void followingHandvaardigheid()
    {
        dataBaseContext.Student.Where(s => s.teachers.Any(t => t.teachingCourse.Equals("Handvaardigheid"))).ToList().ForEach(s => Console.WriteLine(s.name));
        Console.WriteLine("====================");
    }
}
