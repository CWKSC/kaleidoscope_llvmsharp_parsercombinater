using CombinatorUtil.Node_;
using Kaleidoscope.AST.TopLevelStatement;
using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.PreClass.Base;

namespace Kaleidoscope.AST.Expr;

public abstract class ExprAST : TopLevelStatementAST, CodegenLLVMSharpEleNode
{

    public abstract PreValue Codegen();

    PreEle CodegenLLVMSharpEleNode.Codegen() => Codegen();


}
