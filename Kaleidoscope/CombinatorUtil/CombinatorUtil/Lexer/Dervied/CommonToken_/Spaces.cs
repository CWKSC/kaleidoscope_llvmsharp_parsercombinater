using CombinatorUtil.Lexer.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Lexer.Dervied.CommonToken_;

public class Spaces : LexerCombinator
{
    public static Spaces New() => new();

    public override Node<string>? Parsing(ParsingContext context) =>
       RegexExpectChars.New(@" +").Parsing(context);

}
