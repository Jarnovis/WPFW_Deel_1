namespace WPFW_Deel_1.codes.Klinkt_Beter;

public class ReadFile
{
    private List<Woord> woorden = new List<Woord>();
    public void Read(Bestand bestand)
    {
        using (StreamReader sr = new StreamReader(Path.Combine(bestand.pad, bestand.bestandNaam)))
        {
            Console.WriteLine(Path.Combine(bestand.pad, bestand.bestandNaam));
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
        using (StreamWriter sw = new StreamWriter("../../../../WPFW Deel 1/TextFiles/UitvoerKlinktBeter.txt"))
        {
            foreach (Woord woord in woorden)
            {
                sw.WriteLine($"Woord: {woord.getText()} Klinkers: {woord.getAantalKlinkers()} Medeklinkers: {woord.getAantalMedelkinkers()} Palingdroom: {palingdroom(woord.getText())} Totaal: {woord.getAantalKlinkers() + woord.getAantalMedelkinkers()} Soort: {woord.GetType()}");
            }
        }
    }

    public void draaiOm()
    {
        using (StreamWriter sw = new StreamWriter("../../../../WPFW Deel 1/TextFiles/UitvoerKlinktBeterOmdraai.txt"))
        {
            foreach (Woord woord in woorden)
            {
                sw.WriteLine(woord.getText().Reverse());
            }
        }
    }

    private bool palingdroom(string woord)
    {
        return woord.Equals(new string(woord.Reverse().ToArray()));
    }
}