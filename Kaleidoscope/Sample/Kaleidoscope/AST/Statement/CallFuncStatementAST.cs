using Kaleidoscope.AST.Expr;
using LLVMSharpUtil_.Class.BasicBlock;
using PrinterUtil;

namespace Kaleidoscope.AST.Statement;

public class CallFuncStatementAST : StatementAST
{

    FuncCalleeAST funcCalleeAST;

    public CallFuncStatementAST(FuncCalleeAST funcCalleeAST)
    {
        this.funcCalleeAST = funcCalleeAST;
    }

    public void Codegen(PreBasicBlock basicBlock)
    {
        var funcCallInst = funcCalleeAST.Codegen();
        basicBlock.AddInst(funcCallInst);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "CallFuncStatementAST {".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += funcCalleeAST.ToStr(printer) + "\n";
        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
