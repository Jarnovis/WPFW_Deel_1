namespace WPFW_Deel_1.codes.Klinkt_Beter;

public struct Bestand
{
    public string pad { get; set; }
    public string bestandNaam { get; set; }

    public Bestand(string pad)
    {
        this.pad = Path.GetDirectoryName(pad);
        this.bestandNaam = Path.GetFileName(pad);
    }
}