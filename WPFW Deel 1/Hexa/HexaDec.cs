namespace WPFW_Deel_1.Hexa;

public class HexaDec
{
    private string hexaDec {get; set; }
    
    public HexaDec(int number)
    {
        if (number < 0 || number > 0xFFFF)
        {
            throw new ArgumentOutOfRangeException("number", "The number must be between 0 and 0xFFFF");
        }
        hexaDec = number.ToString("X4");
    }

    public string getHexa()
    {
        return hexaDec;
    }

    public static HexaDec operator +(HexaDec a, HexaDec b)
    {
        int hexaDec1 = Convert.ToInt32(a.getHexa(), 16);
        int hexaDec2 = Convert.ToInt32(b.getHexa(), 16);
        return new HexaDec(hexaDec2 + hexaDec1);
    }
}