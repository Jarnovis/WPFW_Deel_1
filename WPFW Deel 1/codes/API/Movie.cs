using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPFW_Deel_1.codes.API;

public class Movie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id {get; set;}

    [Required]
    [MaxLength(100)]

    public string title {get; set;}
    [Required]
    [Range(1800, 9999)]

    public int year {get; set;}
    [Required]
    public ICollection<Director> director {get; set;} = new List<Director>();
    public ICollection<Review> review {get; set;} = new List<Review>();
}