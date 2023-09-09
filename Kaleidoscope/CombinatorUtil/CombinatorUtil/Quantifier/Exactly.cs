using ListTreeUtil;

namespace CombinatorUtil.Quantifier;

public class Exactly : Combinator
{

    public Combinator combinator;
    public int n;

    public Exactly(Combinator combinator, int n)
    {
        this.combinator = combinator;
        this.n = n;
    }
    public static Exactly New(Combinator combinator, int n) => new(combinator, n);


    public override LList<ASTNode>? Parsing(ParsingContext context)
    {
        var result = new LList<ASTNode>();
        for (int i = 0; i < n; i++)
        {
            var parsingResult = combinator.Parsing(context);
            if (parsingResult == null) return null;
            result.Add(parsingResult);
        }
        return result;
    }

}



