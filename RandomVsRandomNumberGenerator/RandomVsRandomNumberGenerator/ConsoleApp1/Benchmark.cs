using BenchmarkDotNet.Attributes;

namespace RandomVsRandomNumberGenerator;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn, MeanColumn, MedianColumn]
[HideColumns("Gen0", "Gen1", "Gen2")]
public class Benchmark
{
    private const int NumberGeneration = 100000;
    private const int MinValue = 0;
    private const int MaxValue = 1000;


    [Benchmark]
    public void GenerationRandom() => Methods.GenerationRandom(NumberGeneration, MinValue, MaxValue);

    [Benchmark]
    public void GenerationCryptographicRandom() => Methods.GenerationCryptographicRandom(NumberGeneration, MinValue, MaxValue);

}
