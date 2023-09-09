using CombinatorUtil;
using CombinatorUtil.GeneralCombinator_;
using CombinatorUtil.Node_;
using Kaleidoscope.AST.Expr;

namespace Kaleidoscope.Parsing.Expr_;

public class LessThanExpr : Combinator
{
    public static LessThanExpr New() => new();

    public override LessThanExprAST? Parsing(ParsingContext context)
    {
        var pair = BinraryOperator.New("<").Parsing(context);
        if (pair == null) return null;

        var (t1, t2) = pair;
        if (t1 is not CodegenLLVMSharpEleNode lhs) return null;
        if (t2 is not CodegenLLVMSharpEleNode rhs) return null;

        return new LessThanExprAST(lhs, rhs);
    }

}