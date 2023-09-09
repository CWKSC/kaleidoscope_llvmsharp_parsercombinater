using CombinatorUtil;
using Kaleidoscope.AST.TopLevelStatement;

namespace Kaleidoscope.Parsing.TopLevelStatement_;

public class TopLevelStatement : Combinator
{

    public static TopLevelStatement New() => new();

    public override TopLevelStatementAST? Parsing(ParsingContext context)
    {
        var result = Or.New(
            Extern.New(),
            FuncDef.New(),
            MainDef.New()
        ).Parsing(context);
        if (result == null) return null;
        if (result is not TopLevelStatementAST topLevelStatementAST) return null;

        return topLevelStatementAST;
    }

}