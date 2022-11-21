using System.Globalization;

namespace ConvertVsTryParse;

public static class Methods
{
    private static readonly CultureInfo? CurrentCulture = CultureInfo.CurrentCulture;

    public static void ConvertTransformation(int numberTransformations)
    {
        for (var i = 0; i < numberTransformations; i++)
        {
            var decimalNumber = i + 0.5M;
            var strDecimalNumber = decimalNumber.ToString(CurrentCulture);
            var result = Convert.ToDecimal(strDecimalNumber);
        }
    }

    public static void TryParseTransformation(int numberTransformations)
    {
        for (var i = 0; i < numberTransformations; i++)
        {
            var decimalNumber = i + 0.5M;
            var strDecimalNumber = decimalNumber.ToString(CurrentCulture);
            var logicResult = decimal.TryParse(strDecimalNumber, out var decResult);
        }
    }

    public static void ParseTransformation(int numberTransformations)
    {
        for (var i = 0; i < numberTransformations; i++)
        {
            var decimalNumber = i + 0.5M;
            var strDecimalNumber = decimalNumber.ToString(CurrentCulture);
            var logicResult = decimal.Parse(strDecimalNumber);
        }
    }
}