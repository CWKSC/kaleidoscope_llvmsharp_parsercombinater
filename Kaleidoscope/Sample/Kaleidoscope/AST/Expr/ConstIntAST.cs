using LLVMSharpUtil_.PreClass.Constant;
using PrinterUtil;

namespace Kaleidoscope.AST.Expr;

public class ConstIntAST : ExprAST
{

    public int value;
    public ConstIntAST(int value) => this.value = value;

    public override unsafe PreConstSignInt32 Codegen()
    {
        return new PreConstSignInt32(value);
    }


    public override string ToStr(Printer printer)
    {
        var result = "";
        result += $"ConstInt {{ {value} }}".ToStr(printer);
        return result;
    }

}
