using LLVMSharpUtil_.PreClass.Type;
using LLVMSharpUtil_.PreClass.Var;
using PrinterUtil;

namespace Kaleidoscope.AST.Expr.Var;

public class FuncVarExprAST : VarExprAST
{

    public string name;
    public FuncVarExprAST(string name) => this.name = name;

    public override PreFuncVar Codegen()
    {
        return new PreFuncVar(name, new PreUnknownTy());
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += $"FuncVarExprAST {{ {name} }}".ToStr(printer);
        return result;
    }

}
