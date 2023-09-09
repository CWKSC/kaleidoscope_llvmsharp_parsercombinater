using CombinatorUtil.GeneralCombinator_.Node_;
using CombinatorUtil.Parser.Dervied.CommonToken.Literal_;
using ListTreeUtil;

namespace CombinatorUtil.Parser.Dervied;

public class SimpleExpression : ParserCombinator
{
    public static SimpleExpression New() => new();

    public override NumberLiteralAST? Parsing(ParsingContext context)
    {
        var result = NumberLiteral.New().Parsing(context);
        if (result == null) return null;

        return new NumberLiteralAST(result);
    }

}