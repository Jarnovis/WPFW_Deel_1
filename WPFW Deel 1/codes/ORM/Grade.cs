using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPFW_Deel_1.codes.ORM;

public class Grade
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int studentId { get; set; }
    public int value { get; private set; }

    public Grade(int value)
    {
        this.value = value;
    }
}