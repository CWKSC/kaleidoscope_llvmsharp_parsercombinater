using ListTreeUtil;

namespace CombinatorUtil.Anchor;

public class IsEnd : Combinator
{
    public static IsEnd New() => new();

    public override Node<bool> Parsing(ParsingContext context)
    {
        return Node.New(!context.list.Any());
    }

}