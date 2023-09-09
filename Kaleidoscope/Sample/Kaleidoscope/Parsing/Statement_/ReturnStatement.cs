using CombinatorUtil;
using CombinatorUtil.Parser.Expect_;
using Kaleidoscope.AST.Statement;
using Kaleidoscope.Parsing.Expr_;

namespace Kaleidoscope.Parsing.Statement_;

public class ReturnStatement : Combinator
{
    public static ReturnStatement New() => new();

    public override ReturnStatementAST? Parsing(ParsingContext context)
    {
        var returnAST = ExpectString.New("return").Parsing(context);
        if (returnAST == null) return null;


        var isVoidReturn = ExpectString.New(";").Parsing(context);
        if (isVoidReturn != null)
        {
            return new(null);
        }

        var exprAST = Expr.New(";").Parsing(context);
        if (exprAST == null) return null;

        var temp1 = ExpectString.New(";").Parsing(context);
        if (temp1 == null) return null;

        return new(exprAST);
    }

}