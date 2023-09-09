using ListTreeUtil;
using PrinterUtil;

namespace CombinatorUtil.GeneralCombinator_.Node_;

public class BinraryOperatorAST : ExpressionAST
{

    string operatorString;
    public Node LHS;
    public Node RHS;

    public BinraryOperatorAST(string operatorString, Node lHS, Node rHS)
    {
        this.operatorString = operatorString;
        LHS = lHS;
        RHS = rHS;
    }

    public override string ToStr(Printer printer)
    {
        var result = "";

        result += "operatorString: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += operatorString.ToStr(printer) + "\n";
        printer.DecreaseIndent();

        result += "LHS: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += LHS.ToStr(printer) + "\n";
        printer.DecreaseIndent();

        result += "RHS: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += RHS.ToStr(printer);
        printer.DecreaseIndent();

        return result;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not BinraryOperatorAST other) return false;

        if (!other.operatorString.Equals(operatorString)) return false;
        if (!other.LHS.Equals(LHS)) return false;
        if (!other.RHS.Equals(RHS)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(operatorString, LHS, RHS);
    }

}
