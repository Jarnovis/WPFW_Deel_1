using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPFW_Deel_1.codes.API;
public class Review
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id {get; set;}

    [Required]
    [Range(1, 10)]
    public int rating {get; set;}

    [MaxLength(1000)]
    public string description {get; set;}

    [MaxLength(50)]
    public string userName {get; set;}
    public DateTime createdAt {get; set;}

    [ForeignKey("movie")]
    public int movieId {get; set;}
    public Movie movie {get; set;}
}