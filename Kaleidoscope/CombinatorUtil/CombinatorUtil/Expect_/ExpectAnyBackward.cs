using ListTreeUtil;

namespace CombinatorUtil.Expect_;

public class ExpectAnyBackward : Combinator
{

    public static ExpectAnyBackward New() => new();

    public override ASTNode? Parsing(ParsingContext context)
    {
        var current = context.current;
        var list = context.list;
        if (current == null) return null;

        var previous = current.Previous;
        if (previous == null) return null;

        var value = previous.Value;
        list.Remove(previous);
        return value;
    }

}

