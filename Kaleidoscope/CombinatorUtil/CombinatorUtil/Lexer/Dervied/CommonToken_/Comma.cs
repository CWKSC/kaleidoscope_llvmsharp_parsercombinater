using CombinatorUtil.Lexer.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Lexer.Dervied.CommonToken_;

public class Comma : LexerCombinator
{
    public static Comma New() => new();

    public override Node<string>? Parsing(ParsingContext context) =>
        ExpectChars.New(",").Parsing(context);

}