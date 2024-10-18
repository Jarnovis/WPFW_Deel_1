namespace WPFW_Deel_1.codes.Klinkt_Beter;

public class ReadFile
{
    private List<Woord> woorden = new List<Woord>();
    public void Read()
    {
        using (StreamReader sr = new StreamReader("../../../../WPFW Deel 1/TextFiles/Groot.txt"))
        {
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                string[] woordenUitLine = line.Split(" ");
                foreach (string woord in woordenUitLine)
                {
                    if (woord.Length % 2 == 0)
                    {
                        woorden.Add(new Even(woord));
                    }
                    else
                    {
                        woorden.Add(new Oneven(woord));
                    }
                }
            }
        }
    }

    public void getWoorden()
    {
        foreach (Woord woord in woorden)
        {
            Console.WriteLine($"Woord: {woord.getText()} Klinkers: {woord.getAantalKlinkers()} Medeklinkers: {woord.getAantalMedelkinkers()} Totaal: {woord.getAantalKlinkers() + woord.getAantalMedelkinkers()} Soort: {woord.GetType()}");
        }
    }
}