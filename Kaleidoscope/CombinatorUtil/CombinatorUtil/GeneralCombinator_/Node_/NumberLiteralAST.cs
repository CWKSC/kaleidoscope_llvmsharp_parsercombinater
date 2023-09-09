using ListTreeUtil;

namespace CombinatorUtil.GeneralCombinator_.Node_;

public class NumberLiteralAST : ExpressionAST
{

    public Node<string> numberLiteral;

    public NumberLiteralAST(Node<string> numberLiteral)
    {
        this.numberLiteral = numberLiteral;
    }

    public override string ToString()
    {
        return numberLiteral.ToString()!;
    }

}
