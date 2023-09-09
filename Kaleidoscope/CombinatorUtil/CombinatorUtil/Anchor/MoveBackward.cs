namespace CombinatorUtil;

public class MoveBackward : Combinator
{
    public static MoveBackward New() => new();

    public override Success? Parsing(ParsingContext context)
    {
        var current = context.current;
        if (current == null) return null;

        var previous = current.Previous;
        if (previous == null) return null;

        context.current = previous;
        return new Success();
    }

}
