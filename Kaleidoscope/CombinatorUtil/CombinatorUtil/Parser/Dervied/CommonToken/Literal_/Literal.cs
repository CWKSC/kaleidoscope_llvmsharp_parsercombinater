using ListTreeUtil;

namespace CombinatorUtil.Parser.Dervied.CommonToken.Literal_;

public class Literal : ParserCombinator
{
    public static Literal New() => new();

    public override Node<string>? Parsing(ParsingContext context) =>
        (Node<string>?)Or.New(
            NumberLiteral.New(),
            StringLiteral.New()
        ).Parsing(context);

}