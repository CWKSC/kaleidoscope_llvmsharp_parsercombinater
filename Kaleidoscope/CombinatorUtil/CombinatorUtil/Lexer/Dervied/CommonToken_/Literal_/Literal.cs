using ListTreeUtil;

namespace CombinatorUtil.Lexer.Dervied.CommonToken_.Literal_;

public class Literal : LexerCombinator
{
    public static Literal New() => new();

    public override Node<string>? Parsing(ParsingContext context) =>
        (Node<string>?)Or.New(
            Float.New(),
            Integer.New(),
            StringLiteral.New()
        ).Parsing(context);

}