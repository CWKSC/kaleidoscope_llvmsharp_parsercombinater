using ListTreeUtil;

namespace CombinatorUtil.Expect_;

public class ExpectWithType<T> : Combinator
    where T : ASTNode
{

    public override T? Parsing(ParsingContext context)
    {
        var list = context.list;
        var current = context.current;
        if (current == null) return null;

        var value = current.Value;
        if (value is not T valueT) return null;

        var next = current.Next;
        list.Remove(current);
        context.current = next;
        return valueT;
    }

}

public static class ExpectWithType
{
    public static ExpectWithType<T> New<T>() where T : ASTNode => new();

}