using CombinatorUtil;
using CombinatorUtil.Parser.Expect_;
using Kaleidoscope.AST.TopLevelStatement;
using Kaleidoscope.Parsing.Statement_;

namespace Kaleidoscope.Parsing.TopLevelStatement_;

public class MainDef : Combinator
{

    public static MainDef New() => new();

    public override MainDefAST? Parsing(ParsingContext context)
    {
        var mainKeyword = ExpectString.New("main").Parsing(context);
        if (mainKeyword == null) return null;

        context.parsingFunc = new("main");
        var statementsAST = StatementsAroundBracket.New().Parsing(context);
        if (statementsAST == null) return null;
        context.parsingFunc = null;

        return new(statementsAST);
    }

}