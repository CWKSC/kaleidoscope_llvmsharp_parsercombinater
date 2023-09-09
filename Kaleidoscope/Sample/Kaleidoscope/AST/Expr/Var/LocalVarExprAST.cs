using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.PreClass.Type;
using LLVMSharpUtil_.PreClass.Var;
using PrinterUtil;

namespace Kaleidoscope.AST.Expr.Var;

public class LocalVarExprAST : VarExprAST
{

    public string name;
    public LocalVarExprAST(string name) => this.name = name;

    public override PreValue Codegen()
    {
        return new PreLocalVar(name, new PreUnknownTy());
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += $"LocalVarExprAST {{ {name} }}".ToStr(printer);
        return result;
    }

}
