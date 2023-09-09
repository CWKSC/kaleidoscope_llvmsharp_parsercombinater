using CombinatorUtil.Lexer.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Lexer.Dervied.CommonToken_;

public class Colon : Combinator
{
    public static Colon New() => new();

    public override ASTNode? Parsing(ParsingContext context) =>
        ExpectChars.New(":").Parsing(context);

}