using ListTreeUtil;

namespace CombinatorUtil.Parser.Dervied.CommonToken.Literal_;

public class NumberLiteral : ParserCombinator
{
    public static NumberLiteral New() => new();

    public override Node<string>? Parsing(ParsingContext context) =>
        (Node<string>?)Or.New(
            Float.New(),
            Integer.New()
        ).Parsing(context);

}