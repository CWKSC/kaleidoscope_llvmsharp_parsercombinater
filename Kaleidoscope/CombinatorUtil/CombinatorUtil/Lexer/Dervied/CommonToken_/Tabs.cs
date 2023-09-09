using CombinatorUtil.Lexer.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Lexer.Dervied.CommonToken_;

public class Tabs : LexerCombinator
{

    public static Tabs New() => new();

    public override ASTNode? Parsing(ParsingContext context) =>
       RegexExpectChars.New(@"\t+").Parsing(context);

}