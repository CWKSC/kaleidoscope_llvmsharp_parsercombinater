using CombinatorUtil.Lexer.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Lexer.Dervied.CommonToken_.Literal_;

public class StringLiteral : LexerCombinator
{
    public static StringLiteral New() => new();

    public override Node<string>? Parsing(ParsingContext context) =>
        RegexExpectChars.New(@"\""(\\.|[^""\\])*\""").Parsing(context);

}
