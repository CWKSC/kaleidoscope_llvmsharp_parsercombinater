using CombinatorUtil.Expect_;
using CombinatorUtil.GeneralCombinator_.Node_;
using ListTreeUtil;

namespace CombinatorUtil.GeneralCombinator_.Grouping.BinraryOperator_;

public class GroupBinraryOperator : Combinator
{
    public string operatorString;
    public GroupBinraryOperator(string operatorString) => this.operatorString = operatorString;
    public static GroupBinraryOperator New(string operatorString) => new(operatorString);

    public override ASTNode? Parsing(ParsingContext context)
    {
        var operatorNode = ExpectAny.New().Parsing(context);
        if (operatorNode == null) return null;
        if (operatorNode.ToString() != operatorString) return null;

        var LHS = (Node?)ExpectAnyBackward.New().Parsing(context);
        if (LHS == null) return null;

        var RHS = (Node?)ExpectAny.New().Parsing(context);
        if (RHS == null) return null;

        return new BinraryOperatorAST(operatorString, LHS, RHS);
    }

}