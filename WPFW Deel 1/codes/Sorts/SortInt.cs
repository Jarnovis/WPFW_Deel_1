namespace WPFW_Deel_1.Sorts;

public class SortInt
{
    public string[] SortLambda(string[] text)
    {
        Array.Sort(text, (x, y) => x.CompareTo(y));
        return text;
    }

    public string[] Sort(string[] text)
    {
        for (int i = 1; i < text.Length; i++)
        {
            string key = text[i];
            int j = i - 1;

            while (j >= 0 && string.Compare(text[j], key) > 0)
            {
                text[j + 1] = text[j];
                j = j - 1;
            }
            text[j + 1] = key;
        }

        return text;
    }
}