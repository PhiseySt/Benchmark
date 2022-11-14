using BenchmarkDotNet.Attributes;

namespace StructVsClassPassAsParam;


[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn, MeanColumn, MedianColumn]
[HideColumns("Gen0", "Gen1", "Gen2")]
public class Benchmark
{
    private const int NumIteration = 10000;

    [Benchmark]
    public void PassStruct() => Methods.PassStruct(NumIteration);

    [Benchmark]
    public void PassClass() => Methods.PassClass(NumIteration);
}