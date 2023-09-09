using CombinatorUtil.Parser.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Parser.Dervied.CommonToken.Literal_;

public class StringLiteral : ParserCombinator
{
    public static StringLiteral New() => new();

    public override Node<string>? Parsing(ParsingContext context) =>
        RegexExpectString.New(@"\""(\\.|[^""\\])*\""").Parsing(context);

}
