namespace WPFW_Deel_1.codes.API.DTO;

public class MovieDTO
{
    public string title {get; set;}
    public int year {get; set;}
    public List<string> director {get; set;} = new List<string>();
    public List<string> review {get; set;} = new List<string>();
}