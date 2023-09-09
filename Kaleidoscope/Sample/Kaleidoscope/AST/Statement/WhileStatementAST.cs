using Kaleidoscope.AST.Expr;
using LLVMSharpUtil_.Class.BasicBlock;
using LLVMSharpUtil_.Class.Func;
using LLVMSharpUtil_.PreClass.Inst.Terminator;
using PrinterUtil;

namespace Kaleidoscope.AST.Statement;

public class WhileStatementAST : StatementAST
{

    BooleanExprAST condExpr;
    StatementsAST bodyStatements;

    public WhileStatementAST(BooleanExprAST condExpr, StatementsAST bodyStatements)
    {
        this.condExpr = condExpr;
        this.bodyStatements = bodyStatements;
    }


    public void Codegen(PreFunc func, ref PreBasicBlock basicBlock)
    {
        var condCheckBasicBlock = new PreBasicBlock("while_condition_check");
        var whileBodyBasicBlock = new PreBasicBlock("while_body");
        var afterWhileBasicBlock = new PreBasicBlock("after_while");
        var brCondCheckInst = new PreBrInst(condCheckBasicBlock);

        // Jump to while_condition_check
        basicBlock.AddInst(brCondCheckInst);
        func.AddBasicBlock(basicBlock);

        // while_condition_check
        var booleanExpr = condExpr.Codegen();
        var condBrInst = new PreCondBrInst(booleanExpr, whileBodyBasicBlock, afterWhileBasicBlock);
        condCheckBasicBlock.AddInst(condBrInst);
        func.AddBasicBlock(condCheckBasicBlock);

        // while_body
        bodyStatements.Codegen(func, ref whileBodyBasicBlock);
        whileBodyBasicBlock.AddInst(brCondCheckInst);

        basicBlock = afterWhileBasicBlock;
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "WhileStatementAST {".ToStr(printer) + "\n";
        printer.IncreaseIndent();

        //result += "condExpr: ".ToStr(printer) + "\n";
        //printer.IncreaseIndent();
        //result += condExpr.ToStr(printer) + "\n";
        //printer.DecreaseIndent();

        //result += "bodyStatements: ".ToStr(printer) + "\n";
        //printer.IncreaseIndent();
        //foreach (var statement in bodyStatements)
        //{
        //    result += statement.ToStr(printer) + "\n";
        //}
        //printer.DecreaseIndent();

        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }


}
