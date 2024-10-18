using System.Reflection;

namespace WPFW_Deel_1.codes.Async;

public class GokAsync
{
    private static Dictionary<String, int> woorden = new Dictionary<String, int>();
    
    public static async Task VerwerkBestand()
    {
        using (StreamReader sr = new StreamReader("../../../../WPFW Deel 1/TextFiles/Groot.txt"))
        {
            string line;

            while ((line = await sr.ReadLineAsync()) != null)
            {
                string[] words = line.Split(" ");

                foreach (string word in words)
                {
                    if (!woorden.ContainsKey(word))
                    {
                        woorden.Add(word, 0);
                    }

                    woorden[word]++;
                    
                    Thread.Sleep(10);
                }
            }
        }
    }

    public void gok()
    {
        int input = 0;

        while (input != -1)
        {
            Console.WriteLine("Voer -1 in om te stoppen\nHoevaak is het meest voorkomende woord voorgekomen?: ");

            try
            {
                input = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine($"Meest voorkomend woord: {woorden.Keys.Max()}\nAantal keer voort gekomen: {woorden.Values.Max()}\nJuist gegokt: {input == woorden.Values.Max()}");
            }
            catch (Exception)
            {
                new Exception("Invoer was geen getal");
            }
        }
    }
}