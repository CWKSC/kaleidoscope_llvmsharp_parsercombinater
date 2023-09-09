using CombinatorUtil;
using CombinatorUtil.Expect_;
using Kaleidoscope.AST.Expr;
using ListTreeUtil;

namespace Kaleidoscope.Parsing.Expr_;

public class ConstFloat : Combinator
{

    public static ConstFloat New() => new();

    public override ConstDoubleAST? Parsing(ParsingContext context)
    {
        var node = ExpectWithType.New<Node<string>>().Parsing(context);
        if (node == null) return null;

        var stringValue = node.value;
        if (!float.TryParse(stringValue, out var floatValue)) return null;

        return new ConstDoubleAST(floatValue);
    }

}