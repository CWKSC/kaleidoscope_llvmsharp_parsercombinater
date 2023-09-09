using CombinatorUtil;
using CombinatorUtil.Parser.Expect_;
using Kaleidoscope.AST.TopLevelStatement;
using Kaleidoscope.Parsing.Statement_;

namespace Kaleidoscope.Parsing.TopLevelStatement_;

public class FuncDef : Combinator
{

    public static FuncDef New() => new();

    public override FuncDefAST? Parsing(ParsingContext context)
    {
        var def = ExpectString.New("def").Parsing(context);
        if (def == null) return null;

        var prototypeAST = Prototype.New().Parsing(context);
        if (prototypeAST == null) return null;
        context.parsingFunc = new(prototypeAST.name);
        context.parsingFunc.funcArgsNameToType = new(prototypeAST.argNameToType);

        var statementsAST = StatementsAroundBracket.New().Parsing(context);
        if (statementsAST == null) return null;
        context.parsingFunc = null;

        return new(prototypeAST, statementsAST);
    }

}