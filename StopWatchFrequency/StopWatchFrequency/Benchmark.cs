using BenchmarkDotNet.Attributes;

namespace StopWatchFrequency;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn, MeanColumn, MedianColumn]
[HideColumns("Gen0", "Gen1", "Gen2")]
public class Benchmark
{

    [Benchmark]
    public void StopwatchLatency() => Methods.StopwatchLatency();

    [Benchmark]
    public void StopwatchResolution() => Methods.StopwatchResolution();

}