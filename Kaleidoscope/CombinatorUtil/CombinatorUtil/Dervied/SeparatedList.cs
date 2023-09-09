using CombinatorUtil.Anchor;
using ListTreeUtil;

namespace CombinatorUtil.Dervied;

public class SeparatedList : Combinator
{

    public Combinator combinator;
    public Combinator delimiter;

    public SeparatedList(Combinator combinator, Combinator delimiter)
    {
        this.combinator = combinator;
        this.delimiter = delimiter;
    }
    public static SeparatedList New(Combinator combinator, Combinator delimiter) => new(combinator, delimiter);

    public override LList<ASTNode>? Parsing(ParsingContext context)
    {
        if (IsEnd.New().Parsing(context).value) return new();

        var result = new LList<ASTNode>();
        while (true)
        {
            var node = combinator.Parsing(context);
            if (node == null) return null;
            result.Add(node);

            var isEnd = IsEnd.New().Parsing(context);
            if (isEnd.value) return result;

            var delimiterNode = delimiter.Parsing(context);
            if (delimiterNode == null) return null;

            isEnd = IsEnd.New().Parsing(context);
            if (isEnd.value) return result;
        }
    }

}