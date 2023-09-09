using ListTreeUtil;
using PrinterUtil;

namespace CombinatorUtil.GeneralCombinator_.Node_;

public class BracketAST : ExpressionAST
{

    public LinkedList<ASTNode> list = new();
    public BracketAST() { }
    public BracketAST(LinkedList<ASTNode> list) => this.list = list;
    public BracketAST(params ASTNode[] list) => this.list = new(list);

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "(".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        foreach (var item in list)
        {
            if (item is IToStr iToStr)
            {
                result += iToStr.ToStr(printer);
            }
            else
            {
                result += item?.ToString() ?? "(null node)";
            }
            result += "\n";
        }
        printer.DecreaseIndent();
        result += ")".ToStr(printer);
        return result;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not BracketAST other) return false;

        if (!list.SequenceEqual(other.list)) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(list);
    }

}
