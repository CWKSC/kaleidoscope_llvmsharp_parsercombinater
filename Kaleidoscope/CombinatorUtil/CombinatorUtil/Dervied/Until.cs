using CombinatorUtil.AST;
using CombinatorUtil.Recover;
using ListTreeUtil;

namespace CombinatorUtil;

public class Until : Combinator
{

    public Combinator combinator;
    public Combinator until;
    public Until(Combinator combinator, Combinator until)
    {
        this.combinator = combinator;
        this.until = until;
    }
    public static Until New(Combinator combinator, Combinator until) => new(combinator, until);

    public override UntilAST? Parsing(ParsingContext context)
    {
        var many = new List<ASTNode>();
        var list = context.list;
        while (true)
        {
            if (!list.Any()) return null;

            // Peek Until //
            var untilNode = RecoverIfNull.New(until).Parsing(context);
            if (untilNode != null) return new UntilAST(many, untilNode);

            // Many part //
            var node = combinator.Parsing(context);
            if (node == null) return null;
            many.Add(node);
        }
    }

}
