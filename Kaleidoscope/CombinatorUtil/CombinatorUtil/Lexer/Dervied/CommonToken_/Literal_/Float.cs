using CombinatorUtil.Lexer.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Lexer.Dervied.CommonToken_.Literal_;

public class Float : LexerCombinator
{
    public static Float New() => new();

    public override Node<string>? Parsing(ParsingContext context) =>
        RegexExpectChars.New(@"[+-]?\d*\.\d*").Parsing(context);


}
