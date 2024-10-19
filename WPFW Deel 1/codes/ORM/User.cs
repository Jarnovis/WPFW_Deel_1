using System.ComponentModel.DataAnnotations.Schema;

namespace WPFW_Deel_1.codes.ORM;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string email { get; private set; }

    public User(string email)
    {
        this.email = email;
    }

    public User()
    {
    }
}