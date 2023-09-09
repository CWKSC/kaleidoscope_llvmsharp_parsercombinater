using CombinatorUtil;
using CombinatorUtil.Parser.Dervied.CommonToken;
using CombinatorUtil.Parser.Expect_;
using Kaleidoscope.AST.Statement;
using Kaleidoscope.Parsing.Expr_;

namespace Kaleidoscope.Parsing.Statement_;

public class AssignStatement : Combinator
{

    public static AssignStatement New() => new();

    public override AssignStatementAST? Parsing(ParsingContext context)
    {
        if (MoveForward.New().Parsing(context) == null) return null;

        var equalKeyword = ExpectString.New("=").Parsing(context);
        if (equalKeyword == null) return null;

        if (MoveBackward.New().Parsing(context) == null) return null;

        var identifier = Identifier.New().Parsing(context);
        if (identifier == null) return null;

        var exprAST = Expr.New(";").Parsing(context);
        if (exprAST == null) return null;

        var temp1 = ExpectString.New(";").Parsing(context);
        if (temp1 == null) return null;

        return new(identifier.value, exprAST);
    }


}
