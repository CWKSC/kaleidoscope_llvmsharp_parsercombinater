using LLVMSharpUtil_;
using LLVMSharpUtil_.PreClass.Var;
using PrinterUtil;

namespace Kaleidoscope.AST.Expr;

public class FuncArgAST : ExprAST
{

    public string name;
    public string type;

    public FuncArgAST(string name, string type)
    {
        this.name = name;
        this.type = type;
    }

    public override PreFuncVar Codegen()
    {
        var preType = LLVMSharpUtil.GetPreType(type);
        return new(name, preType);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += $"FuncVarAST {{ {name} }}".ToStr(printer);
        return result;
    }

}
