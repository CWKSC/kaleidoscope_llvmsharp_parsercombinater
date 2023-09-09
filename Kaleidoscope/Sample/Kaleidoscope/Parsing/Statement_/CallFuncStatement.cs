using CombinatorUtil;
using CombinatorUtil.Parser.Expect_;
using Kaleidoscope.AST.Expr;
using Kaleidoscope.AST.Statement;
using Kaleidoscope.Parsing.Expr_;

namespace Kaleidoscope.Parsing.Statement_;

public class CallFuncStatement : Combinator
{
    public static CallFuncStatement New() => new();

    public override CallFuncStatementAST? Parsing(ParsingContext context)
    {
        var callKeyword = ExpectString.New("call").Parsing(context);
        if (callKeyword == null) return null;

        var exprAST = Expr.New(";").Parsing(context);
        if (exprAST == null) return null;

        var temp1 = ExpectString.New(";").Parsing(context);
        if (temp1 == null) return null;

        if (exprAST is not FuncCalleeAST funcCalleeAST) return null;

        return new(funcCalleeAST);
    }

}