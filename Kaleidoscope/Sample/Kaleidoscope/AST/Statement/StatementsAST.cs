using ListTreeUtil;
using LLVMSharpUtil_.Class.BasicBlock;
using LLVMSharpUtil_.Class.Func;

namespace Kaleidoscope.AST.Statement;


public class StatementsAST : LList<StatementAST>
{
    public StatementsAST(List<StatementAST> list) : base(list)
    {
    }

    public void Codegen(PreFunc func, ref PreBasicBlock basicBlock)
    {

        foreach (var statement in list)
        {
            if (statement is DefineLocalVarStatementAST defineLocalVarStatementAST)
            {
                defineLocalVarStatementAST.Codegen(func, basicBlock);
            }
            else if (statement is AssignStatementAST assignStatementAST)
            {
                assignStatementAST.Codegen(func, basicBlock);
            }
            else if (statement is CallFuncStatementAST callFuncStatementAST)
            {
                callFuncStatementAST.Codegen(basicBlock);
            }
            else if (statement is IfStatementAST ifStatementAST)
            {
                ifStatementAST.Codegen(func, ref basicBlock);
            }
            else if (statement is WhileStatementAST whileStatementAST)
            {
                whileStatementAST.Codegen(func, ref basicBlock);
            }
            else if (statement is ReturnStatementAST returnStatementAST)
            {
                returnStatementAST.Codegen(func, ref basicBlock);
            }
        }

        if (basicBlock.instList.Count != 0)
        {
            func.AddBasicBlock(basicBlock);
        }

    }

}
