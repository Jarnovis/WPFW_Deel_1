namespace WPFW_Deel_1.codes.TelWoorden;

public class TelWoorden
{
    private int totalRed = 0;
    
    Dictionary<String, int> woorden = new Dictionary<String, int>();
    
    public void verwerkBestand()
    {
        using (StreamReader sr = new StreamReader("../../../../WPFW Deel 1/TextFiles/Groot.txt"))
        {
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                string[] words = line.Split(" ");

                foreach (string woord in words)
                {
                    if (!woorden.ContainsKey(woord))
                    {
                        woorden.Add(woord, 0);
                    }
                    woorden[woord]++;
                    
                    totalRed++;

                    if (totalRed % 100 == 0)
                    {
                        Console.WriteLine($"Meest voorkoment woord: {woorden.Keys.Max()} Aantal Keer {woorden.Values.Max()} Uithoeveel woorden {totalRed}");
                    }
                }
            }
            
            Console.WriteLine($"Meest voorkoment woord: {woorden.Keys.Max()} Aantal Keer {woorden.Values.Max()} Uithoeveel woorden {totalRed}");
        }
    }
}