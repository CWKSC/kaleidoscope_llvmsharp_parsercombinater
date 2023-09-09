using CombinatorUtil.Parser.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Parser.Dervied.CommonToken;

public class Bracket : ParserCombinator
{
    public static Bracket New() => new();

    public override ASTNode? Parsing(ParsingContext context) =>
        Or.New(
            ExpectString.New("("),
            ExpectString.New(")"),
            ExpectString.New("["),
            ExpectString.New("]"),
            ExpectString.New("{"),
            ExpectString.New("}")
        ).Parsing(context);

}

