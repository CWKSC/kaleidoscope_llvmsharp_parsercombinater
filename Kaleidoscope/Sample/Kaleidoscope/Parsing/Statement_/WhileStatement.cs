using CombinatorUtil;
using CombinatorUtil.Parser.Expect_;
using Kaleidoscope.AST.Expr;
using Kaleidoscope.AST.Statement;
using Kaleidoscope.Parsing.Expr_;

namespace Kaleidoscope.Parsing.Statement_;

public class WhileStatement : Combinator
{

    public static WhileStatement New() => new();

    public override WhileStatementAST? Parsing(ParsingContext context)
    {
        var ifKeyword = ExpectString.New("while").Parsing(context);
        if (ifKeyword == null) return null;

        var exprAST = Expr.New("{").Parsing(context);
        if (exprAST == null) return null;

        if (exprAST is not BooleanExprAST condExpr)
        {
            throw new Exception("[WhileStatement] condExpr is not BooleanExprAST");
        }

        var statementsAST = StatementsAroundBracket.New().Parsing(context);
        if (statementsAST == null) return null;

        return new(condExpr, statementsAST);
    }


}
