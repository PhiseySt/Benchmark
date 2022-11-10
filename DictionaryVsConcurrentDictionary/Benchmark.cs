using BenchmarkDotNet.Attributes;

namespace DictionaryVsConcurrentDictionary;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn, MeanColumn, MedianColumn]
[HideColumns("Gen0", "Gen1", "Gen2")]
public class Benchmark
{
    private readonly int _numberAddItems = 10000;
    private readonly string[] _keys;
    private readonly int[] _values;
    private readonly Random _rng = new();
    private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public Benchmark()
    {
        _keys = new string[_numberAddItems];
        _values = new int[_numberAddItems];

        for (var x = 0; x < _keys.Length; x++)
        {
            if (x % 5 != 0)
            {
                _keys[x] = RandomString((x % 5) + 1);
                _values[x] = x;
            }
            else
            {
                _keys[x] = "Hello World";
                _values[x] = 555;
            }
        }
    }

    private string RandomString(int size)
    {
        var buffer = new char[size];

        for (var i = 0; i < size; i++)
        {
            buffer[i] = Chars[_rng.Next(Chars.Length)];
        }
        return new string(buffer);
    }

    [Benchmark]
    public void NotParallelAddToConcurrent() => Methods.NotParallelAddToConcurrent(_numberAddItems, _keys, _values);

    [Benchmark]
    public void NotParallelAddToDictionary() => Methods.NotParallelAddToDictionary(_numberAddItems, _keys, _values);

    [Benchmark]
    public void ParallelAddToConcurrent() => Methods.ParallelAddToConcurrent(_numberAddItems, _keys, _values);

    [Benchmark]
    public void ParallelAddToDictionary() => Methods.ParallelAddToDictionary(_numberAddItems, _keys, _values);

}