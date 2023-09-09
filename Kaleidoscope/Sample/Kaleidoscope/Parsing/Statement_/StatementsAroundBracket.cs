using CombinatorUtil;
using CombinatorUtil.Parser.Expect_;
using Kaleidoscope.AST.Statement;

namespace Kaleidoscope.Parsing.Statement_;


public class StatementsAroundBracket : Combinator
{
    public static StatementsAroundBracket New() => new();

    public override StatementsAST? Parsing(ParsingContext context)
    {
        var aroundManyAST = AroundMany.New(
            ExpectString.New("{"),
            Statement.New(),
            ExpectString.New("}")
        ).Parsing(context);
        if (aroundManyAST == null) return null;
        var statements = aroundManyAST.many.Select(ele => (StatementAST)ele).ToList();

        return new(statements);
    }

}