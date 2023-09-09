using Microsoft.CodeAnalysis.CSharp;

namespace PrinterUtil;

public class Printer
{
    public int indent = 0;
    public int indentStep = 4;
    public bool isIncreaseIndentFirstTime = true;
    public bool isUnescape = true;
    public string prefix = "";
    public string suffix = "";
    public ConsoleColor foregroundColor = ConsoleColor.Gray;
    public ConsoleColor backgroundColor = ConsoleColor.Black;

    public string recordOutput = "";

    public string GetString(string message)
    {
        if (isUnescape) message = SymbolDisplay.FormatLiteral(message, false);
        return GetIndentString() + prefix + message + suffix;
    }
    public string GetStringLine(string message)
    {
        return GetString(message) + "\n";
    }

    public void WriteLine(dynamic any)
    {
        Console.ForegroundColor = foregroundColor;
        Console.BackgroundColor = backgroundColor;
        string message = GetString(any);
        recordOutput += message + Environment.NewLine;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    //// Indent ////
    public void IncreaseIndent() => indent += indentStep;
    public void DecreaseIndent() => indent -= indentStep;
    public void IncreaseIndentExceptFirstTime()
    {
        if (isIncreaseIndentFirstTime)
        {
            isIncreaseIndentFirstTime = false;
            return;
        }
        IncreaseIndent();
    }
    public string GetIndentString() => new(' ', indent);



}