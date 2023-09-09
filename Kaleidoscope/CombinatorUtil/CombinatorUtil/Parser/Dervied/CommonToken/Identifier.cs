using CombinatorUtil.AST;
using CombinatorUtil.Parser.Expect_;

namespace CombinatorUtil.Parser.Dervied.CommonToken;

public class Identifier : ParserCombinator
{

    public static Identifier New() => new();

    public override IdentifierAST? Parsing(ParsingContext context)
    {
        var nameAST = RegexExpectString.New(@"\w[\w\d]*").Parsing(context);
        if (nameAST == null) return null;

        var name = nameAST.value;
        return new(name);
    }

}
