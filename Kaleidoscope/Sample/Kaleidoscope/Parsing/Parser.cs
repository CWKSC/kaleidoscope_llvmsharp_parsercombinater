using CombinatorUtil;
using Kaleidoscope.AST;
using Kaleidoscope.AST.TopLevelStatement;
using Kaleidoscope.Parsing.TopLevelStatement_;

namespace Kaleidoscope.Parsing;

public class Parser : Combinator
{
    public static Parser New() => new();

    public override ProgramAST Parsing(ParsingContext context)
    {
        var result = Many.New(TopLevelStatement.New()).Parsing(context);

        return new ProgramAST(result.list.Cast<TopLevelStatementAST>().ToList());
    }

}