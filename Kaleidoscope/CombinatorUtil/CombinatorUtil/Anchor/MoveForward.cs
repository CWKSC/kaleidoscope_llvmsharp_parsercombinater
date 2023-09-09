namespace CombinatorUtil;

public class MoveForward : Combinator
{
    public static MoveForward New() => new();

    public override Success? Parsing(ParsingContext context)
    {
        var current = context.current;
        if (current == null) return null;

        var next = current.Next;
        if (next == null) return null;

        context.current = next;
        return new Success();
    }

}
