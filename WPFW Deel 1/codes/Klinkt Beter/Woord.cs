using System.IO;

namespace WPFW_Deel_1.codes.Klinkt_Beter;

public abstract class Woord
{
    private string tekst { get; set; }
    private int aantalKlinkers { get; set; }
    private int aantalMedelkinkers { get; set; }
    protected char[] klinkers = { 'A', 'E', 'O', 'U', 'I' };

    public Woord(string tekst)
    {
        this.tekst = tekst;
        check();
    }

    private void check()
    {
        foreach (char c in tekst)
        {
            if (klinkers.Contains(char.ToUpper(c)))
            {
                aantalKlinkers++;
            }
            else
            {
                aantalMedelkinkers++;
            }
        }
    }

    public String getText()
    {
        return tekst;
    }

    public int getAantalKlinkers()
    {
        return aantalKlinkers;
    }

    public int getAantalMedelkinkers()
    {
        return aantalMedelkinkers;
    }
}

public class Even : Woord
{
    public Even(string tekst) : base(tekst)
    {
    }
}

public class Oneven : Woord
{
    public Oneven(string tekst) : base(tekst)
    {
    }
}