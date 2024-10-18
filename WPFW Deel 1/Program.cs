using WPFW_Deel_1.codes.Async;
using WPFW_Deel_1.codes.Klinkt_Beter;
using WPFW_Deel_1.codes.TelWoorden;
using WPFW_Deel_1.Hexa;
using WPFW_Deel_1.Sorts;


public class Program
{
    public static void Main(string[] args)
    {
        /*runHexaDecimal();
        runSortBubble();
        runSortInt();
        runKlinktBeter();
        runTelWoorden();
        */
        
        runGokAsync();
        
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
}