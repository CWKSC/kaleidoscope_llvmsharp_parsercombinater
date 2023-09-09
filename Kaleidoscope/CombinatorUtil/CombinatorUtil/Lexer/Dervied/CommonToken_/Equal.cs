using CombinatorUtil.Lexer.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Lexer.Dervied.CommonToken_;

public class Equal : LexerCombinator
{

    public static Equal New() => new();

    public override Node<string>? Parsing(ParsingContext context) =>
       ExpectChars.New("=").Parsing(context);

}