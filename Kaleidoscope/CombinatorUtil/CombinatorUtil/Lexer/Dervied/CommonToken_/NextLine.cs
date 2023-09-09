using CombinatorUtil.Lexer.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Lexer.Dervied.CommonToken_;

public class NextLine : LexerCombinator
{
    public static NextLine New() => new();

    public override Node<string>? Parsing(ParsingContext context) =>
         (Node<string>?)Or.New(
             ExpectChars.New("\r\n"),
             ExpectChars.New("\n")
         ).Parsing(context);

}
