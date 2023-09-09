using CombinatorUtil.Lexer.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Lexer.Dervied.CommonToken_.Literal_;

public class Integer : LexerCombinator
{
    public static Integer New() => new();

    public override Node<string>? Parsing(ParsingContext context) =>
        RegexExpectChars.New(@"[+-]?\d+").Parsing(context);

}
