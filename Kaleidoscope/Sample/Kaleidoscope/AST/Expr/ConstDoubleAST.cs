using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.Class.Constant;
using PrinterUtil;

namespace Kaleidoscope.AST.Expr;

public class ConstDoubleAST : ExprAST
{

    public float value;
    public ConstDoubleAST(float value) => this.value = value;

    public override unsafe PreValue Codegen()
    {
        return new PreConstDouble(value);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += $"ConstFloat {{ {value} }}".ToStr(printer);
        return result;
    }

}
