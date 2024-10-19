using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPFW_Deel_1.codes.API;

public class Director
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id {get; set;}

    [Required]
    [MaxLength(50)]
    public string name {get; set;}
    public ICollection<Movie> movies {get; set;} = new List<Movie>();
}