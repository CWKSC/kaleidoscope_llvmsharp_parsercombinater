using ListTreeUtil;

namespace CombinatorUtil.Expect_;

public class ExpectAny : Combinator
{

    public static ExpectAny New() => new();

    public override ASTNode? Parsing(ParsingContext context)
    {
        var current = context.current;
        var list = context.list;
        if (current == null) return null;

        var value = current.Value;
        var next = current.Next;
        list.Remove(current);
        context.current = next;
        return value;
    }

}

