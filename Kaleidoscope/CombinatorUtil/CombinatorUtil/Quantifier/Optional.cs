using ListTreeUtil;

namespace CombinatorUtil;

public class Optional : Combinator
{

    public Combinator combinator;
    public Optional(Combinator combinator) => this.combinator = combinator;
    public static Optional New(Combinator combinator) => new(combinator);

    public override ASTNode Parsing(ParsingContext context)
    {
        var node = combinator.Parsing(context);
        if (node == null) return new Null();
        return node;
    }

}
