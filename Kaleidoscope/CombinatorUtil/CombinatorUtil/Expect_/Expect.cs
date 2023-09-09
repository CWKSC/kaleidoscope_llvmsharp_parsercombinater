using ListTreeUtil;

namespace CombinatorUtil;

public class Expect<T> : Combinator
    where T : ASTNode
{

    public readonly T expect;
    public Expect(T expect) => this.expect = expect;

    public override T? Parsing(ParsingContext context)
    {
        var list = context.list;
        var current = context.current;
        if (current == null) return null;

        var value = current.Value;
        if (!value.Equals(expect)) return null;

        var next = current.Next;
        list.Remove(current);
        context.current = next;
        return (T?)value;
    }

}

public static class Expect
{
    public static Expect<T> New<T>(T expect) where T : ASTNode => new(expect);

}
