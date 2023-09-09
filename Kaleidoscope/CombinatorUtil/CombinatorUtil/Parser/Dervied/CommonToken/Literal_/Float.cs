using CombinatorUtil.Parser.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Parser.Dervied.CommonToken.Literal_;

public class Float : ParserCombinator
{
    public static Float New() => new();

    public override Node<string>? Parsing(ParsingContext context) =>
        RegexExpectString.New(@"[+-]?\d*\.\d*").Parsing(context);

}
