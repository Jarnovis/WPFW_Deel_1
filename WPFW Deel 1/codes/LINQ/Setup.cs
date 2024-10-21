using System.Formats.Tar;
using System.Numerics;

public class Setup
{
    public static IList<MovieLINQ> Movies = new List<MovieLINQ>
    {
        new MovieLINQ{Title = "2001 A Space Odyssey", Year = 1968, Director = "Stanley Kubrick", Genre = "Sci-Fi"},
        new MovieLINQ{Title = "The Shining", Year = 1980, Director = "Stanley Kubrick", Genre = "Horror"},
        new MovieLINQ{Title = "Dead Poets Society", Year = 1989, Director = "Peter Weir", Genre = "Drama"},
        new MovieLINQ{Title = "The Truman Show", Year = 1998, Director = "Peter Weir", Genre = "Sci-Fi"},
        new MovieLINQ{Title = "Blade Runner", Year = 1982, Director = "Ridley Scott", Genre = "Sci-Fi"},
        new MovieLINQ{Title = "Easy Rider", Year = 1969, Director = "Dennis Hopper", Genre = "Adventure"},
        new MovieLINQ{Title = "Once Upon a Time in the West", Year = 1968, Director = "Sergio Leone", Genre = "Western"},
        new MovieLINQ{Title = "12 Angry Men", Year = 1957, Director = "Sidney Lumet", Genre = "Drama"},
        new MovieLINQ{Title = "A Clockwork Orange", Year = 1971, Director = "Stanley Kubrick", Genre = "Drama"},
        new MovieLINQ{Title = "One Flew Over the Cuckoo's Nest", Year = 1975, Director = "Milos Forman", Genre = "Drama"},
        new MovieLINQ{Title = "Brazil", Year = 1985, Director = "Terry Gilliam", Genre = "Sci-Fi"},
        new MovieLINQ{Title = "Rain Man", Year = 1988, Director = "Barry Levinson", Genre = "Drama"},
        new MovieLINQ{Title = "The Good, the Bad and the Ugly", Year = 1968, Director = "Sergio Leone", Genre = "Western"},
        new MovieLINQ{Title = "The Perks of Being a Wallflower", Year = 2012, Director = "Stephen Chbosky", Genre = "Drama"},
        new MovieLINQ{Title = "Wag The Dog", Year = 1997, Director = "Barry Levinson", Genre = "Drama"},
        new MovieLINQ{Title = "For A Few Dollars More", Year = 1965, Director = "Sergio Leone", Genre = "Western"},
        new MovieLINQ{Title = "Thelma & Louise", Year = 1991, Director = "Ridley Scott", Genre = "Drama"},
        new MovieLINQ{Title = "Ali G IndaHouse", Year = 2002, Director = "Mark Mylod", Genre = "Comedy"}
    };

    
    public static void Opdracht1()
    // Toon van alle films de titel en het jaartal, gesorteerd op jaartal.
    {
        foreach (MovieLINQ movie in Movies.OrderBy(m => m.Year))
        {
            Console.WriteLine($"{movie.Title} - {movie.Year}");
        }
        Console.WriteLine("______________________");
    }

    public static void Opdracht2()
    // In welk jaar bracht 'Sergio Leone' zijn eerste film uit?
    {
        Console.WriteLine(Movies.Where(m => m.Director.Equals("Sergio Leone")).OrderBy(m => m.Year).Select(m => m.Year).FirstOrDefault());
        Console.WriteLine("______________________");
    }

    public static void Opdracht3()
    // Hoeveel films zijn er van 'Peter Weir' van het genre 'Sci-Fi'?
    {
        Console.WriteLine(Movies.Where(m => m.Director.Equals("Peter Weir")).Where(m => m.Genre.Equals("Sci-Fi")).Select(m => m.Year).FirstOrDefault());
        Console.WriteLine("______________________");
    }

    public static void Opdracht4()
    // Toon de 6e t/m 10e film uit de lijst.
    {
        foreach (MovieLINQ movie in Movies.Take(5))
        {
            Console.WriteLine(movie.Title);
        }
        Console.WriteLine("______________________");
    }

    public static void Opdracht5()
    // Is er een film uit 1997 (True/False)?
    {
        Console.WriteLine(Movies.Any(m => m.Year == 1997));
        Console.WriteLine("______________________");
    }

    public static void Opdracht6()
    // Van welke regisseur is de film 'One Flew Over the Cuckoo's Nest'?
    {
        Console.WriteLine(Movies.Where(m => m.Title.Equals("One Flew Over the Cuckoo's Nest")).Select(m => m.Director));
        Console.WriteLine("______________________");
    }

    public static void Opdracht7()
    // Wat is het 1000e Fibonacci getal?
    {
        Console.WriteLine(Fibonacci().ElementAt(999));
        Console.WriteLine("______________________");
    }

    public static IEnumerable<BigInteger> Fibonacci()
    {
        BigInteger number1 = 1;
        BigInteger number2 = 1;
        yield return number1;
        while (true)
        {
            yield return number2;
            BigInteger temp = number1 + number2;
            number1 = number2;
            number2 = temp;
        }
    }
}