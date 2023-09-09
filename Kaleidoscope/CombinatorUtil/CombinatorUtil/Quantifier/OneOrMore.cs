using ListTreeUtil;

namespace CombinatorUtil;

public class OneOrMore : Combinator
{

    public Combinator combinator;
    public OneOrMore(Combinator combinator) => this.combinator = combinator;
    public static OneOrMore New(Combinator combinator) => new(combinator);

    public override LList<ASTNode>? Parsing(ParsingContext context)
    {
        var result = new LList<ASTNode>();

        var first = combinator.Parsing(context);
        if (first == null) return null;
        result.Add(first);

        while (true)
        {
            var node = combinator.Parsing(context);
            if (node == null) return result;
            result.Add(node);
        }
    }

}

