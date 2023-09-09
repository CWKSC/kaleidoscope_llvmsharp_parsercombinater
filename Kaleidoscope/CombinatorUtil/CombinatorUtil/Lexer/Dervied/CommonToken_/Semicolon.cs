using CombinatorUtil.Lexer.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Lexer.Dervied.CommonToken_;

public class Semicolon : LexerCombinator
{

    public static Semicolon New() => new();

    public override Node<string>? Parsing(ParsingContext context) =>
        ExpectChars.New(";").Parsing(context);

}