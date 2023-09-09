using CombinatorUtil;
using CombinatorUtil.Parser.Expect_;
using Kaleidoscope.AST.Expr;
using Kaleidoscope.AST.Statement;
using Kaleidoscope.Parsing.Expr_;

namespace Kaleidoscope.Parsing.Statement_;

public class IfStatement : Combinator
{
    public static IfStatement New() => new();

    public override IfStatementAST? Parsing(ParsingContext context)
    {
        var ifKeyword = ExpectString.New("if").Parsing(context);
        if (ifKeyword == null) return null;

        var exprAST = Expr.New("{").Parsing(context);
        if (exprAST == null) return null;

        if (exprAST is not BooleanExprAST booleanExprAST)
        {
            throw new Exception("[IfStatement] is not BooleanExprAST");
        }

        var statementsAST = StatementsAroundBracket.New().Parsing(context);
        if (statementsAST == null) return null;

        // Else 
        var elseKeyword = ExpectString.New("else").Parsing(context);
        if (elseKeyword == null) return new(booleanExprAST, statementsAST, null);

        var elseStatementsAST = StatementsAroundBracket.New().Parsing(context);
        if (elseStatementsAST == null) return null;

        return new(booleanExprAST, statementsAST, elseStatementsAST);
    }

}