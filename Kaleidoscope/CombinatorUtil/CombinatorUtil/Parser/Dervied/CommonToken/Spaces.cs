using CombinatorUtil.Parser.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Parser.Dervied.CommonToken;

public class Spaces : ParserCombinator
{
    public static Spaces New() => new();

    public override ASTNode? Parsing(ParsingContext context) =>
        RegexExpectString.New(@" +").Parsing(context);

}
