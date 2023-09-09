using Kaleidoscope.AST.Expr;
using LLVMSharpUtil_.Class.BasicBlock;
using LLVMSharpUtil_.Class.Func;
using LLVMSharpUtil_.PreClass.Inst.Memory;
using PrinterUtil;

namespace Kaleidoscope.AST.Statement;

public class AssignStatementAST : StatementAST
{

    public string name;
    public ExprAST exprAST;

    public AssignStatementAST(string name, ExprAST exprAST)
    {
        this.name = name;
        this.exprAST = exprAST;
    }

    public void Codegen(PreFunc func, PreBasicBlock basicBlock)
    {
        var expr = exprAST.Codegen();
        var allocInst = func.nameToAllocInst[name];
        var storeInst = new PreStoreInst(allocInst, expr);
        basicBlock.AddInst(storeInst);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "AssignStatementAST {".ToStr(printer) + "\n";
        printer.IncreaseIndent();

        result += "name: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += name.ToStr(printer) + "\n";
        printer.DecreaseIndent();

        result += "expr: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += exprAST.ToStr(printer) + "\n";
        printer.DecreaseIndent();

        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
