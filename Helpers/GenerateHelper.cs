namespace SimoshStore;

public class GenerateHelper
{
    public static int GenerateNumber()
    {
        Random random = new Random();
        int randomNumber = random.Next(10000000, 100000000);
        return randomNumber;
    }
}
