using CombinatorUtil;
using CombinatorUtil.Expect_;
using Kaleidoscope.AST.Expr;
using ListTreeUtil;

namespace Kaleidoscope.Parsing.Expr_;

public class ConstInt : Combinator
{

    public static ConstInt New() => new();

    public override ConstIntAST? Parsing(ParsingContext context)
    {
        var node = ExpectWithType.New<Node<string>>().Parsing(context);
        if (node == null) return null;

        var stringValue = node.value;
        if (!int.TryParse(stringValue, out var intValue)) return null;

        return new ConstIntAST(intValue);
    }

}