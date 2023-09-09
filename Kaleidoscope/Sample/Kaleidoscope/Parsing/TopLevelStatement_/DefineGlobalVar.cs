using CombinatorUtil;
using CombinatorUtil.Parser.Dervied.CommonToken;
using CombinatorUtil.Parser.Expect_;
using Kaleidoscope.AST.TopLevelStatement;

namespace Kaleidoscope.Parsing.TopLevelStatement_;

public class DefineGlobalVar : Combinator
{
    public static DefineGlobalVar New() => new();

    public override DefineGlobalVarAST? Parsing(ParsingContext context)
    {
        var temp1 = ExpectString.New("var").Parsing(context);
        if (temp1 == null) return null;

        var identifierAST1 = Identifier.New().Parsing(context);
        if (identifierAST1 == null) return null;
        var name = identifierAST1.value;

        var temp2 = ExpectString.New(":").Parsing(context);
        if (temp2 == null) return null;

        var identifierAST2 = Identifier.New().Parsing(context);
        if (identifierAST2 == null) return null;
        var type = identifierAST2.value;

        return new(name, type);
    }

}