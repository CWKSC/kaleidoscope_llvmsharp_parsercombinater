using Kaleidoscope.AST.Expr;
using Kaleidoscope.AST.TopLevelStatement;
using ListTreeUtil;
using LLVMSharpUtil_.Class.BasicBlock;
using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.PreClass.Func;
using LLVMSharpUtil_.PreClass.Inst.Terminator;
using PrinterUtil;

namespace Kaleidoscope.AST;

public class ProgramAST : Node
{

    List<TopLevelStatementAST> topLevelStatementASTs = new();

    public ProgramAST(List<TopLevelStatementAST> topLevelStatementASTs)
    {
        this.topLevelStatementASTs = topLevelStatementASTs;
    }

    public void Codegen()
    {
        foreach (var statement in topLevelStatementASTs)
        {
            if (statement is ExprAST exprAST)
            {
                var value = exprAST.Codegen();
                var valueTy = value.type;

                var funcTy = new PreFuncTy(valueTy, new());
                var func = new PreAnonFunc(funcTy);
                var basicBlock = new PreBasicBlock("entry");
                var retInst = new PreRetInst(value);

                basicBlock.AddInst(retInst);
                func.AddBasicBlock(basicBlock);
                Resource.module.AddFunc(func);
            }
            else if (statement is ExternAST externAST)
            {
                externAST.Codegen();
            }
            else if (statement is FuncDefAST funDefAST)
            {
                funDefAST.Codegen(Resource.module);
            }
            else if (statement is MainDefAST mainDefAST)
            {
                mainDefAST.Codegen(Resource.module);
            }
        }
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        foreach (var statement in topLevelStatementASTs)
        {
            result += statement.ToStr(printer) + "\n";
        }
        return result;
    }

}
