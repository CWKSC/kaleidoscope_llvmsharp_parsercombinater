using Kaleidoscope.AST.Expr;
using LLVMSharpUtil_.Class.BasicBlock;
using LLVMSharpUtil_.Class.Func;
using LLVMSharpUtil_.PreClass.Inst.Terminator;
using PrinterUtil;

namespace Kaleidoscope.AST.Statement;

public class ReturnStatementAST : StatementAST
{

    public ExprAST? exprAST;

    public ReturnStatementAST(ExprAST? exprAST)
    {
        this.exprAST = exprAST;
    }

    public void Codegen(PreFunc func, ref PreBasicBlock basicBlock)
    {
        if (exprAST == null)
        {
            var retInst = new PreRetInst(null);
            basicBlock.AddInst(retInst);

            // Submit basic block to func
            func.AddBasicBlock(basicBlock);
            basicBlock = new PreBasicBlock("");
        }
        else
        {
            var value = exprAST.Codegen();
            var retInst = new PreRetInst(value);
            basicBlock.AddInst(retInst);

            // Submit basic block to func
            func.AddBasicBlock(basicBlock);
            basicBlock = new PreBasicBlock("");
        }
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "ReturnStatementAST {".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        if (exprAST != null)
        {
            result += exprAST.ToStr(printer) + "\n";
        }
        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
