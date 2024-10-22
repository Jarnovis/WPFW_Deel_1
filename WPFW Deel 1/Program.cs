using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WPFW_Deel_1.codes.API;
using WPFW_Deel_1.codes.Async;
using WPFW_Deel_1.codes.Klinkt_Beter;
using WPFW_Deel_1.codes.ORM;
using WPFW_Deel_1.codes.TelWoorden;
using WPFW_Deel_1.Hexa;
using WPFW_Deel_1.Sorts;
using WPFW_Deel_1.codes.LINQ;


public class Program
{
    private static void configure(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container
        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<MovieDataBaseContext>();
    

        var app = builder.Build();

        // Configure the HTTP request pipeline
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseRouting();
        app.MapControllers(); // Map controller routes
        

        app.Run();
    }

    public static void Main(string[] args)
    {
        configure(args);
        /*runHexaDecimal();
        runSortBubble();
        runSortInt();
        runKlinktBeter();
        runTelWoorden();
        runGokAsync();
        feedDbSchool();
        runLINQ();
        feedDbMovieDataBase();
        */
    }

    private static void runHexaDecimal()
    {
        HexaDec hexaDec1 = new HexaDec(78);
        HexaDec hexaDec2 = new HexaDec(787);
        HexaDec result = hexaDec1 + hexaDec2;
        
        Console.WriteLine(hexaDec1.getHexa());
        Console.WriteLine(result.getHexa());
    }

    private static void runSortBubble()
    {
        int[] array = { 9, 3, 5, 6, 1, 0, 2, 4, 7, 8};
        
        Bubble sortBubble = new Bubble(array);

        foreach (int item in sortBubble.Sort())
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }

    private static void runSortInt()
    {
        string[] array = { "G", "A", "B", "E", "C", "D", "F", "H", "K", "J", "I" };
        
        SortInt sortInt = new SortInt();

        foreach (string item in sortInt.Sort(array))
        {
            Console.Write(item);
        }
        
        Console.WriteLine();

        foreach (string item in sortInt.SortLambda(array))
        {
            Console.Write(item);
        }
        
        Console.WriteLine();
    }

    private static void runKlinktBeter()
    {
        Bestand bestand = new Bestand("../../../../WPFW Deel 1/TextFiles/Groot.txt");
        ReadFile rf = new ReadFile();

        rf.Read(bestand);
        rf.getWoorden();
        rf.draaiOm();
    }

    private static void runTelWoorden()
    {
        TelWoorden tw = new TelWoorden();
        tw.verwerkBestand();
    }

    private static void runGokAsync()
    {
        GokAsync ga = new GokAsync();
        GokAsync.VerwerkBestand();
        ga.gok();
    }

    private static void feedDbSchool()
    {
        DataBaseContext dbc = new DataBaseContext();
        
        var DocAardrijkskunde = new Teacher("Aardrijkskunde", "AardrijskundeTeacher1@gmail.com");
        var DocHandvaardigheid = new Teacher("Handvaardigheid", "HandvaardigheidTeacher@gmail.com");
        var DocAardrijkskunde2 = new Teacher("Aardrijkskunde", "AardrijksundeTeacher2@gmail.com");
        var Jan = new Student("Jan", "Jan@gmail.com")
        {
            grades = new List<Grade>(),
            teachers = new List<Teacher>()
        };
        
       Jan.teachers.Add(DocAardrijkskunde);
       Jan.teachers.Add(DocHandvaardigheid);

        var janGrade = new Grade(5)
        {
            studentId = Jan.Id
        };

        var janGrade2 = new Grade(7)
        {
            studentId = Jan.Id
        };
        
        Jan.grades.Add(janGrade);
        Jan.grades.Add(janGrade2);
        
        var Henk = new Student("Henk", "Henk@gmail.com")
        {
            grades = new List<Grade>(),
            teachers = new List<Teacher>()
        };
        
        Henk.teachers.Add(DocAardrijkskunde2);
        Henk.teachers.Add(DocHandvaardigheid);

        var henkGrade = new Grade(9)
        {
            studentId = Henk.Id
        };
        
        Henk.grades.Add(henkGrade);

        var Flip = new Student("Flip", "Flip@gmail.com");


        dbc.Student.Add(Jan);
        dbc.Student.Add(Henk);
        dbc.Student.Add(Flip);
        dbc.Teacher.Add(DocAardrijkskunde);
        dbc.Teacher.Add(DocHandvaardigheid);
        dbc.Teacher.Add(DocAardrijkskunde2);

        dbc.SaveChanges();

    }

    private static void runLINQ()
    {
        Setup.Opdracht1();
        Setup.Opdracht2();
        Setup.Opdracht3();
        Setup.Opdracht4();
        Setup.Opdracht5();
        Setup.Opdracht6();
        Setup.Opdracht7();

        ORMLINQ ol = new ORMLINQ();

        ol.studentenMetCijfers();
        ol.aantalTeachers();
        ol.studentGeenDocent();
        ol.studentSorted();
        ol.followingHandvaardigheid();

    }

    private static void feedDbMovieDataBase()
    {
        MovieDataBaseContext mdbc = new MovieDataBaseContext();

        var Anthony = new Director()
        {
            name = "Anthony C. Ferrante"
        };

        var Todd = new Director()
        {
            name = "Todd Phillips"
        };

        var sharknado = new Movie()
        {
            title = "Sharknado",
            year = 2013,
            director = new List<Director>(),
            review = new List<Review>()
        };

        var sharknado2 = new Movie()
        {
            title = "Sharknado 2: The Second One",
            year = 2014,
            director = new List<Director>(),
            review = new List<Review>()
        };

        var sharknado3 = new Movie()
        {
            title = "Sharknado 3: Oh Hell No!",
            year = 2015,
            director = new List<Director>(),
            review = new List<Review>()
        };

        var joker = new Movie()
        {
            title = "Joker",
            year = 2019,
            director = new List<Director>(),
            review = new List<Review>()
        };

        var joker2 = new Movie()
        {
            title = "Joker: Folie à Deux",
            year = 2024,
            director = new List<Director>(),
            review = new List<Review>()
        };

        var reviewJoker1 = new Review()
        {
            rating = 9,
            description = "It was a master peace",
            userName = "JokerLover123",
            createdAt = DateTime.Today,
            movieId = joker.id
        };

        var reviewJoker2 = new Review()
        {
            rating = 1,
            description = "Dogshit. How did they fuck up. The first movie was so fucking good. I was hyped to watch part 2, but now I need to bleech my eyes. FUCKING DISGUSTING MOVIE. I wont even let my worst enemy watch this.",
            userName = "JokerLover123",
            createdAt = DateTime.Today,
            movieId = joker2.id
        };

        sharknado.director.Add(Anthony);
        sharknado2.director.Add(Anthony);
        sharknado3.director.Add(Anthony);
        joker.director.Add(Todd);
        joker2.director.Add(Todd);

        joker.review.Add(reviewJoker1);
        joker2.review.Add(reviewJoker2);

        mdbc.directors.Add(Anthony);
        mdbc.directors.Add(Todd);

        mdbc.movies.Add(sharknado);
        mdbc.movies.Add(sharknado2);
        mdbc.movies.Add(sharknado3);
        mdbc.movies.Add(joker);
        mdbc.movies.Add(joker2);

        mdbc.SaveChanges();
    }
    
}