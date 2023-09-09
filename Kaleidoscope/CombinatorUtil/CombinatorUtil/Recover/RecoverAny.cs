using ListTreeUtil;

namespace CombinatorUtil.Recover;

public class RecoverAny : Combinator
{

    public Combinator combinator;
    public RecoverAny(Combinator combinator) => this.combinator = combinator;
    public static RecoverAny New(Combinator combinator) => new(combinator);

    public override ASTNode? Parsing(ParsingContext context)
    {
        var copy = context.Clone();
        var parsingResult = combinator.Parsing(context);
        context.ReplaceBy(copy);
        return parsingResult;
    }

}
