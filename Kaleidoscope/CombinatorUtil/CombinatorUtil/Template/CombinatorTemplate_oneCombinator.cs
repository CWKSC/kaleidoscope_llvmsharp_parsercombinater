using ListTreeUtil;

namespace CombinatorUtil.Template;

public class CombinatorTemplate_oneCombinator : Combinator
{

    public Combinator combinator;
    public CombinatorTemplate_oneCombinator(Combinator combinator) => this.combinator = combinator;
    public static CombinatorTemplate_oneCombinator New(Combinator combinator) => new(combinator);

    public override ASTNode? Parsing(ParsingContext context)
    {
        throw new NotImplementedException();
    }

}
