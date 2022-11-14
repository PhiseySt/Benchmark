namespace StructVsClassPassAsParam;

public static class Methods
{
    
    public static void PassClass(int numIteration)
    {
        for (var i = 0; i < numIteration; i++)
        {
            var sc = new SomeClass { Val1 = 1000, Val2 = 100000, Val3 = -1000 };
            LongRunningMethodClass(sc, numIteration);
        }
    }

    public static void PassStruct(int numIteration)
    {
        for (var i = 0; i < numIteration; i++)
        {
            var ss = new SomeStruct { Val1 = 1000, Val2 = 100000, Val3 = -1000 };
            LongRunningMethodStruct(ss, numIteration);
        }
    }

    public static void LongRunningMethodClass(SomeClass sc, int numIteration)
    {
        var sc2 = sc;
        var sum = 0;
        for (var i = 0; i < numIteration; i++)
        {
            sum += i;
        }
    }

    public static void LongRunningMethodStruct(SomeStruct ss, int numIteration)
    {
        var ss2 = ss;
        var sum = 0;
        for (var i = 0; i < numIteration; i++)
        {
            sum += i;
        }
    }
}

public class SomeClass
{
    public int Val1 { get; set; }
    public int Val2 { get; set; }
    public int Val3 { get; set; }
}

public struct SomeStruct
{
    public int Val1 { get; set; }
    public int Val2 { get; set; }
    public int Val3 { get; set; }
}