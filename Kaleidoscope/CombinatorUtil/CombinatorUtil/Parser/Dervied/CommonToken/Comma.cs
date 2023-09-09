using CombinatorUtil.Parser.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Parser.Dervied.CommonToken;

public class Comma : ParserCombinator
{
    public static Comma New() => new();

    public override ASTNode? Parsing(ParsingContext context) =>
        ExpectString.New(",").Parsing(context);

}