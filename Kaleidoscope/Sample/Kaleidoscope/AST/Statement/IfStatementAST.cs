using Kaleidoscope.AST.Expr;
using LLVMSharpUtil_.Class.BasicBlock;
using LLVMSharpUtil_.Class.Func;
using LLVMSharpUtil_.PreClass.Inst.Terminator;
using PrinterUtil;

namespace Kaleidoscope.AST.Statement;

public class IfStatementAST : StatementAST
{

    BooleanExprAST condExpr;
    StatementsAST thenStatements;
    StatementsAST? elseStatements;

    public IfStatementAST(BooleanExprAST condExpr, StatementsAST thenStatements, StatementsAST? elseStatements)
    {
        this.condExpr = condExpr;
        this.thenStatements = thenStatements;
        this.elseStatements = elseStatements;
    }

    public void Codegen(PreFunc func, ref PreBasicBlock basicBlock)
    {
        if (elseStatements == null)
        {
            var thenBasicBlock = new PreBasicBlock("then");
            var afterThenBasicBlock = new PreBasicBlock("after_then");
            var brAfterThenInst = new PreBrInst(afterThenBasicBlock);

            var booleanExpr = condExpr.Codegen();
            var condBrInst = new PreCondBrInst(booleanExpr, thenBasicBlock, afterThenBasicBlock);
            basicBlock.AddInst(condBrInst);

            func.AddBasicBlock(basicBlock);
            basicBlock = afterThenBasicBlock;

            thenStatements.Codegen(func, ref thenBasicBlock);
            thenBasicBlock.AddInst(brAfterThenInst);
        }
        else
        {
            var thenBasicBlock = new PreBasicBlock("then");
            var elseBasicBlock = new PreBasicBlock("else");
            var afterThenElseBasicBlock = new PreBasicBlock("after_then_else");
            var brAfterThenElseInst = new PreBrInst(afterThenElseBasicBlock);

            var booleanExpr = this.condExpr.Codegen();
            var condBrInst = new PreCondBrInst(booleanExpr, thenBasicBlock, elseBasicBlock);
            basicBlock.AddInst(condBrInst);

            func.AddBasicBlock(basicBlock);
            basicBlock = afterThenElseBasicBlock;

            thenStatements.Codegen(func, ref thenBasicBlock);
            thenBasicBlock.AddInst(brAfterThenElseInst);

            elseStatements.Codegen(func, ref elseBasicBlock);
            elseBasicBlock.AddInst(brAfterThenElseInst);
        }

    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "IfStatementAST {".ToStr(printer) + "\n";
        printer.IncreaseIndent();

        result += "condExpr: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += condExpr.ToStr(printer) + "\n";
        printer.DecreaseIndent();

        result += "thenStatements: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        foreach (var statement in thenStatements)
        {
            result += statement.ToStr(printer) + "\n";
        }
        printer.DecreaseIndent();

        if (elseStatements != null)
        {
            result += "elseStatementAST: ".ToStr(printer) + "\n";
            printer.IncreaseIndent();
            foreach (var statement in elseStatements)
            {
                result += statement.ToStr(printer) + "\n";
            }
            printer.DecreaseIndent();
        }

        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }


}
