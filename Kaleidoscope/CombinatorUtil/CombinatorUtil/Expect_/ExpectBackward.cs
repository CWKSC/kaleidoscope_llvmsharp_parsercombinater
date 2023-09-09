using ListTreeUtil;

namespace CombinatorUtil;

public class ExpectBackward<T> : Combinator
    where T : ASTNode
{

    public readonly T expect;
    public ExpectBackward(T expect) => this.expect = expect;

    public override T? Parsing(ParsingContext context)
    {
        var current = context.current;
        if (current == null) return null;

        var previous = current.Previous;
        if (previous == null) return null;

        var value = previous.Value;
        if (!value.Equals(expect)) return null;

        context.list.Remove(previous);
        return (T?)value;
    }

}

public static class ExpectBackward
{
    public static ExpectBackward<T> New<T>(T expect) where T : ASTNode => new(expect);

}
