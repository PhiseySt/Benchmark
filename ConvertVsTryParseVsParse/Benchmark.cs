using BenchmarkDotNet.Attributes;

namespace ConvertVsTryParse;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn, MeanColumn, MedianColumn]
[HideColumns("Gen0", "Gen1", "Gen2")]
public class Benchmark
{
    private const int NumberTransformations = 1000000;

    [Benchmark]
    public void ConvertTransformation() => Methods.ConvertTransformation(NumberTransformations);

    [Benchmark]
    public void TryParseTransformation() => Methods.TryParseTransformation(NumberTransformations);

    [Benchmark]
    public void ParseTransformation() => Methods.ParseTransformation(NumberTransformations);
}