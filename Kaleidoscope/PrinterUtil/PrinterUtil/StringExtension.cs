namespace PrinterUtil;

public static class StringExtension
{

    public static void Print(this string value, Printer printer)
    {
        printer.WriteLine(value);
    }

    public static string ToStr(this string value, Printer printer)
    {
        return printer.GetString(value);
    }

}
