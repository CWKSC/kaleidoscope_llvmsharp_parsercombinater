using CombinatorUtil.Parser.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Parser.Dervied.CommonToken.Literal_;

public class Integer : ParserCombinator
{
    public static Integer New() => new();

    public override Node<string>? Parsing(ParsingContext context) =>
        RegexExpectString.New(@"[+-]?\d+").Parsing(context);

}
