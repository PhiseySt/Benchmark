using System.Security.Cryptography;

namespace RandomVsRandomNumberGenerator;

public class Methods
{
    public static void GenerationRandom(int numberGeneration, int minValue, int maxValue)
    {
        for (var i = 0; i < numberGeneration; i++)
        {
           var val = Random.Shared.Next(minValue, maxValue);
        }
    }

    public static void GenerationCryptographicRandom(int numberGeneration, int minValue, int maxValue)
    {
        for (var i = 0; i < numberGeneration; i++)
        {
            var val = RandomNumberGenerator.GetInt32(minValue, maxValue);
        }
    }
}