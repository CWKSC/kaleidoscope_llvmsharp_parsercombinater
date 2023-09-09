using CombinatorUtil.Lexer.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Lexer.Dervied.CommonToken_;

public class Identifier : LexerCombinator
{
    public static Identifier New() => new();

    public override Node<string>? Parsing(ParsingContext context) =>
        RegexExpectChars.New(@"\w[\w\d]*").Parsing(context);

}
