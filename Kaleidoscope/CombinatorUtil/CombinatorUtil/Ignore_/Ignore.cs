using CombinatorUtil.Node_;

namespace CombinatorUtil.Ignore_;

public class Ignore : Combinator
{

    public Combinator combinator;
    public Ignore(Combinator combinator) => this.combinator = combinator;
    public static Ignore New(Combinator combinator) => new(combinator);

    public override IgnoreNode? Parsing(ParsingContext context)
    {
        var result = combinator.Parsing(context);
        return result == null ? null : new IgnoreNode();
    }

}
