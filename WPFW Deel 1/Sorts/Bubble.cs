namespace WPFW_Deel_1.Sorts;

public class Bubble
{
    private int[] numbers;
    public Bubble(int[] numbers)
    {
        this.numbers = numbers;
    }

    public int[] Sort()
    {
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = 0; j < numbers.Length - i - 1; j++)
            {
                if (numbers[j] > numbers[j+1])
                {
                    int temp = numbers[j];
                    numbers[j] = numbers[j+1];
                    numbers[j+1] = temp;
                }
            }
        }
        
        return numbers;
    }
}