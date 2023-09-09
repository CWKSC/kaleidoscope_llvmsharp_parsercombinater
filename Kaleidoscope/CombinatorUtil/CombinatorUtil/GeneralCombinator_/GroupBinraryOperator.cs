using CombinatorUtil.Expect_;
using ListTreeUtil;
using ListTreeUtil.Base;

namespace CombinatorUtil.GeneralCombinator_;

public class BinraryOperator : Combinator
{
    string operatorString;
    public BinraryOperator(string operatorString) => this.operatorString = operatorString;
    public static BinraryOperator New(string operatorString) => new(operatorString);

    public override PairNode<Node, Node>? Parsing(ParsingContext context)
    {
        var operatorNode = ExpectWithType.New<Node<string>>().Parsing(context);
        if (operatorNode == null) return null;
        if (operatorNode.value != operatorString) return null;

        var LHS = (Node?)ExpectAnyBackward.New().Parsing(context);
        if (LHS == null) return null;

        var RHS = (Node?)ExpectAny.New().Parsing(context);
        if (RHS == null) return null;

        return new PairNode<Node, Node>(LHS, RHS);
    }

}


