using System.Diagnostics;

namespace StopWatchFrequency;

public class Methods
{
    public static long StopwatchLatency() => Stopwatch.GetTimestamp();


    public static long StopwatchResolution()
    {
        long lastTimestamp = Stopwatch.GetTimestamp();
        while (Stopwatch.GetTimestamp() == lastTimestamp)
        {
        }

        return lastTimestamp;
    }
}