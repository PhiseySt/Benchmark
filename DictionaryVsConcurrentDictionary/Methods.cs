using System.Collections.Concurrent;

namespace DictionaryVsConcurrentDictionary;

public static class Methods
{
    public static void NotParallelAddToDictionary(int numberAddItems, string[] k, int[] v)
    {
        Dictionary<string, int> d = new();

        for (var i = 0; i < numberAddItems; i++)
        {
            SomeLongRunningMethod();

            if (!d.ContainsKey(k[i]))
                d.Add(k[i], v[i]);
            else
                d[k[i]] = v[i];
        }
    }

    public static void ParallelAddToDictionary(int numberAddItems, string[] k, int[] v)
    {
        object lockObject = new();
        Dictionary<string, int> d = new();

        Parallel.For(0, numberAddItems, x =>
        {
            SomeLongRunningMethod();
            lock (lockObject)
            {
                if (!d.ContainsKey(k[x]))
                    d.Add(k[x], v[x]);
                else
                    d[k[x]] = v[x];
            }
        });
    }

    public static void NotParallelAddToConcurrent(int numberAddItems, string[] k, int[] v)
    {
        ConcurrentDictionary<string, int> cd = new();

        for (var i = 0; i < numberAddItems; i++)
        {
            SomeLongRunningMethod();
            cd.AddOrUpdate(k[i], v[i], (k, v) => v);
        };
    }

    public static void ParallelAddToConcurrent(int numberAddItems, string[] k, int[] v)
    {
        ConcurrentDictionary<string, int> cd = new();

        Parallel.For(0, numberAddItems, x =>
        {
            SomeLongRunningMethod();
            cd.AddOrUpdate(k[x], v[x], (k, v) => v);
        });
    }

    public static void SomeLongRunningMethod()
    {
        var a = DateTime.Now.Millisecond;
        var x = double.MaxValue;
        x = Math.Sqrt(x);
        x = Math.Sqrt(a);
        var b = a + DateTime.Now.Millisecond;
        x = Math.Sqrt(b);
        x = Math.Round(Math.Sqrt(a) * Math.Sqrt(b));
        a = (int)(Math.Log(x) % Math.Log10(x));
        b = (int)(Math.Log10(x) / Math.Sqrt(x));
        a = (int)(Math.Sqrt(x));
        b = (int)(Math.Log(x));
        x *= x;
        x /= Math.Log(b);
        x -= x;
        x %= Math.Log10(a);
        x += x;
        a = 0;
        b = 0;
        x = 0;
    }
}
