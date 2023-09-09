using ListTreeUtil;
using PrinterUtil;

namespace CombinatorUtil;

public class Success : Node
{

    public override string ToStr(Printer printer)
    {
        return "Success".ToStr(printer);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not Success) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

}
