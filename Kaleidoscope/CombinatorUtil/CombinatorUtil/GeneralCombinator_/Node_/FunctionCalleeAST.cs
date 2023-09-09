using PrinterUtil;

namespace CombinatorUtil.GeneralCombinator_.Node_;

public class FunctionCalleeAST : ExpressionAST
{

    public string name = "";
    public List<string> args = new();

    public FunctionCalleeAST() { }
    public FunctionCalleeAST(string name, List<string> args)
    {
        this.name = name;
        this.args = args;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not FunctionCalleeAST other) return false;

        if (name != other.name) return false;
        if (!args.SequenceEqual(other.args)) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(name, args);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "FunctionCallee {".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += $"name: {name}".ToStr(printer) + "\n";
        result += $"args: {string.Join(", ", args)}".ToStr(printer) + "\n";
        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
