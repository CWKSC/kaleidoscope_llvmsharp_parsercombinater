using ListTreeUtil;

namespace CombinatorUtil.AST;

public class UntilAST : Node
{

    public List<ASTNode> many;
    public ASTNode end;

    public UntilAST(List<ASTNode> many, ASTNode end)
    {
        this.many = many;
        this.end = end;
    }

}
