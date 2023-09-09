using ListTreeUtil;

namespace CombinatorUtil.AST;

public class AroundManyAST : Node
{

    public ASTNode start;
    public List<ASTNode> many;
    public ASTNode end;

    public AroundManyAST(ASTNode start, List<ASTNode> many, ASTNode end)
    {
        this.start = start;
        this.many = many;
        this.end = end;
    }

}
