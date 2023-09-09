using ListTreeUtil;

namespace CombinatorUtil.Recover;

public class RecoverIfNull : Combinator
{

    public Combinator combinator;
    public RecoverIfNull(Combinator combinator) => this.combinator = combinator;
    public static RecoverIfNull New(Combinator combinator) => new(combinator);

    public override ASTNode? Parsing(ParsingContext context)
    {
        var copy = context.Clone();
        var parsingResult = combinator.Parsing(context);
        if (parsingResult == null)
        {
            context.ReplaceBy(copy);
            return null;
        }
        return parsingResult;
    }

}

