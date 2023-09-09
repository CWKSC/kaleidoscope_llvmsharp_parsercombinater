using PrinterUtil;

namespace ListTreeUtil;

public abstract class ASTNode : IToStr
{
    public abstract string ToStr(Printer printer);

}