using ListTreeUtil;

namespace CombinatorUtil.Expect_;

public class ExpectNodeOrListUnwarp<T> : Combinator
    where T : ASTNode
{

    public T node;
    public ExpectNodeOrListUnwarp(T node) => this.node = node;

    public override T? Parsing(ParsingContext context)
    {
        var result = ExpectAny.New().Parsing(context);
        if (result == null) return null;
        if (result is not T resultT) return null;
        if (!resultT.Equals(node)) return null;

        return resultT;
    }

}

public static class ExpectNodeOrListUnwarp
{
    public static ExpectNodeOrListUnwarp<T> New<T>(T node) where T : ASTNode => new(node);

}